using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class GameModel
    {
        private readonly Random _random = new Random();
        private int _targetNumber;

        public void StartNewGame(int minValue, int maxValue)
        {
            _targetNumber = _random.Next(minValue, maxValue + 1);
        }

        public bool CheckGuess(int guess)
        {
            return guess == _targetNumber;
        }
    }
}
