using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Pratico_26752.Classes;


namespace HelpdeskSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances
            Customer customer = new Customer { CustomerID = 1, Name = "John Doe", Email = "john@example.com" };
            Operator operator1 = new Operator { OperatorID = 1, Name = "Jane Smith", Shift = "Morning" };
            Product product = new Product { ProductID = 1, Name = "Smartphone X", Description = "A high-end smartphone." };
            KnownProblem knownProblem = new KnownProblem { ProblemID = 1, Description = "Battery overheating", Solution = "Replace the battery" };
            knownProblem.AffectedProducts.Add(product);

            // Create an assistance request
            Assistance assistance = new Assistance
            {
                AssistanceID = 1,
                RequestDate = DateTime.Parse("2024-12-13T19:13:00Z"),
                Type = AssistanceType.TechnicalSupport,
                Status = AssistanceStatus.Open,
                Customer = customer,
                Product = product,
                ProblemDescription = "The phone overheats quickly."
            };

            // Link known problem
            assistance.LinkKnownProblem(knownProblem);

            // Customer requests assistance
            customer.RequestAssistance(assistance);

            // Operator assigns and resolves the assistance
            operator1.AssignAssistance(assistance);
            operator1.ResolveAssistance(assistance, true, 9);

            Console.WriteLine($"Assistance Status: {assistance.Status}");
            Console.WriteLine($"Problem Resolved: {assistance.ProblemResolved}");
            Console.WriteLine($"Customer Rating: {assistance.Rating}");
        }
    }
}
