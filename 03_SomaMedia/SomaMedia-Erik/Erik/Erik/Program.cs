// See https://aka.ms/new-console-template for more information

var mean = new Mean();

class Mean
{
    private List<float> _numbers = new List<float>();

    public void Add(float number)
    {
        _numbers.Add(number);
    }

    public float calculate()
    {
        if (_numbers.Count == 0)
        {
            Console.WriteLine("sem valores cadastrados");
            return 0;
        }
        float sum = 0;
        foreach (var number in _numbers)
        {
            sum += number;
        }

        var mean = sum / _numbers.Count;
        return mean;
    }
    
    public Mean()
    {
        Console.Write("Coloque o valores cadastrados: ");
        try
        {
            for (var i = 0; i < 10; i++)
            {
                var atual = float.Parse(Console.ReadLine());
                Add(atual);
            }

            Console.WriteLine("Limite maximo de 10");
        }
        finally
        {
            Console.WriteLine(calculate());
        }
    }
    
}