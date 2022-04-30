using ConsoleApp1;

// Iterate through NameList from start to finish
QuestionClass.ListRecursion(0);

Console.WriteLine(TESTModule("hello"));
Console.WriteLine(TESTModule(1.0f));
Console.WriteLine(TESTModule(2.0f));
//TESTModule(0); // Commented out, as this throws the requested exception
Console.WriteLine(TESTModule(2));
Console.WriteLine(TESTModule(5));
Console.WriteLine(TESTModule(7.54568));
Console.WriteLine(TESTModule('d'));


T TESTModule<T>(T input)
{
    switch (input)
    {
        case string s:
            return (T)(object)s.ToUpper();

        case 1.0f:
            return (T)(object)3.0f;
        case 2.0f:
            return (T)(object)3.0f;

        case int i:
            if (i > 4) i = i * 3;
            else if (i < 1) throw new ArgumentOutOfRangeException();
            else i = i * 2;
            return (T)(object)i;

        default:
            return input;
    }
}
