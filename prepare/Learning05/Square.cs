public class Square : Shape
{
    private double _side;

    public Square(string color, string name, double side) : base(color, name)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
        
    }
}