using System;
using System.Drawing;
using System.Windows.Forms;
namespace 扫雷
{
    public partial class Form1 : Form
    {
        Button[] btn = new Button[144];
        Boolean[] Flag = new Boolean[144];
        int[] Number = new int[144];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int count = 0;
            while (count < 25)
            {
                Random rd = new Random();
                int rand = rd.Next();
                if (!Flag[rand % 144])
                {
                    count++;
                    Flag[rand % 144] = true;
                }
            }
            for (int i = 0; i < 144; i++)
            {
                btn[i] = new Button();
                btn[i].Location = new System.Drawing.Point(10 + 31 * (i % 12), 10 + 31 * (i / 12));
                btn[i].Name = i.ToString();
                btn[i].Size = new System.Drawing.Size(29, 29);
                btn[i].Font = new System.Drawing.Font("微软雅黑", 12F);
                btn[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                Controls.Add(btn[i]);
                btn[i].Text = btn[i].Name;
                if (Flag[i])
                {
                    btn[i].BackColor = Color.Red;
                }
                CheckBomb(i);
            }
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button temp = ((Button)sender);
            if (e.Button == MouseButtons.Left)
            {
                if (temp.Text != "F")
                {
                    if (Flag[int.Parse(temp.Name)])
                    {
                        Application.Restart();
                    }
                    temp.Enabled = false;
                    Find(int.Parse(temp.Name));
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (temp.Text != "F")
                {
                    temp.Text = "F";
                }
                else
                {
                    temp.Text = Number[int.Parse(temp.Name)].ToString();
                }
            }
        }
        private void Find(int i)
        {
            if (Number[i] == 0)
            {

            }
        }
        private void CheckBomb(int i)
        {
            if ((i % 12 == 0) || (i % 12 == 11) || (i > 0 && i < 11) || (i > 132 && i < 143))
            {
                if (i % 12 == 0)
                {
                    int check = 0;
                    if (Flag[i + 1])
                    {
                        check++;
                    }
                    try
                    {
                        if (Flag[i + 12])
                        {
                            check++;
                        }
                        if (Flag[i - 12])
                        {
                            check++;
                        }
                    }
                    catch { }
                    btn[i].Text = check.ToString();
                    Number[i] = check;
                }
                else if (i % 12 == 11)
                {
                    int check = 0;
                    if (Flag[i - 1])
                    {
                        check++;
                    }
                    try
                    {
                        if (Flag[i + 12])
                        {
                            check++;
                        }
                        if (Flag[i - 12])
                        {
                            check++;
                        }
                    }
                    catch { }
                    btn[i].Text = check.ToString();
                    Number[i] = check;
                }
                else if (i > 0 && i < 11)
                {
                    int check = 0;
                    if (Flag[i + 1])
                    {
                        check++;
                    }
                    if (Flag[i - 1])
                    {
                        check++;
                    }
                    if (Flag[i + 12])
                    {
                        check++;
                    }
                    btn[i].Text = check.ToString();
                    Number[i] = check;
                }
                else
                {
                    int check = 0;
                    if (Flag[i + 1])
                    {
                        check++;
                    }
                    if (Flag[i - 1])
                    {
                        check++;
                    }
                    if (Flag[i - 12])
                    {
                        check++;
                    }
                    btn[i].Text = check.ToString();
                    Number[i] = check;
                }
            }
            else
            {
                int check = 0;
                if (Flag[i + 1])
                {
                    check++;
                }
                if (Flag[i - 1])
                {
                    check++;
                }
                if (Flag[i + 12])
                {
                    check++;
                }
                if (Flag[i - 12])
                {
                    check++;
                }
                btn[i].Text = check.ToString();
                Number[i] = check;
            }
        }
    }
}