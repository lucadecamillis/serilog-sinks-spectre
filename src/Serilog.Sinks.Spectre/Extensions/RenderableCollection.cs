using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Extensions;

/// <summary>
/// Create a <see cref="IRenderable" /> object as collection of sub-renderables
/// </summary>
public class RenderableCollection(IEnumerable<IRenderable> items) : IRenderable
{
    // Not used here
    public Measurement Measure(RenderOptions options, int maxWidth) => new();

    public IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        return items.SelectMany(i => i.Render(options, maxWidth));
    }
}