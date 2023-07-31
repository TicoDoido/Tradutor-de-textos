using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private string outputFilePath;

        public Form1()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt";
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            // Abre uma caixa de di�logo para selecionar um arquivo .txt
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // L� o conte�do do arquivo selecionado
                string texto = File.ReadAllText(filePath);

                // Exibe o conte�do no RichTextBox richTextBox1
                richTextBox1.Text = texto;
            }
        }

        private async void buttonTranslate_Click(object sender, EventArgs e)
        {
            string textoParaTraduzir = richTextBox1.Text;

            // Divide o texto em linhas separadas
            string[] linhas = textoParaTraduzir.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string linha in linhas)
            {
                // Faz a chamada � API do MyMemory para traduzir a linha
                string linhaTraduzida = await TraduzirLinha(linha);

                // Exibe a linha traduzida no RichTextBox2
                richTextBox2.AppendText(Environment.NewLine + linhaTraduzida);
            }
        }

        private async Task<string> TraduzirLinha(string linha)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.mymemory.translated.net/get";

                // Crie um objeto que represente o conte�do da requisi��o
                var conteudo = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("q", linha),
                    new KeyValuePair<string, string>("langpair", "pt|en")
                });

                HttpResponseMessage response = await client.PostAsync(url, conteudo);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar o JSON usando classes personalizadas
                var result = JsonSerializer.Deserialize<ApiResponse>(responseBody);
                if (result?.responseData?.translatedText != null)
                {
                    return result.responseData.translatedText;
                }
                else
                {
                    throw new Exception("N�o foi poss�vel obter a tradu��o.");
                }
            }
        }

        // Classe auxiliar para desserializar a resposta JSON da API
        private class ApiResponse
        {
            public ResponseData responseData { get; set; }
        }

        private class ResponseData
        {
            public string translatedText { get; set; }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Torna o RichTextBox richTextBox2 edit�vel
            richTextBox2.ReadOnly = false;

            MessageBox.Show("Modo de edi��o ativado. Agora voc� pode editar o texto traduzido.");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputFilePath))
            {
                // Obt�m o texto traduzido do RichTextBox richTextBox2
                string novoTextoTraduzido = richTextBox2.Text;

                // Salva o texto traduzido em um arquivo
                File.WriteAllText(outputFilePath, novoTextoTraduzido);

                // Torna o RichTextBox richTextBox2 somente leitura novamente
                richTextBox2.ReadOnly = true;

                MessageBox.Show("Texto traduzido atualizado e salvo com sucesso!");
            }
        }
    }
}
