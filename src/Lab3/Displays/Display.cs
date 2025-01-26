using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;
    private Color _color;

    public Display(IDisplayDriver driver, Color color)
    {
        _driver = driver;
        _color = color;
    }

    public void ChangeColor(Color color)
    {
        _color = color;
    }

    public void DisplayText(string message)
    {
        _driver.Clear();
        _driver.SetColor(_color);
        _driver.Print(message);
    }

    public void ReceiveMessage(string message)
    {
        DisplayText(message);
    }
}