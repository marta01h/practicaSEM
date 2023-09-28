using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Commands;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private GameModel _gameModel;
        private int _guess;
        private string _resultMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Guess
        {
            get { return _guess; }
            set
            {
                _guess = value;
                OnPropertyChanged();
                CheckGuessCommand.RaiseCanExecuteChanged();
            }
        }

        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                _resultMessage = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CheckGuessCommand { get; }

        public GameViewModel()
        {
            _gameModel = new GameModel();
            StartNewGame();

            CheckGuessCommand = new RelayCommand(CheckGuess, () => Guess >= 1 && Guess <= 20);
        }

        public void StartNewGame()
        {
            _gameModel.StartNewGame(1, 20);
            ResultMessage = "Угадайте число!";
        }

        public void CheckGuess()
        {
            if (_gameModel.CheckGuess(Guess))
            {
                ResultMessage = "Вы угадали!";
                MessageBox.Show("Вы угадали число!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                StartNewGame();
            }
            else
            {
                ResultMessage = "Попробуйте еще раз.";
                MessageBox.Show("Попробуйте еще раз.", "Результат", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
