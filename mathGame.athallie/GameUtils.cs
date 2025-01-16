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

        public GameUtils(string choice)
        {
            _choice = choice;
            _question = setQuestion();
        }

        public bool validateAnswer(string answer)
        {
            return Convert.ToInt32(answer).Equals(getAnswer());
        }

        private string setQuestion()
        {
            string op = getOperator();
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
            return $"{ints[0]} {getOperator()} {ints[1]}";
        }
        public string getOperator()
        {
            switch (_choice.ToLower())
            {
                case "a": return "+";
                case "b": return "-";
                case "c": return "*";
                case "d": return "/";
                default: return "";
            }
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

        public string getQuestion()
        {
            return _question;
        }

        public string getChoice()
        {
            return _choice;
        }
    }
}
