//Starting Prompt
using System.Security.Cryptography;

Console.WriteLine("Welcome to Math Game!");
Console.WriteLine("What do you want to do?");
Console.WriteLine("""
    [A] Addition
    [B] Substraction
    [C] Multiplication
    [D] Division
    """);

//Input
string choice = Console.ReadLine();

//Output: Question
var question = getQuestion(choice);
Console.WriteLine(question);

//Input: Answer
string answer = Console.ReadLine();

//Output: Result
bool result = validateAnswer(question, answer);
switch(result) {
    case true: Console.WriteLine("You're correct. The answer is " + answer); break ;
    case false: Console.WriteLine("You're wrong. The answer is " + getAnswer(question)); break;
}

//Methods
bool validateAnswer(string question, string answer)
{
    return Convert.ToInt32(answer).Equals(getAnswer(question));
}
int add(int a, int b)
{
    return a + b;
}

int substract(int a, int b)
{
    return a - b;
}

int multiply(int a, int b)
{
    return a * b;
}

int divide(int a, int b)
{
    return a / b;
}
string getQuestion(string choice)
{
    string op = getOperator(choice);
    int[] ints = [
        RandomNumberGenerator.GetInt32(101), 
        RandomNumberGenerator.GetInt32(101)];
    if (op == "/")
    {
        while (ints[0] % ints[1] != 0)
        {
            ints = [
                RandomNumberGenerator.GetInt32(101), 
                RandomNumberGenerator.GetInt32(1, 101)];
        }
    }
    return $"{ints[0]} {getOperator(choice)} {ints[1]}";
}
string getOperator(string choice)
{
    switch(choice.ToLower())
    {
        case "a": return "+";
        case "b": return "-";
        case "c": return "*";
        case "d": return "/";
        default: return "";
    }
}

int getAnswer(string question)
{
    string[] expressionElements = question
    .Split().Where(e => e != " ")
    .ToArray();
    var a = Convert.ToInt32(expressionElements[0]);
    var b = Convert.ToInt32(expressionElements[2]);

    switch (expressionElements[1])
    {
        case "+": return add(a, b);
        case "-": return substract(a, b);
        case "*": return multiply(a, b);
        case "/": return divide(a, b);
        default: return 0;
    }

}