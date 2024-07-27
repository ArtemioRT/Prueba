using System;
using System.Collections.Generic;

class ProgramaClase
{
    private static readonly Dictionary<char, string> Morse = new Dictionary<char, string>()
    {
        {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"}, {'5', "....."},
        {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."}, 
        {'G', "--."},{'H', "...."}, {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."}, 
        {'M', "--"}, {'N', "-."},{'O', "---"}, {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, 
        {'S', "..."}, {'T', "-"}, {'U', "..-"},{'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, 
        {'Y', "-.--"}, {'Z', "--.."}
    };

    private static readonly Dictionary<string, char> Texto;

    static ProgramaClase()
    {
        Texto = new Dictionary<string, char>();
        foreach (var n in Morse)
        {
            Texto[n.Value] = n.Key;
        }
    }

    static string TextoAMorse(string input)
    {
        List<string> CodigoMorse = new List<string>();

        foreach (char c in input)
        {
            if (Morse.ContainsKey(c))
            {
                CodigoMorse.Add(Morse[c]);
            }
        }

        return string.Join(" ", CodigoMorse);
    }

    static string MorseATexto(string input)
    {
        List<string> Palabras = new List<string>();
        string[] MorsePalabras = input.Split(new string[] { "  " }, StringSplitOptions.None);

        foreach (string n in MorsePalabras)
        {
            List<char> Palabra = new List<char>();
            string[] MorseLetras = n.Split(' ');

            foreach (string letra in MorseLetras)
            {
                if (Texto.ContainsKey(letra))
                {
                    Palabra.Add(Texto[letra]);
                }
            }

            Palabras.Add(new string(Palabra.ToArray()));
        }

        return string.Join(" ", Palabras);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Texto a traducir:\n");
        string input = Console.ReadLine().Trim();

        if (input.Contains('.') || input.Contains('-'))
        {
            Console.WriteLine("Traduciendo del código morse a texto:");
            Console.WriteLine(MorseATexto(input));
        }
        else
        {
            Console.WriteLine("Traduciendo de texto a código morse:");
            Console.WriteLine(TextoAMorse(input.ToUpper()));
        }
    }
}
