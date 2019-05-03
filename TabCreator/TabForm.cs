using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace TabCreator
{
    public partial class TabForm : Form
    {
        private Sheet _sheet;
        private string[] _tuning;
        private TextBox[] _stringBoxes;
        private TextBox[] _tabBoxes;
        private Dictionary<string, Sort> _toSortEnum;
        private Sort _currentSorting;
        private AddForm _addXForm;
        private QueueSheetPanel _queueSheet;
        private string _currentNote;

        public TabForm()
        {
            InitializeComponent();
            InitializeMoreComponents();
        }

        private void InitializeMoreComponents()
        {
            SheetPlaceHolder.Dispose();
            _queueSheet = new QueueSheetPanel();
            _queueSheet.Location = new System.Drawing.Point(6, 233);
            _queueSheet.BorderStyle = BorderStyle.FixedSingle;
            _queueSheet.Anchor = ((AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left));
            _queueSheet.CurrentNoteChanged += queueSheet_CurrentNoteChanged;
            tabGenerateTab.Controls.Add(_queueSheet);

            _tuning = new string[] { "e", "B", "G", "D", "A", "E" };
            _sheet = new Sheet(_tuning);
            _currentSorting = Sort.Octaves;
            _addXForm = new AddForm();
            _stringBoxes = new TextBox[] {
                txtELowString,
                txtBString,
                txtGString,
                txtDString,
                txtAString,
                txtEString
            };
            _tabBoxes = new TextBox[] {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10,
                textBox11,
                textBox12,
                textBox13,
                textBox14,
            };

            _toSortEnum = new Dictionary<string, Sort>(){
                {"Octaves", Sort.Octaves},
                {"Frets", Sort.Frets},
                {"Strings", Sort.Strings}
            };
        }

        void queueSheet_CurrentNoteChanged(object sender, NoteEventArgs e)
        {
            _currentNote = e.Pitch;
            LoadTabs(_currentSorting);
            listNotes.SelectedItem = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddToTab();
        }

        private void AddToTab()
        {
            _sheet.AddTab((int)numSpace.Value, ReadStringsAndFrets());
            UpdateTab();

            if (listNotes.SelectedItem == null && _queueSheet.NoteQueue.Any())
                _queueSheet.DequeueNote();
        }

        private void AddToTab(int numberOfEntries)
        {
            _sheet.AddTab((int)numSpace.Value, numberOfEntries, ReadStringsAndFrets());
            UpdateTab();

            if (listNotes.SelectedItem == null && _queueSheet.NoteQueue.Any())
                _queueSheet.DequeueNote();
        }

        private void UpdateTab()
        {
            txtTabSheet.Text = _sheet.ToString();
            txtTabSheet.SelectionStart = txtTabSheet.Text.Length;
            txtTabSheet.ScrollToCaret();
        }

        private TabNote[] ReadStringsAndFrets()
        {
            List<TabNote> tabs = new List<TabNote>();

            for (int str = 0; str < 6; str++)
            {
                tabs.Add(new TabNote(str, _stringBoxes[str].Text));
            }

            return tabs.ToArray();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var item in _stringBoxes)
            {
                item.Text = "-";
            }
        }

        private void btnNewRow_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        private void AddNewRow()
        {
            _sheet.NewRow();
            UpdateTab();
        }

        private void btnAddSplit_Click(object sender, EventArgs e)
        {
            AddSplitter();
        }

        private void AddSplitter()
        {
            _sheet.AddSplitter();
            UpdateTab();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void Undo()
        {
            _sheet.Undo();
            UpdateTab();
        }

        private void listNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                tableLayoutPanel1.Enabled = true;
                radioOctaves.Enabled = true;
                radioFrets.Enabled = true;
                radioStrings.Enabled = true;
                _currentNote = listNotes.SelectedItem.ToString();
                LoadTabs(_currentSorting);
            }
        }

        private void LoadTabs(Sort sort)
        {
            EnableTabControls();

            TabNote[] notes;
            var generatedtabs = _sheet.GenerateFromNote(_currentNote, sort, out notes);

            int minFret = 1;
            int maxFret = 24;

            int.TryParse(txtStartFret.Text, out minFret);
            int.TryParse(txtEndFret.Text, out maxFret);
            tableLayoutPanel1.Enabled = true;

            foreach (var box in _tabBoxes.Reverse().Take(14 - generatedtabs.Count))
            {
                box.Visible = false;
            }

            UpdateTabOptions(notes, generatedtabs, minFret, maxFret);
        }

        private void UpdateTabOptions(TabNote[] notes, List<TabulatureRow> generatedtabs, int minFret, int maxFret)
        {
            for (int i = 0, j = 0; i < generatedtabs.Count; i++)
            {
                int currentFret = int.Parse(notes[i].Input);
                bool withinSetFrets =
                    currentFret <= maxFret &&
                    currentFret >= minFret ||
                    chOpenStrings.Checked && currentFret == 0;

                if (withinSetFrets)
                {
                    _tabBoxes[j].Visible = true;
                    _tabBoxes[j].Text = generatedtabs[i].ToString();
                    j++;
                }
            }
        }

        private void EnableTabControls()
        {
            tableLayoutPanel1.Enabled = true;
            radioOctaves.Enabled = true;
            radioFrets.Enabled = true;
            radioStrings.Enabled = true;
        }

        private void textBox_MouseClick(object sender, MouseEventArgs e)
        {
            var send = sender as TextBox;

            AddToStringBoxes(send);

            if (chDirectAdd.Checked)
                AddToTab();

        }

        private void AddToStringBoxes(TextBox sender)
        {
            for (int i = 0; i < 6; i++)
            {
                int fret = 0;
                if (int.TryParse(new String(sender.Lines[i].Skip(2).ToArray()), out fret))
                    _stringBoxes[i].Text = fret.ToString();
                else
                    _stringBoxes[i].Text = "-";
            }

            btnAdd.Focus();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var send = sender as RadioButton;
            _currentSorting = _toSortEnum[send.Text];
            LoadTabs(_toSortEnum[send.Text]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PromptSave();
        }

        private void PromptSave()
        {
            if (DialogResult.OK == saveTabDialog.ShowDialog())
            {
                using (FileStream stream = new FileStream(saveTabDialog.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        var sheet = _sheet.ToString();
                        writer.Write(sheet);
                    }
                }
            }
        }

        private void cItemCanvas_Click(object sender, EventArgs e)
        {
            var send = sender as ToolStripItem;
            switch (send.Name)
            {
                case "cItemClear":
                    if (DialogResult.Yes == MessageBox.Show("This will erase all your tabs, are you sure?\r\n\nThis action is irreversable.", "Clear canvas?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        _sheet = new Sheet(_tuning);
                        UpdateTab();
                    }
                    break;
                case "cItemNewRow":
                    AddNewRow();
                    break;
                case "cItemAddSplitter":
                    AddSplitter();
                    break;
                case "cItemUndo":
                    Undo();
                    break;
                case "cItemTuning":
                    ChangeTuning();
                    break;
                case "cItemSave":
                    PromptSave();
                    return;

            }
        }

        private void lblInfo_DoubleClick(object sender, EventArgs e)
        {
            ChangeTuning();
        }

        private void ChangeTuning()
        {
            TuningForm form = new TuningForm(this._tuning);
            this.Enabled = false;
            if (DialogResult.OK == form.ShowDialog())
            {
                this._tuning = form.Tuning;
                _sheet.Tuning = form.Tuning;
                lblTuning.Text = String.Join("\r\n", form.Tuning);
            }
            this.Enabled = true;
        }

        private void cItemAdd_Click(object sender, EventArgs e)
        {
            var send = sender as ToolStripItem;
            var box = _tabBoxes.FirstOrDefault(x => (send.Owner as ContextMenuStrip).SourceControl == x);
            int entries = 0;

            if (box != null)
            {
                switch (send.Name)
                {
                    case "cItem1":
                        entries = 1;
                        break;
                    case "cItem4":
                        entries = 4;
                        break;
                    case "cItem8":
                        entries = 8;
                        break;
                    case "cItem16":
                        entries = 16;
                        break;
                    case "cItemX":
                        AddXToTab(box);
                        return;
                }
                if (entries > 0)
                {
                    AddToStringBoxes(box);
                    AddToTab(entries);
                    UpdateTab();
                }
            }
        }

        private void AddXToTab(TextBox sender)
        {
            AddForm addx = new AddForm();
            this.Enabled = false;
            if (addx.ShowDialog() == DialogResult.OK)
            {
                AddToStringBoxes(sender);
                AddToTab(addx.X);
                UpdateTab();
            }
            this.Enabled = true;
        }

        private void AddXToTab()
        {
            this.Enabled = false;
            if (_addXForm.ShowDialog() == DialogResult.OK && _addXForm.X > 0)
            {
                AddToTab(_addXForm.X);
                UpdateTab();
            }
            this.Enabled = true;
        }

        private void btnAddX_Click(object sender, EventArgs e)
        {
            AddXToTab();
        }

        private void cItemTuning_Click(object sender, EventArgs e)
        {
            ChangeTuning();
        }
    }
}
