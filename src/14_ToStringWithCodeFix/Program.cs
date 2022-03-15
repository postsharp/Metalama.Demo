// This is an open-source Metalama example. See https://github.com/postsharp/Metalama.Samples for more.

using System;

[ToString]
internal class MovingVertex
{
    public double X;

    public double Y;

    public double DX;

    public double DY { get; set; }

    [NotToString]

    public double Velocity => Math.Sqrt( (this.DX * this.DX) + (this.DY * this.DY) );
}

internal class Program
{
    private static void Main()
    {
        var car = new MovingVertex { X = 5, Y = 3, DX = 0.1, DY = 0.3 };

        Console.WriteLine( $"car = {car}" );
    }
}
