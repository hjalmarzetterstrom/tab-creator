using System;
using System.Windows.Forms;

namespace TabCreator
{
    public partial class EditAsTextForm : Form
    {
        public string Tabulature { get; set; }

        public EditAsTextForm(string tab)
        {
            InitializeComponent();
            textBox.Text = tab;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var test = new Sheet(textBox.Text);

                Tabulature = textBox.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("The program was unable to convert back to tabulature. Make sure the text is formatted properly", "Unable to convert");
            }
        }
    }
}
