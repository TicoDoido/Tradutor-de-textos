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
            string textoParaTraduzir = richTextBox1.Text;

            // Chama a função TraduzirTextoPorLinhas para traduzir o texto
            string traducao = await TraduzirTextoPorLinhas(textoParaTraduzir, "en", "pt");

            // Exibe o texto traduzido no RichTextBox richTextBox2
            richTextBox2.Text = traducao;

            if (openFileDialog.FileName != null)
            {
                outputFilePath = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "_traduzido.txt";

                // Salva o texto traduzido em um arquivo com sufixo "_traduzido.txt"
                File.WriteAllText(outputFilePath, traducao);
            }
        }

        private async Task<string> TraduzirTextoPorLinhas(string texto, string idiomaOrigem, string idiomaDestino)
        {
            // Divide o texto em linhas
            string[] linhas = texto.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Lista para armazenar as traduções das linhas
            List<string> traducoes = new List<string>();

            // Itera sobre cada linha e realiza a tradução individualmente
            foreach (string linha in linhas)
            {
                // Chama a função TraduzirComMyMemory para traduzir a linha atual
                string traducaoLinha = await TraduzirComMyMemory(linha, idiomaOrigem, idiomaDestino);

                // Adiciona a tradução à lista de traduções
                traducoes.Add(traducaoLinha);
            }

            // Combina as traduções das linhas em uma única string usando Environment.NewLine como separador
            return string.Join(Environment.NewLine, traducoes);
        }

        private async Task<string> TraduzirComMyMemory(string texto, string idiomaOrigem, string idiomaDestino)
        {
            string url = "https://api.mymemory.translated.net/get";

            // Define os parâmetros da chamada da API
            var requestData = new Dictionary<string, string>
            {
                { "q", texto },
                { "langpair", $"{idiomaOrigem}|{idiomaDestino}" }
            };

            using (HttpClient client = new HttpClient())
            {
                // Realiza uma solicitação POST para a API do MyMemory
                var content = new FormUrlEncodedContent(requestData);
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    // Lê a resposta da API
                    string responseJson = await response.Content.ReadAsStringAsync();

                    // Analisa o JSON de resposta
                    using (JsonDocument document = JsonDocument.Parse(responseJson))
                    {
                        JsonElement root = document.RootElement;

                        // Verifica se a chamada da API foi bem-sucedida
                        if (root.TryGetProperty("responseStatus", out JsonElement responseStatus) && responseStatus.ToString() == "200")
                        {
                            // Obtém a tradução do texto do JSON de resposta
                            if (root.TryGetProperty("responseData", out JsonElement responseData) && responseData.TryGetProperty("translatedText", out JsonElement translatedText))
                            {
                                string traducao = translatedText.GetString();
                                return traducao;
                            }
                        }
                        else
                        {
                            // Se a chamada da API não foi bem-sucedida, verifica se há detalhes de erro
                            if (root.TryGetProperty("responseDetails", out JsonElement responseDetails))
                            {
                                string erro = responseDetails.GetString();
                                return $"Erro na tradução: {erro}";
                            }
                        }
                    }
                }

                // Trata o erro caso a chamada não seja bem-sucedida
                return $"Erro na tradução: {response.ReasonPhrase}";
            }
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
