namespace ConsoleApp1.Structs;

public struct ComplexNumber : IComparer<ComplexNumber>
{
    public double Real { get; }
    public double Imaginary { get; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public int Compare(ComplexNumber x, ComplexNumber y)
    {
        double xMagnitude = x.Real * x.Real + x.Imaginary * x.Imaginary;
        double yMagnitude = y.Real * y.Real + y.Imaginary * y.Imaginary;

        if (xMagnitude < yMagnitude)
            return -1;
        else if (xMagnitude > yMagnitude)
            return 1;
        else
            return 0;
    }
}