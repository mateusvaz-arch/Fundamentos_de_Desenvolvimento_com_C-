using System;

namespace CalculadoraTarifa;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("           CALCULADORA DE TARIFA                  ");
        Console.WriteLine("==================================================");
        Console.WriteLine();

        int totalMinutos = 135;      
        double valorPorHora = 12.50;  
        const double tetoDiario = 50.00;

        Console.WriteLine($"Tempo total informado: {totalMinutos} minutos");
        Console.WriteLine($"Valor por hora:        R$ {valorPorHora:F2}");
        Console.WriteLine($"Teto diário fixo:      R$ {tetoDiario:F2}");
        Console.WriteLine("--------------------------------------------------");

        int horasCheias = totalMinutos / 60;
        int minutosRestantes = totalMinutos % 60;

        Console.WriteLine($"Tempo de permanência:  {horasCheias}h {minutosRestantes}min");

        // Cálculo do valor a cobrar:
        int horasCobradas = horasCheias;
        if (minutosRestantes > 0)
        {
            horasCobradas += 1;
        }

        double valorCalculado = horasCobradas * valorPorHora;

        Console.WriteLine($"Horas tarifadas:       {horasCobradas} hora(s)");
        Console.WriteLine($"Valor total a cobrar:  R$ {valorCalculado:F2}");
        Console.WriteLine("--------------------------------------------------");

        // Comparação com o teto diário fixo usando operadores  >, <, ==
        if (valorCalculado > tetoDiario)
        {
            Console.WriteLine($"Resultado: O valor calculado (R$ {valorCalculado:F2}) é MAIOR que o teto diário fixo (R$ {tetoDiario:F2}).");
        }
        else if (valorCalculado < tetoDiario)
        {
            Console.WriteLine($"Resultado: O valor calculado (R$ {valorCalculado:F2}) é MENOR que o teto diário fixo (R$ {tetoDiario:F2}).");
        }
        else
        {
            Console.WriteLine($"Resultado: O valor calculado (R$ {valorCalculado:F2}) é IGUAL ao teto diário fixo (R$ {tetoDiario:F2}).");
        }

        Console.WriteLine("==================================================");
    }
}
