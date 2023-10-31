using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Classes;

using System;
using System.Collections.Generic;
using System.Linq;

public class ProductRepository : IRepository<Product>
{
    private List<Product> products = new List<Product>();
    
    public void Add(Product item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        
        products.Add(item);
    }

    public void Delete(Product item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        products.Remove(item);
    }

    public Product FindById(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return products;
    }
}

public class CustomerRepository : IRepository<Customer>
{
    private List<Customer> customers = new List<Customer>();
    
    public void Add(Customer item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        
        customers.Add(item);
    }

    public void Delete(Customer item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        customers.Remove(item);
    }

    public Customer FindById(int id)
    {
        return customers.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return customers;
    }
}
