// See https://aka.ms/new-console-template for more information

namespace ErikMaia;

class Calculator
{
    private readonly List<string> expressionPartes;
    public Calculator(string expression)
    {
        expressionPartes = expression.Split(' ').ToList();
        Console.WriteLine($"Inicio: {PrintPart()}");
        Div();
        Console.WriteLine($"Div: {PrintPart()}");
        Mult();
        Console.WriteLine($"Mult: {PrintPart()}");
        Sub();
        Console.WriteLine($"Sub: {PrintPart()}");
        Sum();
        Console.WriteLine($"Sum: {PrintPart()}");
        Console.WriteLine($"Resultado: {expressionPartes[0]}");
    }

    private string PrintPart()
    {
        var strList = "";
        foreach (string expression in expressionPartes)
        {
            strList += $"[{expression}]";
        }
        return strList;
    }

    private void Div()
    {
        for (int i = 0; i < expressionPartes.Count; i++)
        {
            if (expressionPartes[i] == "/")
            {
                double div = double.Parse(expressionPartes[i-1])/double.Parse(expressionPartes[i+1]);
                expressionPartes[i-1] = div.ToString();
                expressionPartes.RemoveAt(i+1);
                expressionPartes.RemoveAt(i);
                i--;
            }
        }
    }

    private void Mult()
    {
        for (int i = 0; i < expressionPartes.Count; i++)
        {
            if (expressionPartes[i] == "*")
            {
                var mult = double.Parse(expressionPartes[i-1])*double.Parse(expressionPartes[i+1]);
                expressionPartes[i-1] = mult.ToString();
                expressionPartes.RemoveAt(i+1);
                expressionPartes.RemoveAt(i);
                i--;
            }
        }
    }
    private void Sub()
    {
        for (int i = 0; i < expressionPartes.Count; i++)
        {
            if (expressionPartes[i] == "-")
            {
                var sub = double.Parse(expressionPartes[i-1]) - double.Parse(expressionPartes[i+1]);
                expressionPartes.RemoveAt(i+1);
                expressionPartes.RemoveAt(i);
                expressionPartes[i-1] = sub.ToString();
                i--;
            }
        }
    }
    private void Sum()
    {
        for (int i = 0; i < expressionPartes.Count; i++)
        {
            if (expressionPartes[i] == "+")
            {
                var sum = int.Parse(expressionPartes[i - 1]) + int.Parse(expressionPartes[i + 1]);
                expressionPartes.RemoveAt(i + 1);
                expressionPartes.RemoveAt(i);
                expressionPartes[i-1] = sum.ToString();
                i--;
            }
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var strToCalculate = Console.ReadLine();
        if(string.IsNullOrEmpty(strToCalculate))
        {
            strToCalculate = "3 + 3 * 3 / 3" ;
        }
        new Calculator(strToCalculate);
        return;
    }
}