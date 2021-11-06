using System.Collections.Generic;
using System.Linq;
using Spectre.Console.Rendering;

namespace Serilog.Sinks.Spectre.Extensions
{
	/// <summary>
	/// Create a <see cref="IRenderable"/> object as collection of sub-renderables
	/// </summary>
	public class RenderableCollection : IRenderable
	{
		readonly IRenderable[] items;

		public RenderableCollection(IRenderable[] items)
		{
			this.items = items;
		}

		public Measurement Measure(RenderContext context, int maxWidth)
		{
			// Not used here
			return new Measurement();
		}

		public IEnumerable<Segment> Render(RenderContext context, int maxWidth)
		{
			foreach (Segment segment in this.items.SelectMany(i => i.Render(context, maxWidth)))
			{
				yield return segment;
			}
		}
	}
}