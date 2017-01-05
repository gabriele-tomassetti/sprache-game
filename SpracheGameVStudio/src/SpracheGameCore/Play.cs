using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpracheGameCore
{
    public enum Command
    {
        Greater,
        Less,
        Between,
        Equal
    }

    public class Play
    {
        readonly Command _command;
        readonly int _firstNumber;
        readonly int _secondNumber;

        public Play(Command command, string firstNumber, string secondNumber)
        {
            _command = command;

            if (!int.TryParse(firstNumber, out _firstNumber))
                throw new ArgumentNullException("firstNumber");

            if (secondNumber != null)
            {
                if (!int.TryParse(secondNumber, out _secondNumber))
                    throw new ArgumentNullException("secondNumber");
            }
        }

        public Command Command { get { return _command; } }

        public int FirstNumber { get { return _firstNumber; } }

        public int SecondNumber { get { return _secondNumber; } }

        public bool Evaluate(int number)
        {
            bool result = false;

            switch (Command)
            {
                case Command.Greater:
                    result = number > FirstNumber;
                    break;

                case Command.Less:
                    result = number < FirstNumber;
                    break;

                case Command.Between:
                    result = (number > FirstNumber) && (number < SecondNumber);
                    break;

                case Command.Equal:
                    result = number == FirstNumber;
                    break;
            }

            return result;
        }
    }
}
