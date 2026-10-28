using System;

namespace ClassificadorPermanencia;

class Program
{
    static void Main(string[] args)
    {
        int totalCurta = 0;
        int totalPadrao = 0;
        int totalDiaria = 0;

        while (true)
        {
            Console.Write("Digite o total de minutos estacionado (-1: encerrar): ");
            int minutosEstacionado = int.Parse(Console.ReadLine()!);

            if (minutosEstacionado == -1)
            {
                break;
            }

            if (minutosEstacionado < 1)
            {
                Console.WriteLine("Erro: O tempo de permanência não pode ser negativoou Zero");
                continue;
            }

            /*
             * Limites de permanência:
             * - Até 60 min: rotativa curta.
             * - De 61 a 360 min: rotativa padrão.
             * - Acima de 360 min: diária.
             */
            if (minutosEstacionado <= 60)
            {
                totalCurta++;
                Console.WriteLine("Classificação: rotativa curta");
            }
            else if (minutosEstacionado <= 360)
            {
                totalPadrao++;
                Console.WriteLine("Classificação: rotativa padrão");
            }
            else
            {
                totalDiaria++;
                Console.WriteLine("Classificação: diária");
            }
        }

        Console.WriteLine("\n--- Total de Veículos por Categoria ---");
        Console.WriteLine($"Rotativa curta:  {totalCurta}");
        Console.WriteLine($"Rotativa padrão: {totalPadrao}");
        Console.WriteLine($"Diária:          {totalDiaria}");
    }
}
