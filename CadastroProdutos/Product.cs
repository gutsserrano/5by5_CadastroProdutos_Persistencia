using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutos
{
    internal class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(int id, string descrption, double price, int quantity)
        {
            Id = id;
            this.Description = descrption;
            this.Price = price;
            this.Quantity = quantity;
        }

        public override string? ToString()
        {
            return $"{Id};{Description};{Price};{Quantity}";
        }
    }
}
