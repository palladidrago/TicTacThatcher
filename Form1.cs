using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictacthacher
{
    public partial class YshayMeirTicTacToe : Form
    {
        
        public YshayMeirTicTacToe()
        {
            InitializeComponent();
            
        }

        private void ResetBoard()
        {
            Label curLabel;
            
            foreach (Control ctrl in this.Controls)
                if (ctrl is Label)
                {
                    curLabel = ctrl as Label;
                    curLabel.Enabled = true;
                    curLabel.Text = "";
                }
            this.m_currentletter = "x";
        }

        string[,] mat;
        string m_currentletter = "x";
        private void Label_Click(object sender, EventArgs e)
        {
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            Label l = sender as Label;
            l.Enabled = false;
            if (m_currentletter == "x")
            {
                l.Text = "x";
                m_currentletter = "o";
                mat = FormToMatrix();
                if (IsWinXorO(mat, "x"))
                {
                    
                    Form form_win = new Form();
                    this.Hide();
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\palla\Documents\Coding\shisharp\tictacthacher\Resources\Frailah.wav");
                    player.Play();

                    form_win.Text = "X won";
                    form_win.ShowDialog();
                    player.Stop();
                    this.Show();
                    ResetBoard();
                    
                   
                }
            }
            else
            {
                l.Text = "o";
                m_currentletter = "x";
                mat = FormToMatrix();
                if (IsWinXorO(mat, "o"))
                {
                    
                    Form form_win = new Form();
                    this.Hide();
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\palla\Documents\Coding\shisharp\tictacthacher\Resources\Frailah.wav");
                    player.Play();

                    form_win.Text = "O won";
                    form_win.ShowDialog();
                    player.Stop();
                    this.Show();
                    ResetBoard();
                }
            }
        }
        public string[,] FormToMatrix()
        {

            //Returns matrix from labels.

            string[,] m = new string[3, 3];
            int row, col;
            Label curLabel;

            //Iterate through controls.

            foreach (Control ctrl in this.Controls)
                if (ctrl is Label)
                {
                    curLabel = ctrl as Label;

                    //מציאת מספר השורה והעמודה מתוך שם הפקד

                    row = int.Parse(curLabel.Name[curLabel.Name.Length - 2].ToString());
                    col = int.Parse(curLabel.Name[curLabel.Name.Length - 1].ToString());
                    m[row, col] = curLabel.Text;
                }
            return m;
        }
        public bool IsWinXorO(string[,] sMat, string s)
        {

            int countRow = 0, countColumn = 0;

            for (int i = 0; i < sMat.GetLength(0); i++)
            {
                countRow = 0;
                countColumn = 0;
                for (int j = 0; j < sMat.GetLength(1); j++)
                {
                    //Row check 
                    if (sMat[i, j] == s) { countRow++; }
                    if (sMat[j, i] == s) { countColumn++; }
                    if (countRow == 3 || countColumn == 3) return true;
                }
            }
            //Diagonal check
            return (sMat[0, 0] == s && sMat[1, 1] == s && sMat[2, 2] == s)
                || (sMat[0, 2] == s && sMat[1, 1] == s && sMat[2, 0] == s);
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
