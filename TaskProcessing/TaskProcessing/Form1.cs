namespace TaskProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            await Task.Run(Count);
            MessageBox.Show("Bitti");
        }

        Task Count()
        {
            for (int i = 0; i < 5000; i++)
            {
                label1.Text = i.ToString();
            }

            return Task.CompletedTask;
            
        }
    }
}