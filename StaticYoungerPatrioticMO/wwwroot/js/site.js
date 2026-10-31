(function () {
    'use strict';
    const $ = (s, c) => (c || document).querySelector(s);
    const $$ = (s, c) => Array.from((c || document).querySelectorAll(s));
    const reduced = window.matchMedia('(prefers-reduced-motion: reduce)').matches;

    /* ========== 1. ЧАСТИЦЫ-«ИСКРЫ» В HERO (canvas) ========== */
    (function sparks() {
        const canvas = $('#sparks');
        const hero = $('#hero');
        if (!canvas || !hero) return;
        const ctx = canvas.getContext('2d');
        const dpr = Math.min(window.devicePixelRatio || 1, 2);
        let w = 0, h = 0, running = true, parts = [];

        function resize() {
            w = canvas.width = canvas.offsetWidth * dpr;
            h = canvas.height = canvas.offsetHeight * dpr;
        }
        function spawn(fromBottom) {
            return {
                x: Math.random() * w,
                y: fromBottom ? h + 12 * dpr : Math.random() * h,
                r: (Math.random() * 2.1 + 0.7) * dpr,
                s: (Math.random() * 0.85 + 0.3) * dpr,
                d: (Math.random() - 0.5) * 0.35 * dpr,
                a: Math.random() * 0.45 + 0.25,
                f: Math.random() * Math.PI * 2
            };
        }
        resize();
        window.addEventListener('resize', resize);
        parts = Array.from({ length: 64 }, () => spawn(false));

        function tick() {
            if (running && !reduced) {
                ctx.clearRect(0, 0, w, h);
                ctx.shadowColor = 'rgba(255,179,71,.9)';
                ctx.shadowBlur = 9 * dpr;
                ctx.fillStyle = '#f7c948';
                for (const p of parts) {
                    p.y -= p.s;
                    p.f += 0.02;
                    p.x += p.d + Math.sin(p.f) * 0.3 * dpr;
                    if (p.y < -14 * dpr || p.x < -20 || p.x > w + 20) Object.assign(p, spawn(true));
                    ctx.globalAlpha = p.a * (0.65 + 0.35 * Math.sin(p.f * 2));
                    ctx.beginPath();
                    ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
                    ctx.fill();
                }
                ctx.globalAlpha = 1;
                ctx.shadowBlur = 0;
            }
            requestAnimationFrame(tick);
        }
        if (!reduced) {
            tick();
            new IntersectionObserver(e => { running = e[0].isIntersecting; }, { threshold: 0.05 }).observe(hero);
            document.addEventListener('visibilitychange', () => { if (document.hidden) running = false; else running = true; });
        }
    })();

    /* ========== 2. ПОДЪЁМ ЗНАКА «ИСКРЫ» И ПОЯВЛЕНИЕ БЛОКОВ ПРИ СКРОЛЛЕ ========== */
    const appear = new IntersectionObserver(entries => {
        entries.forEach(en => {
            if (!en.isIntersecting) return;
            en.target.classList.add('in-view');   // секция: поднимает знак искры + watermark
            en.target.classList.add('in');        // reveal-элемент
            appear.unobserve(en.target);
        });
    }, { threshold: 0.16 });
    $$('section[data-animate], .reveal').forEach(el => appear.observe(el));

    /* ========== 3. СЧЁТЧИКИ ========== */
    const counters = new IntersectionObserver(entries => {
        entries.forEach(en => {
            if (!en.isIntersecting) return;
            const el = en.target;
            counters.unobserve(el);
            const target = parseInt(el.dataset.count, 10) || 0;
            if (reduced) { el.textContent = String(target); return; }
            const dur = 1500, t0 = performance.now();
            (function step(t) {
                const k = Math.min(1, (t - t0) / dur);
                const e = 1 - Math.pow(1 - k, 3);
                el.textContent = String(Math.round(target * e));
                if (k < 1) requestAnimationFrame(step);
            })(t0);
        });
    }, { threshold: 0.6 });
    $$('[data-count]').forEach(el => counters.observe(el));

    /* ========== 4. НАВИГАЦИЯ: scrollspy, burger, фон шапки ========== */
    const nav = $('#nav'), toTop = $('#toTop'), burger = $('#navBurger');
    const links = $$('.nav-link');
    const sections = links
        .map(l => $(l.getAttribute('href')))
        .filter(Boolean);

    const spy = new IntersectionObserver(entries => {
        entries.forEach(en => {
            if (!en.isIntersecting) return;
            links.forEach(l => l.classList.toggle('active', l.getAttribute('href') === '#' + en.target.id));
        });
    }, { rootMargin: '-45% 0px -50% 0px' });
    sections.forEach(s => spy.observe(s));

    burger.addEventListener('click', () => {
        const open = document.body.classList.toggle('menu-open');
        burger.setAttribute('aria-expanded', String(open));
    });
    links.forEach(l => l.addEventListener('click', () => {
        document.body.classList.remove('menu-open');
        burger.setAttribute('aria-expanded', 'false');
    }));

    /* ========== 5. СКРОЛЛ: шапка, кнопка «наверх», параллакс лент ========== */
    const waveA = $('.wave-a'), waveB = $('.wave-b');
    let queued = false;
    function onScroll() {
        nav.classList.toggle('scrolled', window.scrollY > 40);
        toTop.classList.toggle('show', window.scrollY > 600);
        if (!reduced && !queued) {
            queued = true;
            requestAnimationFrame(() => {
                const y = window.scrollY;
                if (waveA) waveA.style.transform = 'translateY(' + (y * -0.045) + 'px)';
                if (waveB) waveB.style.transform = 'translateY(' + (y * -0.085) + 'px)';
                queued = false;
            });
        }
    }
    window.addEventListener('scroll', onScroll, { passive: true });
    onScroll();

    toTop.addEventListener('click', () =>
        window.scrollTo({ top: 0, behavior: reduced ? 'auto' : 'smooth' }));
})();