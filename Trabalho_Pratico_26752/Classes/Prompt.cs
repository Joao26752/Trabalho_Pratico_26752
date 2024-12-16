using System;
using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        // Cria o formulário
        Form prompt = new Form()
        {
            Width = 400,
            Height = 200,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };

        // Componentes do formulário
        Label lblText = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
        TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 340 };
        Button btnOk = new Button() { Text = "OK", Left = 200, Width = 80, Top = 100 };
        Button btnCancel = new Button() { Text = "Cancelar", Left = 290, Width = 80, Top = 100 };

        // Botões
        btnOk.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
        btnCancel.Click += (sender, e) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };

        // Adiciona componentes ao formulário
        prompt.Controls.Add(lblText);
        prompt.Controls.Add(txtInput);
        prompt.Controls.Add(btnOk);
        prompt.Controls.Add(btnCancel);
        prompt.AcceptButton = btnOk;
        prompt.CancelButton = btnCancel;

        // Retorna o texto digitado se OK for pressionado
        return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : string.Empty;
    }
}
