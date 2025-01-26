using Itmo.ObjectOrientedProgramming.Lab3.TextWriters;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private readonly ITextWriter _writer;
    private Color _color;

    public DisplayDriver(ITextWriter writer)
    {
        _writer = writer;
    }

    public void Clear()
    {
        _writer.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Print(string message)
    {
        _writer.WriteText(ColourText(message));
    }

    private string ColourText(string text) => Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text);
}