//Starting Prompt
using System.Security.Cryptography;
using mathGame.athallie;

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
GameUtils gameUtils = new GameUtils(choice);

//Output: Question
var question = gameUtils.getQuestion();
Console.WriteLine(question);

//Input: Answer
string answer = Console.ReadLine();

//Output: Result
bool result = gameUtils.validateAnswer(answer);
switch(result) {
    case true: Console.WriteLine("You're correct. The answer is " + answer); break ;
    case false: Console.WriteLine("You're wrong. The answer is " + gameUtils.getAnswer()); break;
}