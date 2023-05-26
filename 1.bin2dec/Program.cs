var input = "";
var isInputValid = false;

while (!isInputValid)
{
    Console.Write($"Please input binary number(up to 8 digits): ");
    input = Console.ReadLine();
    Console.WriteLine(input);
    if (IsBinary(input) && input.Length <= 8)
        isInputValid = true;
    else
    {
        Console.WriteLine($"Please only input binary number sir, which is 0 and 1{Environment.NewLine}");
    }
}

Console.WriteLine($"The decimal value of {input} is: {Convert2Decimal(input)}");

static double Convert2Decimal(string input)
{
    var decval = 0.0;
    for (int i = input.Length - 1, j = 0; i >= 0; i--, j++)
    {
        decval += Convert.ToInt16(input[i].ToString()) * Math.Pow(2, j);
    }
    return decval;
}

static bool IsBinary(string input)
{
    foreach (var @char in input)
    {
        if (@char != '0' && @char != '1')
            return false;
    }
    return true;
}

var isModeTest = true;
if (isModeTest)
{
    TestConvert2Decimal("0", 0);
    TestConvert2Decimal("1", 1);
    TestConvert2Decimal("10", 2);
    TestConvert2Decimal("11", 3);
    TestConvert2Decimal("101", 5);
    TestConvert2Decimal("111", 7);
    TestConvert2Decimal("1000", 8);
    TestConvert2Decimal("101010", 42);
    TestConvert2Decimal("11001100", 204);
    TestConvert2Decimal("11111111", 255);
}
static void TestConvert2Decimal(string binary, double expectedDecimal)
{
    double decimalValue = Convert2Decimal(binary);

    Console.WriteLine("Binary: " + binary);
    Console.WriteLine("Expected Decimal: " + expectedDecimal);
    Console.WriteLine("Actual Decimal: " + decimalValue);
    Console.WriteLine("Test Result: " + (decimalValue == expectedDecimal ? "Passed" : "Failed"));
    Console.WriteLine();
}