using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;

class Program3
{
    class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Escolha o formato de entrada (1 - JSON, 2 - XML): ");
        string escolha = Console.ReadLine();

        List<Faturamento> faturamentos = new List<Faturamento>();

        if (escolha == "1")
        {
            /* Lendo os dados em JSON. */
            Console.WriteLine("Lendo dados do arquivo JSON...");
            string jsonFilePath = "dados.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(jsonData);
        }
        else if (escolha == "2")
        {
            /* Lendo os dados em XML. */
            Console.WriteLine("Lendo dados do arquivo XML...");
            string xmlFilePath = "dados.xml";

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;           

            using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
            {
                Faturamento faturamentoAtual = null;

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "row")
                        {
                            faturamentoAtual = new Faturamento();
                        }
                        else if (reader.Name == "dia" && faturamentoAtual != null)
                        {
                            faturamentoAtual.Dia = reader.ReadElementContentAsInt();
                        }
                        else if (reader.Name == "valor" && faturamentoAtual != null)
                        {
                            faturamentoAtual.Valor = reader.ReadElementContentAsDouble();
                            /* Adicionando o faturamento á lista após ler o valor e Ignorando dias com faturamento 0. */
                            if (faturamentoAtual.Valor > 0)
                            {
                                faturamentos.Add(faturamentoAtual);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        /* Obtendo da lista somente os itens com valor maior que 0 garantindo  os dados com faturamento. */
        var faturamentosComValor = faturamentos.Where(f => f.Valor > 0).ToList();

        /* Obendo da lista com valores o menor e o maior faturamento. */
        double menorFaturamento = faturamentosComValor.Min(f => f.Valor);
        double maiorFaturamento = faturamentosComValor.Max(f => f.Valor);

        /* Calculando a média de faturamento. */
        double somaFaturamento = faturamentosComValor.Sum(f => f.Valor);
        double mediaFaturamento = somaFaturamento / faturamentosComValor.Count;

        /* Contando os dias com faturamento superior à média. */
        int diasAcimaDaMedia = faturamentosComValor.Count(f => f.Valor > mediaFaturamento);

        /* Exibindo os resultados solicitados. */
        Console.WriteLine($"Menor faturamento: {menorFaturamento:C}");
        Console.WriteLine($"Maior faturamento: {maiorFaturamento:C}");
        Console.WriteLine($"Número de dias com faturamento superior à média: {diasAcimaDaMedia}");
    }
}