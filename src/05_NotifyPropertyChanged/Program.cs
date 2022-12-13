class Program
{
    static void Main()
    {
        var vector = new Vector( 2, 2 );
        vector.PropertyChanged += ( _, e ) => Console.WriteLine( $"Property {e.PropertyName} has changed." );
        vector.X = 3;
    }
}


[NotifyPropertyChanged]
partial class Vector
{
    public Vector( double x, double y )
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }
}

class ColoredVector : Vector
{
    public string Color { get; set; }

    public ColoredVector(double x, double y, string color) : base(x, y)
    {
        this.Color = color;
    }
}

