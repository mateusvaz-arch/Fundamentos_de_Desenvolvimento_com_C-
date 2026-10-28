using System;

namespace ClassificadorPermanencia;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o total de minutos estacionado: ");
        int minutosEstacionado = int.Parse(Console.ReadLine()!);

        if (minutosEstacionado < 1)
        {
            Console.WriteLine("Erro: O tempo de permanência não pode ser negativo ou Zero");
        }
        /*
         * Limites de permanência:
         * - Até 60 min: rotativa curta (atividades rápidas, compras ou embarque).
         * - De 61 a 360 min (até 6h): rotativa padrão (estadias comuns para trabalho/lazer).
         * - Acima de 360 min: diária (permanência prolongada compensada como taxa diária).
         */
        else if (minutosEstacionado <= 60)
        {
            Console.WriteLine("Classificação: rotativa curta");
        }
        else if (minutosEstacionado <= 360)
        {
            Console.WriteLine("Classificação: rotativa padrão");
        }
        else
        {
            Console.WriteLine("Classificação: diária");
        }
    }
}
