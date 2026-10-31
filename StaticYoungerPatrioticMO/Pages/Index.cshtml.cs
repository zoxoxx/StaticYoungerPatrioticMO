using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StaticYoungerPatrioticMO.Models;

namespace StaticYoungerPatrioticMO.Pages
{
    public class IndexModel : PageModel
    {
        public SiteInfo Info { get; } = new(
            City: "Санкт-Петербург",
            Year: "2026",
            Quota: 156,
            QuotaYear: "2026/27",
            AgeMin: 12,
            AgeMax: 18);

        public IReadOnlyList<string> Goals { get; } = new[]
        {
        "Поддержка и воспитание молодёжи, попавшей в трудную жизненную ситуацию;",
        "Профилактика вовлечения подростков в неформальные группы деструктивной направленности;",
        "Привитие культурных, общественных ценностей и гордости за свою Родину."
    };

        public IReadOnlyList<string> Realization { get; } = new[]
        {
        "Юный «искровец» получает дневник заданий, которые необходимо выполнить за определённый временной интервал.",
        "Задания чередуются: физические, творческие, культурные.",
        "Прогресс фиксируется в дневнике и подтверждается кураторами и командиром дружины."
    };

        public IReadOnlyList<TaskBlock> Tasks { get; } = new[]
        {
        new TaskBlock("phys", "Физические", "icon-medal",
            "Сила, выносливость и дисциплина.",
            new[]
            {
                "Занятия различными видами спорта (футбол, баскетбол, бокс, шахматы и т.д.);",
                "НВП и оказание первой помощи;",
                "Управление и сборка БПЛА;",
                "Выезды на полигон для занятий и сдачи нормативов;",
                "Участие в военно-спортивной игре «Зарница»."
            }),
        new TaskBlock("art", "Творческие", "icon-palette",
            "Воображение, ремесло и сцена.",
            new[]
            {
                "Кулинарные занятия;",
                "Участие в театральных постановках;",
                "Рукоделие и прикладное творчество;",
                "Занятия танцами и многое другое."
            }),
        new TaskBlock("cult", "Культурные", "icon-museum",
            "Наследие, память и вдохновение.",
            new[]
            {
                "Совместное посещение музеев и выставок;",
                "Общественные пространства Санкт-Петербурга;",
                "Театры и культурно-массовые мероприятия;",
                "Спортивные события вместе с партнёрами программы."
            })
    };

        public IReadOnlyList<RankInfo> Ranks { get; } = new[]
        {
        new RankInfo("Новобранец", "старт", 0, "Первый шаг: получение дневника заданий и знакомство с отрядом."),
        new RankInfo("Старшина", "1 год", 1, "Первые испытания дневника и спортивные нормативы."),
        new RankInfo("Лейтенант", "2 года", 2, "Уверенный строй: ответственность за младших и результат отряда."),
        new RankInfo("Инженер", "3–4 года", 3, "Нормативы под контролем 33-й отдельной бригады оперативного назначения."),
        new RankInfo("Пионер", "3–4 года", 4, "Высшее звание «искровца» — пример во всём и право носить форму со знаками отличия.")
    };

        public IReadOnlyList<string> RankRules { get; } = new[]
        {
        "Пройти испытания из дневника заданий;",
        "Сдать спортивные нормативы;",
        "Прилежно учиться в школе;",
        "Не иметь замечаний по поведению."
    };

        public IReadOnlyList<Supporter> Supporters { get; } = new[]
        {
        new Supporter("Правительство Санкт-Петербурга"),
        new Supporter("Администрация Калининского района"),
        new Supporter("Законодательное Собрание Санкт-Петербурга"),
        new Supporter("УТ МВД РФ по СЗФО"),
        new Supporter("ОАО РЖД"),
        new Supporter("Спецназ «Ахмат»"),
        new Supporter("33-я отдельная ордена Жукова бригада оперативного назначения")
    };

        public IReadOnlyList<Partner> Partners { get; } = new[]
        {
        new Partner("ФК «Зенит»"),
        new Partner("Концерн «Калашников»"),
        new Partner("ПМЦ Калининского района С-Пб"),
        new Partner("ЦФКиС Калининского района С-Пб"),
        new Partner("Благотворительный фонд «Сиверский»"),
        new Partner("«Своя Мастерская»")
    };

        public IReadOnlyList<ContactPoint> JoinPoints { get; } = new[]
        {
        new ContactPoint("Администрация Калининского района",
            "ул. Михайлова, дом 9",
            "Отдел по вопросам законности, правопорядка и безопасности: приём заявлений и консультации."),
        new ContactPoint("Комиссия по делам несовершеннолетних",
            "Арсенальная набережная, дом 13/1",
            "Администрация Калининского района: сопровождение семей и подростков."),
        new ContactPoint("Штаб Народной Дружины «Калининская»",
            "ул. Карпинского, дом 27, корп. 2",
            "Запись в отряд, выдача дневников, допуск к очередным званиям."),
        new ContactPoint("Подразделения по делам несовершеннолетних УТ МВД РФ по СЗФО",
            "адрес уточняется при обращении",
            "Профилактика, безопасность и сопровождение участников программы.")
    };

        public IReadOnlyList<PhotoItem> Photos { get; } = new[]
        {
        new PhotoItem("~/images/photos/photo-1.svg", "Военно-спортивная игра «Зарница»"),
        new PhotoItem("~/images/photos/photo-2.svg", "Сдача спортивных нормативов"),
        new PhotoItem("~/images/photos/photo-3.svg", "Творческие занятия «искровцев»")
    };

        // ЗАМЕНИТЕ на реальные контактные данные программы
        public string ContactEmail { get; } = "info@iskra-spb.ru";
        public string ContactPhone { get; } = "+7 (812) 000-00-00";
        public string ContactHours { get; } = "Пн–Пт: 10:00 – 18:00";

        // Готовые значения для Razor (чтобы не вычислять в разметке)
        public string CleanPhone => ContactPhone
            .Replace(" ", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("-", "");

        public string StatsDelay1 => "--d:90ms";
        public string StatsDelay2 => "--d:180ms";
        public string StatsDelay3 => "--d:270ms";

        public string AboutRealizationDelay => "--d:120ms";
        public string RulesAccentDelay => "--d:120ms";

        public string ContactMailDelay => "--d:80ms";
        public string ContactPhoneDelay => "--d:160ms";
        public string ContactHoursDelay => "--d:240ms";
        public string ContactOtherDelay => "--d:320ms";

        public string StepsDelay1 => "--d:90ms";
        public string StepsDelay2 => "--d:180ms";
        public string StepsDelay3 => "--d:270ms";
    }
}
