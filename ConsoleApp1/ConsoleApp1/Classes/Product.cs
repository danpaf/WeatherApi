using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Classes;

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}