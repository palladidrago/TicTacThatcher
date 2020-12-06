using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictacthacher
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }


        string[,] mat;
        char m_currentletter = 'x';
        private void Label_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            mat = FormToMatrix();
            if (m_currentletter == 'x')
            {
                l.Text = "x";
                m_currentletter = 'o';
                if (IsWinXorO(mat, "x")) MessageBox.Show("X won"); 
            }
            else
            {
                l.Text = "o";
                m_currentletter = 'x';
                if (IsWinXorO(mat, "o")) MessageBox.Show("O won"); 
            }
            l.Enabled = false;
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
                    if (sMat[i, j] == s) {countRow++; MessageBox.Show(s+" put in row"); }
                    if (sMat[j, i] == s) {countColumn++; MessageBox.Show(s+" put in column");}
                    if (countRow == 3 && countColumn==3 ) return true;
                }
            }
            //Diagonal check
            if (sMat[0, 0] == s && sMat[1, 1] == s && sMat[2, 2] == s
                || sMat[0, 2] == s && sMat[1, 1] == s && sMat[2, 0] == s) return true;
            return false;
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
