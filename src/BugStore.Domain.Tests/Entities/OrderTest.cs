using BugStore.Domain.Entities;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BugStore.Domain.Tests.Entities;
using System;
using BugStore.Domain.Entities;
using Xunit;

    public class OrderTests
    {
        [Fact]
        public void Lines_Should_Default_To_Empty_List_Instead_Of_Null()
        {
            var order = new Order();

            // Comportamento desejado: nunca null para evitar NullReference.
            // O código atual usa "null"; este Assert deve falhar e apontar o bug.
            Assert.NotNull(order.Lines);
            Assert.Empty(order.Lines);
        }

        [Fact]
        public void Can_Link_Customer_To_Order()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Bob",
                Email = "bob@example.com",
                Phone = "555-0101",
                BirthDate = new DateTime(1985, 10, 10)
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                Customer = customer,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            Assert.Equal(customer.Id, order.CustomerId);
            Assert.Equal(customer, order.Customer);
        }
    }
