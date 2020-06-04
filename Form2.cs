using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TeamNamespace;

namespace lil_JIRA
{
    public partial class Form2 : Form
    {
        Team team;
        List<int> left = new List<int>();
        int user;
        public Form2(int _user)
        {
            user = _user;
            InitializeComponent(_user);
            left.Add(this.label4.Left);
            left.Add(this.label7.Left);
            left.Add(this.label11.Left);
            team = new Team(left[0], left[1], left[2]);
            team.FillInMemberData();
            FillInTasks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FillInTasks()
        {
            int counterTask, counterContinue;
            for (int i = 0; i < team.GetMemberCount(); i++)
                for (int j = 0; j < team.GetMemberTaskCount(i); j++)
                {
                    counterTask = team.GetMemberTaskCount(i);
                    counterContinue = 3 - counterTask;
                    for (int k = 0; k < this.Controls.Count; k++)
                        if (counterContinue != 0)
                        {
                            counterContinue--;
                            continue;
                        }
                        else
                        {
                            if (this.Controls[k].Left == left[i])
                            {
                                this.Controls[k].Text = team.GetMemberTaskText(i, counterTask - 1);
                                this.Controls[k].Width = 200;
                                this.Controls[k].Height = 100;
                                this.Controls[k].Visible = true;
                                if (team.GetMemberTaskPriority(i, counterTask - 1))
                                    this.Controls[k].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                else
                                    this.Controls[k].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                                counterTask--;
                                this.Controls[k].Top = 96 + 114 * counterTask;
                            }
                            if (counterTask == 0)
                                break;
                        }
                }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4(user);
            newForm.Show(this);
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(user);
            newForm.Show(this);
            Hide();
        }
    }
}
