using System;
using System.Globalization;

namespace MenuEstacionamento;

class Program
{
    // Constante de teto diário fixo conforme exercício anterior
    private const double TetoDiario = 50.00;

    static void Main(string[] args)
    {
        string opcao;

        do
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("             SISTEMA DE ESTACIONAMENTO            ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1 - Calcular tarifa");
            Console.WriteLine("2 - Converter duração em horas e minutos");
            Console.WriteLine("3 - Classificar permanência");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Escolha uma opção (1 a 4): ");
            opcao = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    ExecutarCalculoTarifa();
                    break;

                case "2":
                    ExecutarConversaoDuracao();
                    break;

                case "3":
                    ExecutarClassificacaoPermanencia();
                    break;

                case "4":
                    Console.WriteLine("Encerrando o programa. Bom trabalho!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Por favor, escolha um número de 1 a 4.");
                    break;
            }

            if (opcao != "4")
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }

        } while (opcao != "4");
    }

    static void ExecutarCalculoTarifa()
    {
        Console.WriteLine("--- [1] Calcular Tarifa ---");
        Console.Write("Digite o tempo total em minutos: ");
        if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos < 0)
        {
            Console.WriteLine("Erro: Valor inválido. O tempo deve ser um número inteiro não negativo.");
            return;
        }

        Console.Write("Digite o valor por hora (R$) [ou deixe vazio para R$ 12.50]: ");
        string entradaValorHora = Console.ReadLine()?.Trim().Replace(',', '.') ?? "";
        double valorHora = 12.50;

        if (!string.IsNullOrEmpty(entradaValorHora))
        {
            if (!double.TryParse(entradaValorHora, NumberStyles.Any, CultureInfo.InvariantCulture, out valorHora) || valorHora < 0)
            {
                Console.WriteLine("Erro: Valor da hora inválido.");
                return;
            }
        }

        // Reutiliza o método de cálculo de tarifa 
        var (horasCobradas, valorTotal) = CalcularTarifa(minutos, valorHora);
        var (horas, minRestantes) = ConverterDuracao(minutos);

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Tempo de permanência: {horas}h {minRestantes}min");
        Console.WriteLine($"Horas tarifadas:      {horasCobradas} hora(s)");
        Console.WriteLine($"Valor total a cobrar: R$ {valorTotal:F2}");

        // Comparação com o teto diário fix
        if (valorTotal > TetoDiario)
        {
            Console.WriteLine($"Atenção: O valor calculado (R$ {valorTotal:F2}) ultrapassou o teto diário de R$ {TetoDiario:F2}.");
        }
    }

    static void ExecutarConversaoDuracao()
    {
        Console.WriteLine("--- [2] Converter Duração em Horas e Minutos ---");
        Console.Write("Digite o total de minutos: ");
        if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos < 0)
        {
            Console.WriteLine("Erro: Valor inválido. O tempo deve ser um número inteiro não negativo.");
            return;
        }

        var (horas, minRestantes) = ConverterDuracao(minutos);
        Console.WriteLine($"Tempo convertido: {horas} hora(s) e {minRestantes} minuto(s) ({horas}h {minRestantes}min)");
    }

    static void ExecutarClassificacaoPermanencia()
    {
        Console.WriteLine("--- [3] Classificar Permanência ---");
        Console.Write("Digite o total de minutos estacionado: ");
        if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos < 1)
        {
            Console.WriteLine("Erro: O tempo de permanência deve ser um número inteiro maior que zero.");
            return;
        }

        string classificacao = ClassificarPermanencia(minutos);
        Console.WriteLine($"Classificação da permanência: {classificacao}");
    }

    #endregion

    #region Lógicas Reutilizáveis (Sem duplicação de regras)

    /// Converte um total de minutos em horas inteiras e minutos restantes
    public static (int horas, int minutos) ConverterDuracao(int totalMinutos)
    {
        return (totalMinutos / 60, totalMinutos % 60);
    }

    /// Reutiliza ConverterDuracao para evitar duplicar a lógica de divisão
    public static (int horasCobradas, double valorTotal) CalcularTarifa(int totalMinutos, double valorHora)
    {
        var (horas, minutos) = ConverterDuracao(totalMinutos);
        int horasCobradas = horas + (minutos > 0 ? 1 : 0);
        double valorTotal = horasCobradas * valorHora;
        return (horasCobradas, valorTotal);
    }

    /// Classifica a permanência do veículo conforme as regras de negócio:
    public static string ClassificarPermanencia(int totalMinutos)
    {
        if (totalMinutos <= 0)
        {
            return "inválida";
        }
        if (totalMinutos <= 60)
        {
            return "rotativa curta";
        }
        if (totalMinutos <= 360)
        {
            return "rotativa padrão";
        }
        return "diária";
    }

    #endregion
}
