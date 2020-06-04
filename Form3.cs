using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lil_JIRA
{
    public partial class Form3 : Form
    {
        int user;
        public Form3(int _user)
        {
            user = _user;
            InitializeComponent();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OnFocus3(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
        private void OnFocus4(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }
        private void OnFocus5(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            do
                if (textBox3.Text == "not started" || textBox3.Text == "in work" || textBox3.Text == "done")
                    break;
                else
                {
                    textBox3.Text = "incorrect val";
                    flag = false;
                    break;
                }
            while (false);
            for (int i = 0; i < textBox4.Text.Length; i++)
                if (('0' < textBox4.Text[i] && '9' > textBox4.Text[i]) || textBox4.Text[i] == '.')
                    continue;
                else
                {
                    textBox4.Text = "incorrect val";
                    flag = false;
                    break;
                }
            do
                if (textBox5.Text == "true" || textBox5.Text == "false")
                {
                    break;
                }
                else
                {
                    textBox5.Text = "incorrect val";
                    flag = false;
                    break;
                }
            while (false);
            
            if (flag)
            {
                List<JObject> member_data = new List<JObject>();
                string member_data_string;
                int minLenInd = 0;
                int minLenVal = 0;
                for (int i = 1; i < 4; i++)
                {
                    member_data.Add(JObject.Parse((string)File.ReadAllText("../../data/members/member" + i + ".json")));
                    if (i > 1)
                    {
                        if (member_data[i - 1]["tasks"].Count() < minLenVal)
                        {
                            minLenInd = i;
                            minLenVal = member_data[i - 1]["tasks"].Count();
                        }
                    } 
                    else
                    {
                        minLenInd = i;
                        minLenVal = member_data[i-1]["tasks"].Count();
                    }
                }
                member_data_string = (string)File.ReadAllText("../../data/members/member" + minLenInd + ".json");
                int index = member_data_string.IndexOf(']');
                string newTask = ",{\"taskname\":\"" + (string)textBox1.Text + 
                                 "\",\"descr\":\"" + (string)textBox2.Text + 
                                 "\",\"status\":\"" + (string)textBox3.Text + 
                                 "\",\"time\":\"" + (string)textBox4.Text + 
                                 "\",\"priority\":\"" + (string)textBox5.Text + "\"}";
                member_data_string = member_data_string.Insert(index, newTask);
                StreamWriter file = new StreamWriter("../../data/members/member" + minLenInd + ".json", false, System.Text.Encoding.Default);
                file.Write(member_data_string);
                file.Close();
                Form2 newForm = new Form2(user);
                newForm.Show(this);
                Hide();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(user);
            newForm.Show(this);
            Hide();
        }
    }
}
