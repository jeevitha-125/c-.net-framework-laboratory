using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
    TextBox name = new(), email = new(), phone = new();
    TextBox password = new(), age = new(), address = new();
    ComboBox gender = new(), country = new();
    CheckBox terms = new();
    Label status = new();

    public MainForm()
    {
        Text = "User Registration";
        Size = new Size(650, 650);
        BackColor = Color.DarkSlateGray;
        ForeColor = Color.White;

        Add("Name", name, 50);
        Add("Email", email, 100);
        Add("Phone", phone, 150);
        Add("Password", password, 200);
        password.UseSystemPasswordChar = true;
        Add("Age", age, 250);
        Add("Gender", gender, 300);
        gender.Items.AddRange(new[] { "Male", "Female", "Other" });
        Add("Country", country, 350);
        country.Items.AddRange(new[] { "India", "USA", "UK", "Canada", "Australia" });
        Add("Address", address, 400);
        address.Multiline = true;
        address.Height = 50;

        terms.Text = "I agree to the terms";
        terms.Location = new Point(180, 470);
        Controls.Add(terms);

        Button reg = Btn("Register", 180, 510);
        reg.Click += Register;

        Button clear = Btn("Clear", 330, 510);
        clear.Click += Clear;

        status.Location = new Point(50, 570);
        status.Size = new Size(550, 30);
        Controls.Add(status);
    }

    void Add(string text, Control c, int y)
    {
        Controls.Add(new Label {
            Text = text,
            Location = new Point(50, y + 5),
            Size = new Size(100, 25)
        });

        c.Location = new Point(180, y);
        c.Size = new Size(380, 30);
        Controls.Add(c);
    }

    Button Btn(string text, int x, int y)
    {
        Button b = new() {
            Text = text,
            Location = new Point(x, y),
            Size = new Size(120, 40)
        };
        Controls.Add(b);
        return b;
    }

    void Register(object? s, EventArgs e)
    {
        if (name.Text == "" || email.Text == "" || phone.Text == "" ||
            password.Text == "" || age.Text == "" || address.Text == "")
        {
            Error("Please fill all fields.");
            return;
        }

        if (!int.TryParse(age.Text, out int a) || a < 1 || a > 120)
        {
            Error("Enter a valid age.");
            return;
        }

        if (gender.SelectedIndex < 0 || country.SelectedIndex < 0)
        {
            Error("Select gender and country.");
            return;
        }

        if (!terms.Checked)
        {
            Error("Accept the terms.");
            return;
        }

        status.ForeColor = Color.LightGreen;
        status.Text = "Registration successful!";
        MessageBox.Show("Registration successful!\nWelcome " + name.Text);
    }

    void Clear(object? s, EventArgs e)
    {
        foreach (Control c in new Control[]
            { name, email, phone, password, age, address })
            c.Text = "";

        gender.SelectedIndex = -1;
        country.SelectedIndex = -1;
        terms.Checked = false;
        status.Text = "";
    }

    void Error(string msg)
    {
        status.ForeColor = Color.LightCoral;
        status.Text = msg;
        MessageBox.Show(msg);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}