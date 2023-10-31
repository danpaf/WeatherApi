using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Classes;

public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}