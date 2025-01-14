using OrderManagement.Models;

namespace OrderManagement.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Kontrollera om data redan finns
            if (!context.Customers.Any())
            {
                // Skapa kunder
                var customers = new List<Customer>
                {
                    new Customer { Name = "Alice Johnson", Email = "alice@example.com", Address = "123 Main St", ZipCode = "12345", Country = "USA" },
                    new Customer { Name = "Bob Smith", Email = "bob@example.com", Address = "456 Elm St", ZipCode = "67890", Country = "USA" },
                    new Customer { Name = "Charlie Brown", Email = "charlie@example.com", Address = "789 Oak St", ZipCode = "11223", Country = "USA" }
                };

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                // Skapa produkter
                var products = new List<Product>
                {
                    new Product { Name = "Laptop", Price = 999.99m, Quantity = 10 },
                    new Product { Name = "Mouse", Price = 25.00m, Quantity = 50 },
                    new Product { Name = "Smartphone", Price = 799.99m, Quantity = 20 },
                    new Product { Name = "Headphones", Price = 199.99m, Quantity = 30 },
                    new Product { Name = "Tablet", Price = 499.99m, Quantity = 15 },
                    new Product { Name = "Keyboard", Price = 49.99m, Quantity = 40 }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                // Hämta kunder från databasen
                var alice = context.Customers.First(c => c.Name == "Alice Johnson");
                var bob = context.Customers.First(c => c.Name == "Bob Smith");
                var charlie = context.Customers.First(c => c.Name == "Charlie Brown");

                // Hämta produkter från databasen
                var laptop = context.Products.First(p => p.Name == "Laptop");
                var mouse = context.Products.First(p => p.Name == "Mouse");
                var smartphone = context.Products.First(p => p.Name == "Smartphone");
                var headphones = context.Products.First(p => p.Name == "Headphones");
                var tablet = context.Products.First(p => p.Name == "Tablet");
                var keyboard = context.Products.First(p => p.Name == "Keyboard");

                // Skapa beställningar
                var orders = new List<Order>
                {
                    new Order
                    {
                        Customer = alice,
                        Products = new List<Product>
                        {
                            laptop,
                            mouse
                        }
                    },
                    new Order
                    {
                        Customer = bob,
                        Products = new List<Product>
                        {
                            smartphone,
                            headphones
                        }
                    },
                    new Order
                    {
                        Customer = charlie,
                        Products = new List<Product>
                        {
                            tablet,
                            keyboard
                        }
                    }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}