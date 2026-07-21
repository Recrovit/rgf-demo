using System.Text.Json;
using RGF.DemoApp.Client.Models;

namespace RGF.DemoApp.Features.UserInfo;

public static class UserInfoResponseParser
{
    public static UserInfoDto Parse(JsonElement root)
    {
        var additionalClaims = new Dictionary<string, IReadOnlyList<string>>(StringComparer.OrdinalIgnoreCase);
        var roles = new List<string>();
        string? subject = null;
        string? name = null;
        string? email = null;

        foreach (var property in root.EnumerateObject())
        {
            var values = ReadValues(property.Value);

            switch (property.Name)
            {
                case "sub":
                    subject = values.FirstOrDefault();
                    break;
                case "name":
                    name = values.FirstOrDefault();
                    break;
                case "email":
                    email = values.FirstOrDefault();
                    break;
                case "emails":
                    email ??= values.FirstOrDefault();
                    additionalClaims[property.Name] = values;
                    break;
                case "role":
                case "roles":
                    roles.AddRange(values);
                    break;
                default:
                    additionalClaims[property.Name] = values;
                    break;
            }
        }

        return new UserInfoDto
        {
            Subject = subject ?? string.Empty,
            Name = name,
            Email = email,
            Roles = roles,
            AdditionalClaims = additionalClaims
        };
    }

    private static IReadOnlyList<string> ReadValues(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Array => element.EnumerateArray().Select(ReadSingleValue).ToArray(),
            _ => [ReadSingleValue(element)]
        };
    }

    private static string ReadSingleValue(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => element.GetString() ?? string.Empty,
            JsonValueKind.Number => element.GetRawText(),
            JsonValueKind.True => bool.TrueString,
            JsonValueKind.False => bool.FalseString,
            _ => element.GetRawText()
        };
    }
}
