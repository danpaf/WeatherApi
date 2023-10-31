using ConsoleApp1.Classes;
using ConsoleApp1.Structs;

var productRepository = new ProductRepository();
productRepository.Add(new Product { Id = 1, Name = "Product1", Price = 10.0m });
productRepository.Add(new Product { Id = 2, Name = "Product2", Price = 20.0m });
var product = productRepository.FindById(1);
Console.WriteLine(product.Name);

var point = new Point(1, 2);
var clonedPoint = point.Clone();
Console.WriteLine($"Original Point: ({point.X}, {point.Y}), Cloned Point: ({clonedPoint.X}, {clonedPoint.Y})");

var complex1 = new ComplexNumber(1.0, 2.0);
var complex2 = new ComplexNumber(2.0, 3.0);
var complexComparer = new ComplexNumber();
int complexComparisonResult = complexComparer.Compare(complex1, complex2);
Console.WriteLine($"Comparison of Complex Numbers: {complexComparisonResult}");

var rational1 = new RationalNumber(1, 2);
var rational2 = new RationalNumber(3, 4);
var rationalComparer = new RationalNumber();
int rationalComparisonResult = rationalComparer.Compare(rational1, rational2);
Console.WriteLine($"Comparison of Rational Numbers: {rationalComparisonResult}");