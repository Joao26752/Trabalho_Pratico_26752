using System.Collections.Generic;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;
using System;

namespace Trabalho_Pratico_26752.Classes
{
    public class KnownProblem
    {
        public int ProblemID { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        private readonly List<Product> _affectedProducts = new List<Product>();

        public IReadOnlyList<Product> AffectedProducts => _affectedProducts.AsReadOnly();

        public bool IsProductAffected(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            return _affectedProducts.Contains(product);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _affectedProducts.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _affectedProducts.Remove(product);
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ProblemID}");
            Console.WriteLine($"Descrição: {Description}");
            Console.WriteLine($"Solução: {Solution}");
            Console.WriteLine($"Produtos afetados: {string.Join(", ", _affectedProducts)}");
        }

    }
}
