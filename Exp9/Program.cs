using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
    public MainForm()
    {
        Text = "MDI Application";
        Size = new Size(700, 500);
        IsMdiContainer = true;

        MenuStrip menu = new MenuStrip();
        ToolStripMenuItem file = new ToolStripMenuItem("File");
        ToolStripMenuItem newForm = new ToolStripMenuItem("New");
        ToolStripMenuItem dialog = new ToolStripMenuItem("Custom Dialog");
        ToolStripMenuItem exit = new ToolStripMenuItem("Exit");

        newForm.Click += (s, e) =>
        {
            Form f = new Form
            {
                Text = "Child Form",
                Size = new Size(300, 200),
                MdiParent = this
            };
            f.Show();
        };

        dialog.Click += (s, e) =>
        {
            Form d = new Form
            {
                Text = "Custom Dialog",
                Size = new Size(300, 180)
            };

            TextBox t = new TextBox
            {
                Location = new Point(30, 40),
                Width = 200
            };

            Button b = new Button
            {
                Text = "OK",
                Location = new Point(30, 80)
            };

            d.Controls.Add(new Label
            {
                Text = "Enter Name:",
                Location = new Point(30, 15)
            });

            d.Controls.Add(t);
            d.Controls.Add(b);

            b.Click += (x, y) =>
            {
                MessageBox.Show("Hello " + t.Text);
                d.Close();
            };

            d.ShowDialog();
        };

        exit.Click += (s, e) => Close();

        file.DropDownItems.AddRange(
            new ToolStripItem[] { newForm, dialog, exit });

        menu.Items.Add(file);
        Controls.Add(menu);
        MainMenuStrip = menu;
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}