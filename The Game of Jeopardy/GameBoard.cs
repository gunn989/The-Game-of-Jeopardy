using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace The_Game_of_Jeopardy
{
    public partial class GameBoard : Form
    {
        // Gets player names
        public static string question;
        public string player1Name { get; set; }
        public string player2Name { get; set; }
        public string player3Name { get; set; }
        public int player1Points { get; set; }
        public int player2Points { get; set; }
        public int player3Points { get; set; }

        // Counter to keep track of which questions have been answered
        int counter = 0;

        // Variable for category
        public int i;
        // Variable for which question in category
        public int j;


        public GameBoard()
        {
            InitializeComponent();  
        }



        private void GameBoard_Load(object sender, EventArgs e)
        {
            // Loads in new xml document
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(Environment.CurrentDirectory, "Jeopardy.xml"));

            // Sets labels to wrap text
            category1.MaximumSize = new Size(110, 0);
            category1.AutoSize = true;

            category2.MaximumSize = new Size(110, 0);
            category2.AutoSize = true;

            category3.MaximumSize = new Size(110, 0);
            category3.AutoSize = true;

            category4.MaximumSize = new Size(110, 0);
            category4.AutoSize = true;

            category5.MaximumSize = new Size(110, 0);
            category5.AutoSize = true;


            // Loads labels with proper names
            category1.Text = (doc.DocumentElement.ChildNodes[0].Attributes["name"].Value);
            category2.Text = (doc.DocumentElement.ChildNodes[1].Attributes["name"].Value);
            category3.Text = (doc.DocumentElement.ChildNodes[2].Attributes["name"].Value);
            category4.Text = (doc.DocumentElement.ChildNodes[3].Attributes["name"].Value);
            category5.Text = (doc.DocumentElement.ChildNodes[4].Attributes["name"].Value);

            // Sets player labels to player names
            player1NameLabel.Text = player1Name;
            player2NameLabel.Text = player2Name;
            player3NameLabel.Text = player3Name;


            // Sets player points
            player1PointsLabel.Text = Convert.ToString(player1Points);
            player2PointsLabel.Text = Convert.ToString(player2Points);
            player3PointsLabel.Text = Convert.ToString(player3Points);


        }
        private void endGameButton_Click(object sender, EventArgs e)
        {
            // Only ends the game if all questions have been answered

            if (counter == 25)
            {
                MessageBox.Show("Game Over!");
                Results results = new Results();
                results.Closed += (s, args) => this.Close();
                results.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please answer all the questions before trying to complete the game!");
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            // Asks user if they want to start a new game
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to start a new game?",
                "New Game?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                // Creates new options form
                // Closes current form
                Options newGame = new Options();
                newGame.Closed += (s, args) => this.Close();
                newGame.Show();
                this.Hide();
            }


        }


        private void quitGamebutton_Click(object sender, EventArgs e)
        {
            // Asks user if they want to exit the game.
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit the game?", "Quit Game?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                // Exits windows form application
                System.Windows.Forms.Application.Exit();
            }
        }

        public static void GetXml(int i, int j)
        {
            // Loads in XMl document
            XmlDocument doc = new XmlDocument();
            // Sets up nodelist
            XmlNodeList xmlnode;
            // Opens new filestream for the Jeopardy xml file
            FileStream fs = new FileStream("Jeopardy.xml", FileMode.Open, FileAccess.Read);
            doc.Load(fs);
            // Gets category node from XML file
            xmlnode = doc.GetElementsByTagName("category");
            // Gets the XMlnode for the first category of questions
            // Gets the question, answer, and points for the proper question
            xmlnode[i].ChildNodes.Item(j).InnerText.Trim();
            question = xmlnode[i].ChildNodes.Item(j).InnerText.Trim();
            string answer = xmlnode[i].ChildNodes.Item(j).Attributes["answer"].Value;
            int points = Int16.Parse(xmlnode[i].ChildNodes.Item(j).Attributes["points"].Value);
            // Sets up new AandQ form
            // Passes the question, points, and answer to the AandQ form
            AandQ aand = new AandQ(question, points);
            aand.player1 = 
            aand.answer = answer;
            aand.Show();



        }

        /* Each of the following buttons do the same thing, except that they pull from differents parts of the XML 
         Document */
        private void cat1Question1Button_Click(object sender, EventArgs e)
        {
            // Define variables to pull from different parts of the XML document
            i = 0;
            j = 0;
            // Runs the getXML method with the assigned variables
            GetXml(i, j);
            // Disables the button and removes the text
            cat1Question1Button.Enabled = false;
            cat1Question1Button.Text = "";
            // Adds one to counter
            counter++;

        }

        private void cat1Question2Button_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 1;
            GetXml(i, j);
            cat1Question2Button.Enabled = false;
            cat1Question2Button.Text = "";
            counter++;
        }


        private void cat1Question3Button_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 2;
            GetXml(i, j);
            cat1Question3Button.Enabled = false;
            cat1Question3Button.Text = "";
            counter++;
        }

        private void cat1Question4Button_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 3;
            GetXml(i, j);
            cat1Question4Button.Enabled = false;
            cat1Question4Button.Text = "";
            counter++;
        }

        private void cat1Question5Button_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 4;
            GetXml(i, j);
            cat1Question5Button.Enabled = false;
            cat1Question5Button.Text = "";
            counter++;
        }

        private void cat2Question1Button_Click(object sender, EventArgs e)
        {
            i = 1;
            j = 0;
            GetXml(i, j);
            cat2Question1Button.Enabled = false;
            cat2Question1Button.Text = "";
            counter++;
        }

        private void cat2Question2Button_Click(object sender, EventArgs e)
        {
            i = 1;
            j = 1;
            GetXml(i, j);
            cat2Question2Button.Enabled = false;
            cat2Question2Button.Text = "";
            counter++;
        }

        private void cat2Question3Button_Click(object sender, EventArgs e)
        {
            i = 1;
            j = 2;
            GetXml(i, j);
            cat2Question3Button.Enabled = false;
            cat2Question3Button.Text = "";
            counter++;
        }

        private void cat2Question4Button_Click(object sender, EventArgs e)
        {
            i = 1;
            j = 3;
            GetXml(i, j);
            cat2Question4Button.Enabled = false;
            cat2Question4Button.Text = "";
            counter++;
        }

        private void cat2Question5Button_Click(object sender, EventArgs e)
        {
            i = 1;
            j = 4;
            GetXml(i, j);
            cat2Question5Button.Enabled = false;
            cat2Question5Button.Text = "";
            counter++;
        }

        private void cat3Question1Button_Click(object sender, EventArgs e)
        {
            i = 2;
            j = 0;
            GetXml(i, j);
            cat3Question1Button.Enabled = false;
            cat3Question1Button.Text = "";
            counter++;
        }

        private void cat3Question2Button_Click(object sender, EventArgs e)
        {
            i = 2;
            j = 1;
            GetXml(i, j);
            cat3Question2Button.Enabled = false;
            cat3Question2Button.Text = "";
            counter++;
        }

        private void cat3Question3Button_Click(object sender, EventArgs e)
        {
            i = 2;
            j = 2;
            GetXml(i, j);
            cat3Question3Button.Enabled = false;
            cat3Question3Button.Text = "";
            counter++;
        }

        private void cat3Question4Button_Click(object sender, EventArgs e)
        {
            i = 2;
            j = 3;
            GetXml(i, j);
            cat3Question4Button.Enabled = false;
            cat3Question4Button.Text = "";
            counter++;
        }

        private void cat3Question5Button_Click(object sender, EventArgs e)
        {
            i = 2;
            j = 4;
            GetXml(i, j);
            cat3Question5Button.Enabled = false;
            cat3Question5Button.Text = "";
            counter++;
        }

        private void cat4Question1Button_Click(object sender, EventArgs e)
        {
            i = 3;
            j = 0;
            GetXml(i, j);
            cat4Question1Button.Enabled = false;
            cat4Question1Button.Text = "";
            counter++;
        }

        private void cat4Question2Button_Click(object sender, EventArgs e)
        {
            i = 3;
            j = 1;
            GetXml(i, j);
            cat4Question2Button.Enabled = false;
            cat4Question2Button.Text = "";
            counter++;
        }

        private void cat4Question3Button_Click(object sender, EventArgs e)
        {
            i = 3;
            j = 2;
            GetXml(i, j);
            cat4Question3Button.Enabled = false;
            cat4Question3Button.Text = "";
            counter++;
        }

        private void cat4Question4Button_Click(object sender, EventArgs e)
        {
            i = 3;
            j = 3;
            GetXml(i, j);
            cat4Question4Button.Enabled = false;
            cat4Question4Button.Text = "";
            counter++;
        }

        private void cat4Question5Button_Click(object sender, EventArgs e)
        {
            i = 3;
            j = 4;
            GetXml(i, j);
            cat4Question5Button.Enabled = false;
            cat4Question5Button.Text = "";
            counter++;
        }

        private void cat5Question1Button_Click(object sender, EventArgs e)
        {
            i = 4;
            j = 0;
            GetXml(i, j);
            cat5Question1Button.Enabled = false;
            cat5Question1Button.Text = "";
            counter++;
        }

        private void cat5Question2Button_Click(object sender, EventArgs e)
        {
            i = 4;
            j = 1;
            GetXml(i, j);
            cat5Question2Button.Enabled = false;
            cat5Question2Button.Text = "";
            counter++;
        }

        private void cat5Question3Button_Click(object sender, EventArgs e)
        {
            i = 4;
            j = 2;
            GetXml(i, j);
            cat5Question3Button.Enabled = false;
            cat5Question3Button.Text = "";
            counter++;
        }

        private void cat5Question4Button_Click(object sender, EventArgs e)
        {
            i = 4;
            j = 3;
            GetXml(i, j);
            cat5Question4Button.Enabled = false;
            cat5Question4Button.Text = "";
            counter++;
        }

        private void cat5Question5Button_Click(object sender, EventArgs e)
        {
            i = 4;
            j = 4;
            GetXml(i, j);
            cat5Question5Button.Enabled = false;
            cat5Question5Button.Text = "";
            counter++;
        }
    }
}
