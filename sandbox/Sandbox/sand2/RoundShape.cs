using System.Reflection.Metadata.Ecma335;

class RoundShape
{
    public double _radius;

    public double GetRadius() {return _radius; }

    public void SetRadius(double r) {_radius = r;}

    override public double Area()
    {
        return Math.PI * _radius * _radius;
    }
}