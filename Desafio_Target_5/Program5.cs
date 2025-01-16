using System;

class Program5
{
    static void Main()
    {
        /* Obtendo o texto digitado pelo usuário. */
        Console.Write("Digite a palavra  a ser invertida: ");
        string input = Console.ReadLine();

        /* Invertendo o texto pela função criada. */
        string reversedString = InverterString(input);

        /* Exibindo texto digitado de forma invertida. */
        Console.WriteLine("Palavra invertida: " + reversedString);
    }

    /* Função responsável por inverter a palavra digitada. */
    static string InverterString(string str)
    {
        /* Array de caracteres responsavel por armazenar a palavra invertida. */
        char[] invertedArray = new char[str.Length];

        /* Pecorrendo a palavra digitada de trás para frente ao tempo que inverte os caracteres. */
        int j = 0;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            invertedArray[j] = str[i];
            j++;
        }

        /* Devolvendo a palavra invertida em string para o método que chamou a função. */
        return new string(invertedArray);
    }
}