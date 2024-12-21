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

                // Caminho onde o relatório será salvo
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Relatorio_Helpdesk.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("=== Relatório do Sistema de Helpdesk ===");
                    writer.WriteLine($"Data: {DateTime.Now}");
                    writer.WriteLine($"Tipo de Relatório: {reportType}\n");

                    if (reportType == "Assistências Resolvidas")
                    {
                        var resolved = _assistances.Where(a => a.Status == AssistanceRequestStatus.Closed).ToList();
                        writer.WriteLine($"Total de Assistências Resolvidas: {resolved.Count}\n");
                        foreach (var assistance in resolved)
                        {
                            writer.WriteLine($"ID: {assistance.ID}, Descrição: {assistance.Description}, Avaliação: {assistance.Rating}");
                        }
                    }
                    else if (reportType == "Problemas Conhecidos")
                    {
                        writer.WriteLine($"Total de Problemas Conhecidos: {_knownProblems.Count}\n");
                        foreach (var problem in _knownProblems)
                        {
                            writer.WriteLine($"ID: {problem.ProblemID}, Descrição: {problem.Description}, Solução: {problem.Solution}");
                        }
                    }

                    writer.WriteLine("\n=== Fim do Relatório ===");
                }

                MessageBox.Show($"Relatório gerado com sucesso!\nLocal: {filePath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
