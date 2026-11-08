namespace StaticYoungerPatrioticMO.Models;

public sealed record Supporter(string Name);
public sealed record Partner(string Name);
public sealed record ContactPoint(string Title, string Address, string Note);
public sealed record NormRow(string Exercise, string Value);

public sealed record NormInfo(
    IReadOnlyList<NormRow> Physical,
    IReadOnlyList<string> Individual,
    IReadOnlyList<string> Group,
    IReadOnlyList<string> Extra,
    string Reward);

public sealed record RankInfo(string Name, string Age, int Pips, string Description, NormInfo Norms);
public sealed record TaskBlock(string Id, string Title, string Icon, string Lead, IReadOnlyList<string> Items);
public sealed record PhotoItem(string Src, string Caption);
public sealed record AboutBlock(string Title, IReadOnlyList<string> Paragraphs, IReadOnlyList<string> Bullets);
public sealed record TrusteeRecord(string Name, string Role, string Photo, string Details);
public sealed record SocialLink(string Id, string Name, string Hint, string Url);

public sealed record SiteInfo(
    string City,
    string Year,
    int Quota,
    string QuotaYear,
    int AgeMin,
    int AgeMax);