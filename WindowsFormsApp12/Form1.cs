using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        List<Label> myLabels = new List<Label>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            createLabels(10);
            calculatePositions();

        }

        // Create all of the labels and put them into the list
        void createLabels(int numberOfLabels)
        {
            for (int i = 0; i < numberOfLabels; i++)
            {
                Label x = new Label();
                this.Controls.Add(x);
                myLabels.Add(x);
                x.Text = "TEST" + i;
                x.Font = new Font("Arial", trackBar1.Value, FontStyle.Bold);
                x.BackColor = Color.Blue;
                x.ForeColor = Color.White;
                x.AutoSize = true;
            }
        }

        // workout the positions of the labels
        void calculatePositions()
        {
            Point theLoc = new Point(0, 0);
            Size winSize = this.Size;
            int col = 0;
            int row = 1;
            const int gap = 10;
            foreach (Label label in myLabels)
            {

                // firstly see whether or not the next label will fit inside this row
                // if not we increment row.
                if ((((col + 1) * label.Size.Width) + (col * gap)) > winSize.Width)
                {
                    col = 0;
                    row++;
                }

                theLoc.X = (int)((col * label.Size.Width) + (col * gap));
                theLoc.Y = (int)((row * (label.Size.Height + 20)) + (row * gap));
                label.Location = theLoc;

                col++;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            calculatePositions();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            changeFontSize(trackBar1.Value);
            calculatePositions();
        }
        private void changeFontSize(int newSize)
        {
            Font newFont = new Font("Arial", newSize);
            foreach (Label label in myLabels)
            {
                label.Font = newFont;
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            foreach (Label theLab in myLabels)
            {
                this.Controls.Remove(theLab);
            }
            myLabels.Clear();
            createLabels(trackBar2.Value);
            calculatePositions();

        }
    }
}
