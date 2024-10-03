using System.Threading.Channels;
using System.Globalization;
using System.Collections;

namespace ConversorDeMoedas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool encerrar = false;

            Dictionary<int, string> moedas = new Dictionary<int, string>();

            moedas.Add(1, "Dólar ($)");
            moedas.Add(2, "Euro (€)");
            moedas.Add(3, "Iene (¥)");
            moedas.Add(4, "Libra Esterlina (£)");

            Console.WriteLine("Este é um conversor de moedas.");

            do
            {
                Console.WriteLine(Environment.NewLine + "Insira qual valor em Real (R$) deseja converter: ");

                double valorReal = double.Parse(Console.ReadLine());

                Console.WriteLine(Environment.NewLine + "Selecione em qual moeda você deseja converter: ");

                foreach (var moeda in moedas)
                {
                    Console.WriteLine($"[{moeda.Key}] - [{moeda.Value}] \n");
                }

                int moedaConversao = int.Parse(Console.ReadLine());

                double valorConvertido = ConverterMoeda(valorReal, moedaConversao);

                Console.WriteLine(Environment.NewLine + "O valor convertido é R$" + valorConvertido.ToString("F2", CultureInfo.InvariantCulture));

                Console.WriteLine(Environment.NewLine + "Deseja fazer outra conversão? Sim - [s] Não - [n]" + Environment.NewLine);

                string prosseguir = Console.ReadLine();

                while (prosseguir != "S" && prosseguir != "N" && prosseguir != "s" && prosseguir != "n")
                {
                    if (prosseguir.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        encerrar = true;
                        break;
                    }
                    else if ((prosseguir.Equals("s", StringComparison.OrdinalIgnoreCase)))
                    {
                        encerrar = false;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida.");
                        prosseguir = Console.ReadLine();
                    }
                } 
            }
            while (encerrar == false);
        }

        #region Função
        public static double ConverterMoeda(double valorReal, int moedaConversao)
        {
            double realConvertido = 0;

            switch (moedaConversao)
            {
                case 1:
                    realConvertido = valorReal * 4.50;
                    break;
                case 2:
                    realConvertido = valorReal * 6.200;
                    break;
                case 3:
                    realConvertido = valorReal * 0.052;
                    break;
                case 4:
                    realConvertido = valorReal * 6.95;
                    break;
                default:
                    Console.WriteLine("Seleção inválida. Escolha uma das moedas informadas.");
                    return 0;
            }

            return realConvertido;
        }
        #endregion
    }
}
