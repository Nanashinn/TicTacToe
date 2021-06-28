using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game _game;

        public Form1()
        {
            InitializeComponent();

            _game = new Game(GetBtns(), GetLabels());
        }


        private List<Button> GetBtns()
        {
            var btns = new List<Button>();
            foreach (var item in Controls)
                if (item is Button btn)
                    btns.Add(btn);

            btns.Reverse();
            return btns;
        }

        private List<Label> GetLabels()
        {
            var labels = new List<Label>();
            foreach (var item in Controls)
                if (item is Label label)
                    labels.Add(label);

            labels.Reverse();
            return labels;
        }

        private void button_enter(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            btn.BackColor = Color.AliceBlue;
        }

        private void button_leave(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            btn.BackColor = SystemColors.Control;
        }

        private void button_click(object sender, EventArgs e)
            => _game.BtnClick((Button)sender);
    }
}
