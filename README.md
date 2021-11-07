# Serilog.Sinks.Spectre ![Build status](https://github.com/lucadecamillis/serilog-sinks-spectre/actions/workflows/ci.yml/badge.svg?branch=master)

C# Serilog sink for [Spectre.Console](https://spectreconsole.net/). Started as C# port of the F# package [Serilog.Sinks.SpectreConsole](https://github.com/PragmaticFlow/Serilog.Sinks.SpectreConsole), later the code has been refactored to be more in line with the internal design of Spectre.Console.

### Usage

Install the package via nuget:

```shell
dotnet add package Serilog.Sinks.Spectre
```

The sink can be enabled using `WriteTo.Spectre()`:

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.Spectre()
    .CreateLogger();
```

The format of events to the console can be modified using the `outputTemplate` configuration parameter:

```csharp
    .WriteTo.Spectre(outputTemplate: "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
```
The sink can also be configured via `appsettings.json` using the [_Microsoft.Extensions.Configuration_](https://github.com/serilog/serilog-settings-configuration) package:

```json
{
	"Serilog": {
		"MinimumLevel": "Debug",
		"WriteTo": [
			{
				"Name": "Spectre",
				"Args": {
					"outputTemplate": "[{Timestamp:HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}"
				}
			}
		]
	}
}
```

Special attention has been paid to the integration of Serilog with _Microsoft.Extensions.Logging_. Check out the [Space Library example](https://github.com/lucadecamillis/serilog-sinks-spectre/blob/master/src/Serilog.Sinks.Spectre.Demo/Program.cs) demo. (taken from [spectre.console samples](https://github.com/spectreconsole/spectre.console/blob/3545e0f6b5aa1c381ca14fd17b1e3c58d2fee226/examples/Console/Status/Program.cs)).