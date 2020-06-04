using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lil_JIRA
{
    public partial class Form4 : Form
    {
        private int user;
        public Form4(int _user)
        {
            user = _user;
            InitializeComponent();
        }

        private void OnFocus1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void OnFocus2(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = true;
            JObject member = JObject.Parse((string)File.ReadAllText("../../data/members/member" + user + ".json"));
            
            try
            {
                if (textBox1.Text[0] > '0' && textBox1.Text[0] < '9')
                {
                    if (member["tasks"].Count() < int.Parse(textBox1.Text))
                        throw new ArgumentException("incorrect val");
                }
                else
                    throw new ArgumentException("incorrect val");
            }
            catch (ArgumentException)
            {
                textBox1.Text = "incorrect val";
                flag = false;
            }
                
            try
            {
                do
                {
                    if (textBox2.Text == "not started" || textBox2.Text == "in work" || textBox2.Text == "done")
                        break;
                    else
                        throw new ArgumentException("incorrect val");
                } while (false);
            }
            catch (ArgumentException)
            {
                textBox2.Text = "incorrect val";
                flag = false;
            }

            if (flag)
            {
                member["tasks"][int.Parse(textBox1.Text) - 1]["status"] = textBox2.Text;
                StreamWriter file = new StreamWriter("../../data/members/member" + user + ".json", false, System.Text.Encoding.Default);
                file.Write(JsonConvert.SerializeObject(member));
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
