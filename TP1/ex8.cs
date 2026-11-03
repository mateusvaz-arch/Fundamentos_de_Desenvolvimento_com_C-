// 1 Modularização em métodos estáticos reutilizáveis (ConverterDuracao, CalcularTarifa, ClassificarPermanencia) evitando duplicação.
// 2 Controle de fluxo contínuo via laço do-while e switch para direcionamento limpo das opções.
// 3 Validação defensiva com TryParse e guard clauses garantindo estabilidade contra entradas incorretas.
// 4 Centralização de estado para totalizar categorias de permanência acumuladas durante o turno.
using System;
using System.Globalization;

namespace MenuEstacionamento;

class Program
{
    // Constante de teto diário fixo 
    private const double TetoDiario = 50.00;

    // Contadores de veículos por categoria 
    private static int totalCurta = 0;
    private static int totalPadrao = 0;
    private static int totalDiaria = 0;

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
            Console.WriteLine("4 - Relatório de veículos por categoria");
            Console.WriteLine("5 - Sobre o sistema");
            Console.WriteLine("6 - Sair");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Escolha uma opção (1 a 6): ");
            string? entrada = Console.ReadLine();
            if (entrada == null)
            {
                break;
            }

            opcao = entrada.Trim().Trim('\uFEFF');
            if (string.IsNullOrEmpty(opcao))
            {
                continue;
            }

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
                    ExibirRelatorioCategorias();
                    break;

                case "5":
                    ExibirSobre();
                    break;

                case "6":
                    Console.WriteLine("Encerrando o programa. Bom trabalho!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Por favor, escolha um número de 1 a 6.");
                    break;
            }

            if (opcao != "6")
            {
                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }

        } while (opcao != "6");
    }

    #region Operações do Menu

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

        // Reutiliza métodos de cálculo e conversão sem duplicar código
        var (horasCobradas, valorTotal) = CalcularTarifa(minutos, valorHora);
        var (horas, minRestantes) = ConverterDuracao(minutos);

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Tempo de permanência: {horas}h {minRestantes}min");
        Console.WriteLine($"Horas tarifadas:      {horasCobradas} hora(s)");
        Console.WriteLine($"Valor total a cobrar: R$ {valorTotal:F2}");

        // Comparação com o teto diário fixo 
        if (valorTotal > TetoDiario)
        {
            Console.WriteLine($"Resultado: O valor calculado (R$ {valorTotal:F2}) é MAIOR que o teto diário fixo (R$ {TetoDiario:F2}).");
        }
        else if (valorTotal < TetoDiario)
        {
            Console.WriteLine($"Resultado: O valor calculado (R$ {valorTotal:F2}) é MENOR que o teto diário fixo (R$ {TetoDiario:F2}).");
        }
        else
        {
            Console.WriteLine($"Resultado: O valor calculado (R$ {valorTotal:F2}) é IGUAL ao teto diário fixo (R$ {TetoDiario:F2}).");
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
        Console.WriteLine($"Tempo de permanência: {horas}h {minRestantes}min");
    }

    static void ExecutarClassificacaoPermanencia()
    {
        Console.WriteLine("--- [3] Classificar Permanência ---");
        Console.Write("Digite o total de minutos estacionado: ");
        if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos < 1)
        {
            Console.WriteLine("Erro: O tempo de permanência não pode ser negativo ou zero.");
            return;
        }

        string classificacao = ClassificarPermanencia(minutos);
        Console.WriteLine($"Classificação: {classificacao}");

        // Atualiza os contadores acumulados
        switch (classificacao)
        {
            case "rotativa curta":
                totalCurta++;
                break;
            case "rotativa padrão":
                totalPadrao++;
                break;
            case "diária":
                totalDiaria++;
                break;
        }
    }

    static void ExibirRelatorioCategorias()
    {
        Console.WriteLine("--- [4] Total de Veículos por Categoria ---");
        Console.WriteLine($"Rotativa curta:  {totalCurta}");
        Console.WriteLine($"Rotativa padrão: {totalPadrao}");
        Console.WriteLine($"Diária:          {totalDiaria}");
        Console.WriteLine($"Total geral:     {totalCurta + totalPadrao + totalDiaria}");
    }

    static void ExibirSobre()
    {
        Console.WriteLine("--- [5] Sobre o Sistema ---");
        Console.WriteLine($"Versão do .NET em uso: {Environment.Version}");
        Console.WriteLine("Este programa funciona sem alterações em outro sistema operacional porque o C# compila para uma linguagem intermediária (IL/CIL) executada pelo ambiente multiplataforma do .NET (CLR).");
    }

    #endregion

    #region Lógicas Reutilizáveis 

    /// Converte o total de minutos em horas inteiras e minutos restantes.
    public static (int horas, int minutos) ConverterDuracao(int totalMinutos)
    {
        return (totalMinutos / 60, totalMinutos % 60);
    }

    /// Calcula as horas tarifadas e o valor total, reutilizando ConverterDuracao.
    public static (int horasCobradas, double valorTotal) CalcularTarifa(int totalMinutos, double valorHora)
    {
        var (horas, minutos) = ConverterDuracao(totalMinutos);
        int horasCobradas = horas + (minutos > 0 ? 1 : 0);
        double valorTotal = horasCobradas * valorHora;
        return (horasCobradas, valorTotal);
    }

    /// Classifica a permanência conforme os limites definidos:
    /// - Até 60 min: rotativa curta
    /// - De 61 a 360 min: rotativa padrão
    /// - Acima de 360 min: diária
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
