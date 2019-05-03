using System;
using System.Linq;
using System.Windows.Forms;

namespace TabCreator
{
    public partial class TuningForm : Form
    {
        public string[] Tuning { get; set; }
        private char[] _acceptedChars;
        private TextBox[] _stringBoxes;
        public TuningForm(string[] tuning)
        {
            InitializeComponent();
            _acceptedChars = "cdefgabhCDEFGABH# ".ToCharArray();
            _stringBoxes = new TextBox[] {
                txtString1,
                txtString2,
                txtString3,
                txtString4,
                txtString5,
                txtString6
            };

            for (int i = 0; i < 6; i++)
            {
                _stringBoxes[i].Text = tuning[i];
            }

            UpdatePreview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool invalidTuning = _stringBoxes.Any(x =>
                x.Text.Length < 1 ||
                x.Text.Except(_acceptedChars).Count() > 0 ||
                x.Text.Length > 2);
            bool sharpOrFlat = _stringBoxes.Any(x =>
                x.Text.Trim().Length == 2);

            if (invalidTuning)
            {
                MessageBox.Show("Invalid tuning.", "Try again.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                this.Tuning = _stringBoxes.Select(x => x.Text.Trim(' ')).ToArray();
                if (sharpOrFlat)
                    for (int i = 0; i < 6; i++)
                        if (this.Tuning[i].Length < 2)
                            this.Tuning[i] += " ";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            txtPreview.Text = String.Join("|\r\n", _stringBoxes.Select(x => x.Text).ToArray()) + "|";
        }
    }
}
