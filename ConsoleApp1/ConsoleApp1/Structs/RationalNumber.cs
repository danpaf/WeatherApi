namespace ConsoleApp1.Structs;

public struct RationalNumber : IComparer<RationalNumber>
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public int Compare(RationalNumber x, RationalNumber y)
    {
        double xValue = (double)x.Numerator / x.Denominator;
        double yValue = (double)y.Numerator / y.Denominator;

        if (xValue < yValue)
            return -1;
        else if (xValue > yValue)
            return 1;
        else
            return 0;
    }
}