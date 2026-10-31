namespace StaticYoungerPatrioticMO.Models
{
    public sealed record Supporter(string Name);
    public sealed record Partner(string Name);
    public sealed record ContactPoint(string Title, string Address, string Note);
    public sealed record RankInfo(string Name, string Years, int Pips, string Description);
    public sealed record TaskBlock(string Id, string Title, string Icon, string Lead, IReadOnlyList<string> Items);
    public sealed record PhotoItem(string Src, string Caption);
    public sealed record SiteInfo(
        string City,
        string Year,
        int Quota,
        string QuotaYear,
        int AgeMin,
        int AgeMax);
}
