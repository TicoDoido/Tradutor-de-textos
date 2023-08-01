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
            // Abre uma caixa de diálogo para selecionar um arquivo .txt
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Lê o conteúdo do arquivo selecionado
                string texto = File.ReadAllText(filePath);

                // Exibe o conteúdo no RichTextBox richTextBox1
                richTextBox1.Text = texto;
            }
        }

        private async void buttonTranslate_Click(object sender, EventArgs e)
        {
            string originalText = richTextBox1.Text;

            if (string.IsNullOrEmpty(originalText))
            {
                MessageBox.Show("Nenhum texto para traduzir!");
                return;
            }

            string[] lines = originalText.Split('\n'); // Divide o texto em linhas

            // Limpa o conteúdo de richTextBox2 antes da tradução
            richTextBox2.Text = string.Empty;

            // Configuração da API do My Memory
            string apiUrl = "https://api.mymemory.translated.net/get";
            HttpClient httpClient = new HttpClient();

            foreach (string line in lines)
            {
                string encodedLine = Uri.EscapeDataString(line); // Codifica a linha para URL

                // Monta a URL da API com o texto a ser traduzido
                string requestUrl = $"{apiUrl}?q={encodedLine}&langpair=en|pt";

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        TranslationResponse translationResponse = JsonSerializer.Deserialize<TranslationResponse>(jsonResponse);

                        // Obtém o texto traduzido da resposta da API
                        string translatedText = translationResponse?.responseData?.translatedText;

                        // Adiciona o texto traduzido ao richTextBox2
                        if (!string.IsNullOrEmpty(translatedText))
                        {
                            richTextBox2.AppendText(translatedText + Environment.NewLine);
                        }
                        else
                        {
                            richTextBox2.AppendText("[Erro na tradução]" + Environment.NewLine);
                        }
                    }
                    else
                    {
                        richTextBox2.AppendText("[Erro na tradução]" + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    richTextBox2.AppendText("[Erro na tradução]" + Environment.NewLine);
                }
            }
        }

        // Definição da classe para desserializar a resposta da API do My Memory
        private class TranslationResponse
        {
            public ResponseData responseData { get; set; }
        }

        private class ResponseData
        {
            public string translatedText { get; set; }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Torna o RichTextBox richTextBox2 editável
            richTextBox2.ReadOnly = false;

            MessageBox.Show("Modo de edição ativado. Agora você pode editar o texto traduzido.");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputFilePath))
            {
                // Obtém o texto traduzido do RichTextBox richTextBox2
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
