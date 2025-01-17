using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mathGame.athallie
{
    internal class GameUtils
    {
        private string _choice, _question;
        private List<string> _gameHistory = null;

        public GameUtils()
        {
            _gameHistory = new List<string>();
        }

        public bool validateAnswer(string answer)
        {
            return Convert.ToInt32(answer).Equals(getAnswer());
        }

        private void setQuestion(string op)
        {
            if (op == "0")
            {
                System.Environment.Exit(0);
            }
            else if (op == "1") {
                showHistory();
                _question = "1";
                return;
            }
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
            _question =  $"{ints[0]} {op} {ints[1]}";
        }
        private string getOperator()
        {
            switch (_choice.ToLower())
            {
                case "a": return "+";
                case "b": return "-";
                case "c": return "*";
                case "d": return "/";
                case "e": return "0";
                case "f": return "1";
                default: return "-1";
            }
        }

        public int processChoice()
        {
            string op = getOperator();
            if (op == "0")
            {
                Console.WriteLine("\nThank you for playing!");
                System.Environment.Exit(0);
            }
            else if (op == "1")
            {
                showHistory();
                _question = "1";
                return 1;
            }
            else if (op == "-1") {
                Console.WriteLine("\nWrong input. You should only enter the alphabet of the choice.");
                return -1;
            } else
            {
                setQuestion(op);
            }
            return 0;
        }

        public int getAnswer()
        {
            string[] expressionElements = _question
            .Split().Where(e => e != " ")
            .ToArray();
            var a = Convert.ToInt32(expressionElements[0]);
            var b = Convert.ToInt32(expressionElements[2]);

            switch (expressionElements[1])
            {
                case "+": return Arithmethics.add(a, b);
                case "-": return Arithmethics.substract(a, b);
                case "*": return Arithmethics.multiply(a, b);
                case "/": return Arithmethics.divide(a, b);
                default: return 0;
            }
        }

        public static void showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.Write("""
                [A] Addition
                [B] Substraction
                [C] Multiplication
                [D] Division
                [E] Quit
                [F] History

            Choice (Alphabet): 
            """);
        }

        public void showResult(string answer)
        {
            var result = validateAnswer(answer);
            switch (result)
            {
                case true: 
                    Console.WriteLine("You're correct. The answer is " + answer);
                    _gameHistory.Add($"Won | {_question} | You answered {answer}");
                    break;
                case false: 
                    Console.WriteLine("You're wrong. The answer is " + getAnswer());
                    _gameHistory.Add($"Lost | {_question} | You answered {answer} | Correct answer is {getAnswer()}");
                    break;
            }
        }

        public string getQuestion()
        {
            return _question;
        }

        public string getChoice()
        {
            return _choice;
        }

        public void showHistory()
        {
            Console.WriteLine();
            Console.WriteLine($"""
                History
                ------------------
                """);
            if ( _gameHistory != null && _gameHistory.Count > 0 )
            {
                _gameHistory.ForEach(hist => Console.WriteLine(hist));
            } else
            {
                Console.WriteLine("You haven't played any games yet");
            }
            Console.WriteLine();
        }

        public static void showWelcomePrompt()
        {
            Console.WriteLine($"""
                Welcome to Math Game!
                ---------------------
                """);
        }

        public void setChoice(string choice)
        {
            _choice = choice;
        }
    }
}
