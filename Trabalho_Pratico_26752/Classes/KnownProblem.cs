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
        public List<Product> AffectedProducts { get; set; } = new List<Product>();

        public bool IsProductAffected(Product product)
        {
            return AffectedProducts.Contains(product);
        }

        public void AddProduct(Product product)
        {
            AffectedProducts.Add(product);
        }
        public void RemoveProduct(Product product) {  
            AffectedProducts.Remove(product);    
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ProblemID}");
            Console.WriteLine($"Descrição: {Description}");
            Console.WriteLine($"Solução: {Solution}");
            Console.WriteLine($"Produtos afetados: {string.Join(", ", AffectedProducts)}");
        }

    }
}
