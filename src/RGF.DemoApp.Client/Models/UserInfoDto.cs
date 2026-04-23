namespace RGF.DemoApp.Client.Models;

public sealed class UserInfoDto
{
    public string Subject { get; init; } = string.Empty;

    public string? Name { get; init; }

    public string? Email { get; init; }

    public IReadOnlyList<string> Roles { get; init; } = [];

    public IReadOnlyDictionary<string, IReadOnlyList<string>> AdditionalClaims { get; init; }
        = new Dictionary<string, IReadOnlyList<string>>();
}
