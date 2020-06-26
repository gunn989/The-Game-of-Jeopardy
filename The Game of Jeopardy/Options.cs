using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace The_Game_of_Jeopardy
{
    public partial class Options : Form
    {

        public Options()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void StartForm()
        {
            Application.Run(new Splash());
        }

        private void startButton_Click(object sender, EventArgs e)
        {


            Player player1 = new Player(player1TextBox.Text, 0);
            Player player2 = new Player(player2TextBox.Text, 0);
            Player player3 = new Player(player3TextBox.Text, 0);
            GameBoard gBoard = new GameBoard();
            gBoard.player1Name = player1.playerName;
            gBoard.player2Name = player2.playerName;
            gBoard.player3Name = player3.playerName;

            gBoard.player1Points = player1.points;
            gBoard.player2Points = player2.points;
            gBoard.player3Points = player3.points;


            // Hides current form
            // Closes current form
            // Shows new form
            gBoard.Closed += (s, args) => this.Close();
            gBoard.Show();
            this.Hide();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Disables textboxes depending on how many players are playing. 
            if (comboBox1.SelectedIndex == 0)
            {
                player2TextBox.Enabled = false;
                player3TextBox.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                player3TextBox.Enabled = false;
            }
            else
            {
                player1TextBox.Enabled = true;
                player2TextBox.Enabled = true;
                player3TextBox.Enabled = true;
            }
            
        }

    }
}
