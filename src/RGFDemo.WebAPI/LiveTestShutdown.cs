using Microsoft.Extensions.Hosting;

namespace RGFDemo.WebAPI;

internal static class LiveTestShutdown
{
    internal static bool IsEnabled(bool development, string? hostId, bool inputRedirected)
        => development && inputRedirected && hostId is { Length: 32 }
            && Guid.TryParseExact(hostId, "N", out var id) && id != Guid.Empty;

    internal static async Task ListenAsync(TextReader input, IHostApplicationLifetime lifetime)
    {
        while (!lifetime.ApplicationStopping.IsCancellationRequested)
        {
            var command = await input.ReadLineAsync();
            if (command is null or "stop")
            {
                lifetime.StopApplication();
                return;
            }
        }
    }
}
