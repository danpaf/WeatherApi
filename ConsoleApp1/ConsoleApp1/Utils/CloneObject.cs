using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Utils;

public class CloningUtility
{
    public T CloneObject<T>(IClonable<T> obj)
    {
        return obj.Clone();
    }
}
