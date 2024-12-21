using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class ReportsForm : Form
    {
        private List<Assistance> _assistances;
        private List<KnownProblem> _knownProblems;

        public ReportsForm(List<Assistance> assistances, List<KnownProblem> knownProblems)
        {
            InitializeComponent();
            _assistances = assistances ?? new List<Assistance>();
            _knownProblems = knownProblems ?? new List<KnownProblem>();
        }

        // Evento de clique para gerar um relatório
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica o tipo de relatório selecionado
                string reportType = cbReportType.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(reportType))
                {
                    MessageBox.Show("Por favor, selecione um tipo de relatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Caminho onde o relatório será guardado
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Relatorio_Helpdesk.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("=== Relatório do Sistema de Helpdesk ===");
                    writer.WriteLine($"Data: {DateTime.Now}");

                    // Gera o relatório com base no tipo selecionado
                    if (reportType == "Assistências Resolvidas")
                    {
                        writer.WriteLine("\n--- Assistências Resolvidas ---");
                        foreach (var assistance in _assistances.Where(a => a.Status == "Concluído"))
                        {
                            writer.WriteLine($"ID: {assistance.ID}, Descrição: {assistance.Description}, Técnico: {assistance.AssignedTechnician?.Name}");
                        }
                    }
                    else if (reportType == "Problemas Conhecidos")
                    {
                        writer.WriteLine("\n--- Problemas Conhecidos ---");
                        foreach (var problem in _knownProblems)
                        {
                            writer.WriteLine($"ID: {problem.ID}, Descrição: {problem.Description}, Solução: {problem.Solution}");
                        }
                    }

                    writer.WriteLine("\n=== Fim do Relatório ===");
                }

                MessageBox.Show("Relatório gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
