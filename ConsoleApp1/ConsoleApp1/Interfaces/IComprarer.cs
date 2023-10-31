namespace ConsoleApp1.Interfaces;

public interface IComparer<T> where T : struct
{
    int Compare(T x, T y);
}
