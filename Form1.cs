using System;
using System.Windows.Forms;
using LoginNamespace;

namespace lil_JIRA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void OnFocusPassword(object sender, EventArgs e)
        {
            PasswordTextBox.ForeColor = System.Drawing.SystemColors.Control;
            if (PasswordTextBox.Text == "Enter your password")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.PasswordChar = '•';
            }
        }
        private void OnDefocusPassword(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.PasswordChar = '\0';
                PasswordTextBox.Text = "Enter your password";
            }
        }
        private void OnFocusLogin(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.SystemColors.Control;
            if (textBox1.Text == "Enter your login")
                textBox1.Text = "";
        }
        private void OnDefocusLogin(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = "Enter your login";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int user = 0;
            char res = Login.CheckPassword(textBox1.Text, PasswordTextBox.Text, ref user);
            if (res == 'p')
                PasswordTextBox.ForeColor = System.Drawing.Color.Red;
            else
            if (res == 'l')
                textBox1.ForeColor = System.Drawing.Color.Red;
            else
            if (res == 'a')
            {
                PasswordTextBox.ForeColor = System.Drawing.Color.Red;
                textBox1.ForeColor = System.Drawing.Color.Red;
            }
            else
            if (res == 'e')
            {
                Form2 newForm = new Form2(user);
                newForm.Show(this);
                Hide();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
