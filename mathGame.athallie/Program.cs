//Starting Prompt
using System.Security.Cryptography;
using mathGame.athallie;

play();

void play()
{
    GameUtils.showWelcomePrompt();
    GameUtils gameUtils = new GameUtils();
    while (true)
    {
        GameUtils.showMenu();

        //Get user's choice of game
        string choice = Console.ReadLine();
        gameUtils.setChoice(choice);
        //Get random math question involving user's choice of game
        if (gameUtils.processChoice() == -1) { continue; };
        var question = gameUtils.getQuestion();
        if (question == "1") { continue; }
        Console.WriteLine("Question: " + question);

        //Get user's answer to the question
        Console.Write("Answer: ");
        string answer = Console.ReadLine();
        Console.WriteLine();

        gameUtils.showResult(answer);
    }
}