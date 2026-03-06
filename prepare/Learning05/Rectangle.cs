public class Rectangle : Shape
{
    private double _length;

    private double _width;

    public Rectangle(string color,string name, double length, double width) : base (color, name)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;   
    }
}