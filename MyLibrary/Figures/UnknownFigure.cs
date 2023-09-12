using System.Numerics;
using MindBoxTest.Base;

namespace MyLibrary.Figures;
public class UnknownFigure : Figure
{
    private readonly List<Vector2> _side;

    public UnknownFigure(params Vector2[] dots)
    {
        _side = dots.ToList();
        Validate();
    }

    protected sealed override void Validate()
    {
       
    }

    public override double CalculateSquare()
    {
        double sum = 0;
        for (var i = 0; i < _side.Count; i++)
        {
            var j = (i + 1) % _side.Count;
            var p1 = _side[i];
            var p2 = _side[j];

            sum += p1.X * p2.Y - p1.Y * p2.X;
        }
        return Math.Abs(sum) / 2;
    }
}