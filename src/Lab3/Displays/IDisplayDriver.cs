using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    void Clear();

    void SetColor(Color color);

    void Print(string message);
}