using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Game_of_Jeopardy
{
    public partial class AandQ : Form
    {
        public string answer { get; set; }
        public int points { get; set; }
        public string player1 { get; set; }

        public AandQ(string question, int points)
        {
            InitializeComponent();
            // Sets question label maximum size
            questionLabel.MaximumSize = new Size(500, 0);
            questionLabel.AutoSize = true;

            // Sets question label text to question
            questionLabel.Text = question;
            pointsLabel.Text = "This question is worth " + points + " points";
        }

        private void AandQ_Load(object sender, EventArgs e)
        {
            // Hides buttons so player cannot exit the AandQ form
            this.ControlBox = false;
        }
   
    private void button1_Click(object sender, EventArgs e)
    {
            // Pulls up messagebox to ask if user got question correct
            DialogResult dialogResult = MessageBox.Show("The correct answer is " + answer +
                ". Did you answer correctly?", "Correct Answer", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (playerSelectionComboBox.SelectedIndex == 0)
                {
                    // Add points player 1
                }
                else if (playerSelectionComboBox.SelectedIndex == 1)
                {
                    // Add points player 2
                }
                else if (playerSelectionComboBox.SelectedIndex == 2)
                {
                    // Add points player 3
                }
                this.Hide();
            }
            else
            {
                if (playerSelectionComboBox.SelectedIndex == 0)
                {
                    // Subtract points player 1
                }
                else if (playerSelectionComboBox.SelectedIndex == 1)
                {
                    // Subtract points player 2
                }
                else if (playerSelectionComboBox.SelectedIndex == 2)
                {
                    // Subtract points player 3
                }
                this.Hide();
            }

        }
    }
}
