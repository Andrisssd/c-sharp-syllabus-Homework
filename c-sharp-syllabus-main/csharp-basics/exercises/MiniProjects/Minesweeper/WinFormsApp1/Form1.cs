namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Set();
        }

        private void Set()
        {
            Button tableLayoutPanel = new Button();
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "Hello";
            tableLayoutPanel.Size = new Size(100, 100);
            tableLayoutPanel.TabIndex = 0;
            this.Controls.Add(tableLayoutPanel);

        }
    }
}