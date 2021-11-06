using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Spectre.Console;

namespace Serilog.Sinks.Spectre.Demo
{
	public class SpaceLibrary
	{
		readonly Microsoft.Extensions.Logging.ILogger logger;

		public SpaceLibrary(Microsoft.Extensions.Logging.ILogger logger)
		{
			this.logger = logger;
		}

		public Task Run()
		{
			return AnsiConsole.Status()
				.AutoRefresh(true)
				.Spinner(Spinner.Known.Default)
				.StartAsync("[yellow]Initializing warp drive[/]", AsyncProcess);
		}
		private async Task AsyncProcess(StatusContext ctx)
		{
			TimeSpan waitingTime = TimeSpan.FromMilliseconds(500);

			// Initialize
			await Task.Delay(waitingTime).ConfigureAwait(false);
			this.logger.LogInformation("Starting gravimetric field displacement manifold");

			await Task.Delay(waitingTime).ConfigureAwait(false);
			this.logger.LogInformation("Warming up deuterium chamber");

			await Task.Delay(waitingTime).ConfigureAwait(false);
			this.logger.LogInformation("Generating antideuterium");

			try
			{
				throw new InvalidOperationException("Something has gone wrong");
			}
			catch (Exception ex)
			{
				this.logger.LogError(ex, "An error occurred");
			}

			// Warp nacelles
			await Task.Delay(waitingTime).ConfigureAwait(false);
			ctx.Spinner(Spinner.Known.BouncingBar);
			ctx.Status("[bold blue]Unfolding warp nacelles[/]");
			this.logger.LogInformation("Unfolding left warp nacelle");

			await Task.Delay(waitingTime).ConfigureAwait(false);
			this.logger.LogInformation("Left warp nacelle [green]online[/]");
			this.logger.LogInformation("Unfolding right warp nacelle");

			await Task.Delay(waitingTime).ConfigureAwait(false);
			this.logger.LogInformation("Right warp nacelle {online}", "online");

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
			this.logger.LogInformation("Enabling interior {0}", "dampening");

			await Task.Delay(waitingTime).ConfigureAwait(false);
			this.logger.LogInformation("Interior dampening [green]enabled[/]");

			// Warp!
			await Task.Delay(waitingTime).ConfigureAwait(false);
			ctx.Spinner(Spinner.Known.Moon);
			this.logger.LogInformation("Preparing for warp");

			await Task.Delay(waitingTime).ConfigureAwait(false);
			for (var warp = 1; warp < 10; warp++)
			{
				ctx.Status($"[bold blue]Warp {warp}[/]");
				await Task.Delay(waitingTime).ConfigureAwait(false);
			}
		}
	}
}