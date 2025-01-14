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
                    new Customer { Name = "Alice Johnson", Email = "alice@example.com", Address = "123 Main St", ZipCode = "12345", Country = "USA", City = "New York" },
                    new Customer { Name = "Bob Smith", Email = "bob@example.com", Address = "456 Elm St", ZipCode = "67890", Country = "USA", City = "Los Angeles" },
                    new Customer { Name = "Charlie Brown", Email = "charlie@example.com", Address = "789 Oak St", ZipCode = "11223", Country = "USA", City = "Chicago" },
                    new Customer { Name = "Matilda Johansson", Email = "matilda@example.com", Address = "Renvägen 18", ZipCode = "66630", Country = "Sweden", City = "Stockholm" }
                };

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                // Hämta kunder från databasen
                var alice = context.Customers.First(c => c.Name == "Alice Johnson");
                var bob = context.Customers.First(c => c.Name == "Bob Smith");
                var charlie = context.Customers.First(c => c.Name == "Charlie Brown");
                var matilda = context.Customers.First(c => c.Name == "Matilda Johansson");

                // Skapa beställningar
                var orders = new List<Order>
                {
                    new Order
                    {
                        Customer = alice,
                        Products = new List<Product>
                        {
                            new Product { Name = "Laptop", Price = 999.99m, Quantity = 1 },
                            new Product { Name = "Mouse", Price = 25.00m, Quantity = 5 }
                        }
                    },
                    new Order
                    {
                        Customer = bob,
                        Products = new List<Product>
                        {
                            new Product { Name = "Smartphone", Price = 799.99m, Quantity = 2 },
                            new Product { Name = "Headphones", Price = 199.99m, Quantity = 30 },
                            new Product { Name = "Tablet", Price = 499.99m, Quantity = 5 }
                        }
                    },
                    new Order
                    {
                        Customer = charlie,
                        Products = new List<Product>
                        {
                            new Product { Name = "Tablet", Price = 499.99m, Quantity = 5 },
                            new Product { Name = "Keyboard", Price = 49.99m, Quantity = 40 }
                        }
                    },
                    new Order
                    {
                        Customer = alice,
                        Products = new List<Product>
                        {
                            new Product { Name = "Mouse", Price = 25.00m, Quantity = 5 },
                            new Product { Name = "Keyboard", Price = 49.99m, Quantity = 40 }
                        }
                    },
                    new Order
                    {
                        Customer = bob,
                        Products = new List<Product>
                        {
                            new Product { Name = "Laptop", Price = 999.99m, Quantity = 1 },
                            new Product { Name = "Tablet", Price = 499.99m, Quantity = 5 }
                        }
                    },
                    new Order
                    {
                        Customer = charlie,
                        Products = new List<Product>
                        {
                            new Product { Name = "Smartphone", Price = 799.99m, Quantity = 2 },
                            new Product { Name = "Mouse", Price = 25.00m, Quantity = 5 }
                        }
                    },
                    new Order
                    {
                        Customer = alice,
                        Products = new List<Product>
                        {
                            new Product { Name = "Headphones", Price = 199.99m, Quantity = 30 },
                            new Product { Name = "Tablet", Price = 499.99m, Quantity = 5 }
                        }
                    },
                    new Order
                    {
                        Customer = matilda,
                        Products = new List<Product>
                        {
                            new Product { Name = "Laptop", Price = 999.99m, Quantity = 1 },
                            new Product { Name = "Keyboard", Price = 49.99m, Quantity = 40 }
                        }
                    }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}