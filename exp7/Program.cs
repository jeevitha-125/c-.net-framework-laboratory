using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormControls
{
    public class Form1 : Form
    {
        TextBox txtName;
        RadioButton rbMale, rbFemale;
        ComboBox cmbCourse;
        CheckBox cbCSharp, cbPython, cbJava;
        Button btnSubmit;
        Label lblResult;

        public Form1()
        {
            Text = "Windows Form Controls";
            Size = new Size(500, 500);

            Label lblName = new Label();
            lblName.Text = "Name:";
            lblName.Location = new Point(50, 40);
            lblName.AutoSize = true;

            txtName = new TextBox();
            txtName.Location = new Point(150, 40);
            txtName.Width = 200;

            Label lblGender = new Label();
            lblGender.Text = "Gender:";
            lblGender.Location = new Point(50, 90);
            lblGender.AutoSize = true;

            rbMale = new RadioButton();
            rbMale.Text = "Male";
            rbMale.Location = new Point(150, 90);

            rbFemale = new RadioButton();
            rbFemale.Text = "Female";
            rbFemale.Location = new Point(220, 90);

            Label lblCourse = new Label();
            lblCourse.Text = "Course:";
            lblCourse.Location = new Point(50, 140);
            lblCourse.AutoSize = true;

            cmbCourse = new ComboBox();
            cmbCourse.Location = new Point(150, 140);
            cmbCourse.Items.Add("C#");
            cmbCourse.Items.Add("Python");
            cmbCourse.Items.Add("Java");
            cmbCourse.SelectedIndex = 0;

            Label lblSkills = new Label();
            lblSkills.Text = "Skills:";
            lblSkills.Location = new Point(50, 190);
            lblSkills.AutoSize = true;

            cbCSharp = new CheckBox();
            cbCSharp.Text = "C#";
            cbCSharp.Location = new Point(150, 190);

            cbPython = new CheckBox();
            cbPython.Text = "Python";
            cbPython.Location = new Point(150, 220);

            cbJava = new CheckBox();
            cbJava.Text = "Java";
            cbJava.Location = new Point(150, 250);

            btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(150, 290);
            btnSubmit.Click += BtnSubmit_Click;

            lblResult = new Label();
            lblResult.Location = new Point(50, 340);
            lblResult.AutoSize = true;

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblGender);
            Controls.Add(rbMale);
            Controls.Add(rbFemale);
            Controls.Add(lblCourse);
            Controls.Add(cmbCourse);
            Controls.Add(lblSkills);
            Controls.Add(cbCSharp);
            Controls.Add(cbPython);
            Controls.Add(cbJava);
            Controls.Add(btnSubmit);
            Controls.Add(lblResult);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string gender = rbMale.Checked ? "Male" : "Female";

            string skills = "";

            if (cbCSharp.Checked)
                skills += "C# ";

            if (cbPython.Checked)
                skills += "Python ";

            if (cbJava.Checked)
                skills += "Java ";

            lblResult.Text =
                "Name: " + txtName.Text +
                "\nGender: " + gender +
                "\nCourse: " + cmbCourse.Text +
                "\nSkills: " + skills;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}