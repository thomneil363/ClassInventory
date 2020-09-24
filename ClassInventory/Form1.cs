using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassInventory
{
    public partial class Form1 : Form
    {
        // Create a List to store all inventory objects
        List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            // Gather all information from screen 
            string name = nameInput.Text;
            int age = Convert.ToInt16(ageInput.Text);
            string team = teamInput.Text;
            string position = positionInput.Text;

            // Create object with gathered information
            Player newPlayer = new Player(name, age, team, position);

            // Add object to global list
            players.Add(newPlayer);

            // Display message to indicate addition made
            outputLabel.Text = "";

            outputLabel.Text = (name + "\n" +  age + "\n" + team  + "\n" + position);

            nameInput.Text = "";
            ageInput.Text = "";
            teamInput.Text = "";
            positionInput.Text = "";

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // This is to be completed in Part II. You will use 
            // Lambda Expressions.
            //---------------------------

            int playerIndex = players.FindIndex(x => x.name == removeInput.Text);

            if (playerIndex >= 0)
            {
                // If object is in list remove it
                players.RemoveAt(playerIndex);

                // Display message to indicate deletion made
                outputLabel.Text = "Successfully removed player " + removeInput.Text + "." ;
            }
            else
            {
                // Display error message to indicate a failed deletion
                outputLabel.Text = "Player " + removeInput.Text + " does not exist.";
            }
            removeInput.Text = "";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // This is to be completed in Part II. You will use 
            // Lambda Expressions.
            //---------------------------

            List<Player> searchedPlayers= players.FindAll(x => x.name == searchInput.Text);

            if (searchedPlayers.Count() > 0)
            {
                outputLabel.Text = "";

                // If object entered exists in list show it
                foreach (Player p in searchedPlayers)

                {
                    outputLabel.Text += p.name + "\n";
                    outputLabel.Text += p.age + "\n";
                    outputLabel.Text += p.team + "\n";
                    outputLabel.Text += p.position + "\n" + "\n";
                }
            }
            else
            {
                // Else show not found message
                outputLabel.Text = "Player " + searchInput.Text + " does not exist.";

            }
            searchInput.Text = "";
        }

        private void showButton_Click(object sender, EventArgs e)
        {

            // Show all objects in list
            outputLabel.Text = "";

            foreach (Player p in players)
            {
                outputLabel.Text += p.name + "\n";
                outputLabel.Text += p.age + "\n";
                outputLabel.Text += p.team + "\n";
                outputLabel.Text += p.position + "\n" + "\n";
            }
        }
    }
}
