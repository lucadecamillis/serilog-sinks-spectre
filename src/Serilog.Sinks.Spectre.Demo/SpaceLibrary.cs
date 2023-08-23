using Microsoft.Extensions.Logging;
using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace Serilog.Sinks.Spectre.Demo;

public class SpaceLibrary
{
    private readonly Microsoft.Extensions.Logging.ILogger logger;

    public SpaceLibrary(Microsoft.Extensions.Logging.ILogger logger)
    {
        this.logger = logger;
    }

    public Task Run() =>
        AnsiConsole.Status()
                   .AutoRefresh(true)
                   .Spinner(Spinner.Known.Default)
                   .StartAsync("[yellow]Initializing warp drive[/]", AsyncProcess);

    private async Task AsyncProcess(StatusContext ctx)
    {
        var waitingTime = TimeSpan.FromMilliseconds(500);

        // Initialize
        await Task.Delay(waitingTime).ConfigureAwait(false);
        logger.LogInformation("Starting gravimetric field displacement manifold");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        logger.LogInformation("Warming up deuterium chamber");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        logger.LogInformation("Generating antideuterium");
        try
        {
            throw new InvalidOperationException("Something has gone wrong");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred");
        }

        // Warp nacelles
        await Task.Delay(waitingTime).ConfigureAwait(false);
        ctx.Spinner(Spinner.Known.BouncingBar);
        ctx.Status("[bold blue]Unfolding warp nacelles[/]");
        logger.LogInformation("Unfolding left warp nacelle");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        logger.LogInformation("Left warp nacelle [green]online[/]");
        logger.LogInformation("Unfolding right warp nacelle");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        logger.LogInformation("Right warp nacelle {online}", "online");

        // Warp bubble
        await Task.Delay(waitingTime).ConfigureAwait(false);
        ctx.Spinner(Spinner.Known.Star2);
        ctx.Status("[bold blue]Generating warp bubble[/]");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        ctx.Spinner(Spinner.Known.Star);
        ctx.Status("[bold blue]Stabilizing warp bubble[/]");

        // Safety
        ctx.Spinner(Spinner.Known.Monkey);
        ctx.Status("[bold blue]Performing safety checks[/]");
        logger.LogInformation("Enabling interior {0}", "dampening");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        logger.LogInformation("Interior dampening [green]enabled[/]");

        // Warp!
        await Task.Delay(waitingTime).ConfigureAwait(false);
        ctx.Spinner(Spinner.Known.Moon);
        logger.LogInformation("Preparing for warp");
        await Task.Delay(waitingTime).ConfigureAwait(false);
        for (var warp = 1; warp < 10; warp++)
        {
            ctx.Status($"[bold blue]Warp {warp}[/]");
            await Task.Delay(waitingTime).ConfigureAwait(false);
        }
    }
}