using MindBoxTest.Base;
using MyLibrary;

namespace MyLibrary.Figures;
public class Triangle : Figure
{
    private const double Tolerance = 0.0001;
    private Lazy<bool> _isRightAngle;
    public bool IsRightAngle => _isRightAngle.Value;
    private List <double> Sides = new ();
    public Triangle(params double[] sides)
    {
        Sides = sides.ToList();
        _isRightAngle = new Lazy<bool>(CalculateRightAngle);
        Validate();
    }

    private bool CalculateRightAngle()
    {
        return Math.Abs(Math.Pow(Sides.ElementAt(2), 2) - (Math.Pow(Sides.ElementAt(0), 2) + Math.Pow(Sides.ElementAt(1), 2))) < Tolerance;
    }

    protected sealed override void Validate()
    {
        
        if (Sides.Count != 3)
        {
            throw new ArgumentException("Triangle can has only 3 sides");
        }

        if (!(Sides[0] < Sides[1]+ Sides[2] || Sides[1] < Sides[0] + Sides[2]|| Sides[2] < Sides[0] + Sides[1]))
        {
            throw new ArgumentException("Triangle doesn't exist with this sides");
        }
    }

    public override double CalculateSquare()
    {
        var p = 0.5 * Sides.Sum(x => x);
        return Math.Sqrt(p * (p - Sides.ElementAt(0)) * (p - Sides.ElementAt(1)) *
                         (p - Sides.ElementAt(2)));
    }
}