using MindBoxTest.Base;

namespace MyLibrary.Figures;
public class Circle : Figure
{
    private double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
        Validate();
    }

    protected sealed override void Validate()
    {
        if (Radius < 0)
        {
            throw new ArgumentException("Radius can't be negative");
        }
    }

    public override double CalculateSquare()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}