// namespace MyLibrary.Figures;
namespace MindBoxTest.Base
{
    public abstract class Figure
    {
        private readonly Lazy<double> _square;
        
        protected Figure()
        {
            _square = new Lazy<double>(CalculateSquare);
        }

        protected abstract void Validate();

        public abstract double CalculateSquare();
    }
}