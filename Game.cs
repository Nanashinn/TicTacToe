using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Game
    {
        private readonly List<Button> _btns;
        private readonly List<Label> _labels;

        private string _turnLetter;
        private int _plays;
        private bool _turn;
        private readonly int[] _wins;

        public Game(List<Button> btns, List<Label> labels)
        {
            _btns = btns;
            _labels = labels;

            _plays = 0;
            _turn = true;
            _wins = new int[2];
        }


        public void BtnClick(object sender)
            => ChangeBlock((Button) sender);

        private void ChangeBlock(Button btn)
        {
            if (String.IsNullOrEmpty(btn.Text))
            {
                _turnLetter = CheckTurn();

                btn.Text = _turnLetter;
                CheckPlay();

                _plays++;
                _turn = !_turn;
            }
        }

        private string CheckTurn()
            => _turn ? "X" : "O";

        private void CheckPlay()
        {
            if (ChecarDirecoes())
                BroadcastWinner(_turnLetter);
            else if (_plays == 9)
            {
                MessageBox.Show("It's a tie.");
                RestartGame();
            }
        }

        private bool ChecarDirecoes()
           => CheckHorizontal() || CheckVerticals() || CheckDiagonals();

        private bool CheckHorizontal()
        {
            int sum = 1;
            for (int i = 0; i < 3; i++)
            {
                if (_btns[(i + sum) - 1].Text == _turnLetter && _btns[(i + (sum + 1)) - 1].Text == _turnLetter && _btns[(i + (sum + 2)) - 1].Text == _turnLetter)
                    return true;
                sum += 2;
            }

            return false;
        }

        private bool CheckVerticals()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_btns[(i + 1) - 1].Text == _turnLetter && _btns[(i + 4) - 1].Text == _turnLetter && _btns[(i + 7) - 1].Text == _turnLetter)
                    return true;
            }

            return false;
        }

        private bool CheckDiagonals()
            => _btns[0].Text == _turnLetter && _btns[4].Text == _turnLetter && _btns[8].Text == _turnLetter ||
               _btns[2].Text == _turnLetter && _btns[4].Text == _turnLetter && _btns[6].Text == _turnLetter;

        private void BroadcastWinner(string winner)
        {
            CountWins(winner);
            MessageBox.Show($"The winner is {winner}.");
            RestartGame();
        }

        private void CountWins(string winner)
        {
            _ = winner == "X" ? _wins[0]++ : _wins[1]++;
            UpdateWins();
        }

        private void UpdateWins()
        {
            _labels[0].Text = $"X Wins: {_wins[0]}";
            _labels[1].Text = $"O Wins: {_wins[1]}";
        }

        private void RestartGame()
        {
            foreach (var btn in _btns)
            {
                btn.Text = String.Empty;
                btn.BackColor = SystemColors.Control;
            }
            _plays = 0;
            _turn = true;
        }
    }
}
