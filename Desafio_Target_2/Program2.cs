using System;

class Program2
{
    static void Main()
    {
        Console.WriteLine("Entre com um número natural: ");
        try
        {
            int numero = int.Parse(Console.ReadLine());

            if(numero < 0)
            {
                Console.WriteLine($"A sequência de Fibonacci é crescente, infinita, e formada apenas por números naturais. Não há negativos, frações ou irracionais..");
            }
            else if (PertenceASequenciaFibonacci(numero))
            {
                Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
            }
            else
            {
                Console.WriteLine($"{numero} não pertence à sequência de Fibonacci.");
            }
        }
        catch
        {
            Console.WriteLine("Entrada inválida, execute o programa novamente e informe um número natural.");
        }
    }

    static bool PertenceASequenciaFibonacci(int numero)
    {
        /* Os dois primeiros números da sequência de Fibonacci. */
        int a = 0, b = 1;

        /* Se o número informado for igual a 0 ou 1 retorna o valor pois é uma sequência de Fibonacci. */
        if (numero == 0 || numero == 1)
        {
            return true;
        }

        /* Comando de repetição que irá pecorrer as sequências até que seja igual o maior que o número informado. */
        while (b < numero)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }

        /* Retorno que indica se é uma sequência de Fibonacci. */
        return b == numero;
    }
}