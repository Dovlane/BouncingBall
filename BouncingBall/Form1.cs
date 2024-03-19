using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    // For adding:
    // 1. Balls should collide to each other (You can find an article about that... no more than 5 pages)
    // 2. Investigate where you can use delegates here... (For events like MouseDown, Form1.Resize...)


    public partial class Form1 : Form
    {
        ListBall balls;

        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        int numBalls = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Ball.bordersOfForm(ClientRectangle.Width * 1.0, ClientRectangle.Height * 1.0);
            Ball.timeTickChanged(timer1.Interval);
            balls = new ListBall();
            labelBrojLoptica.Text = "Number of balls: 0";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                label1.Visible = true;
                textBox1.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;

                button1.Text = "Continue";
            }
            else if (button1.Text == "Continue")
            {
                balls.changeVelocity(textBox1.Text, textBox2.Text);

                label1.Visible = false;
                textBox1.Visible = false;
                label2.Visible = false;
                textBox2.Visible = false;

                button1.Text = "Stop";
            }
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            Ball.bordersOfForm(ClientRectangle.Width * 1.0,
                ClientRectangle.Height * 1.0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (balls != null)
                balls.Paint(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bool newBall = balls.ReactionTo_Form1_MouseClick(e);
            if (newBall)
                numBalls++;
            labelBrojLoptica.Text = "Number of balls: " + numBalls;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            balls.ZatvaramListBall();
        }
    }
}
