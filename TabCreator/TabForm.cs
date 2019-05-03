using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TabCreator
{
    public partial class TabForm : Form
    {
        private Sheet _sheet;
        private string[] _tuning;
        private ToolStripTextBox[] _stringBoxes;
        private TextBox[] _tabBoxes;
        private Dictionary<string, Sort> _toSortEnum;
        private Sort _currentSorting;
        private SetForm _addXForm;
        private SetForm _changeSpacing;
        private QueueSheetPanel _queueSheet;
        private string _currentNote;
        private int _currentSpacing;
        private string _filePath;
        private int _argbValueOfInfoLabel;
        private List<string> _history;

        public TabForm()
        {
            InitializeComponent();
            InitializeMoreComponents();
        }

        private void InitializeMoreComponents()
        {
            MainMenuStrip.Items.Insert(2, new ToolStripSeparator());
            MainMenuStrip.Items.Insert(5, new ToolStripSeparator());
            _queueSheet = new QueueSheetPanel();
            _queueSheet.Location = SheetPlaceHolder.Location;
            _queueSheet.Anchor = AnchorStyles.None;
            _queueSheet.CurrentNoteChanged += queueSheet_CurrentNoteChanged;
            _queueSheet.MouseEnter += Queue_MouseEnter;
            _queueSheet.MouseLeave += _queueSheet_MouseLeave;
            SheetPlaceHolder.Dispose();
            splitContainer4.Panel2.Controls.Add(_queueSheet);

            _history = new List<string>();
            _tuning = new string[] { "e", "B", "G", "D", "A", "E" };
            _sheet = new Sheet(_tuning);
            UpdateTab();
            _currentSorting = Sort.Octaves;
            _addXForm = new SetForm();
            _currentSpacing = 2;
            _changeSpacing = new SetForm() { X = _currentSpacing };

            _stringBoxes = new ToolStripTextBox[] {
                toolStripELowString,
                toolStripBString,
                toolStripGString,
                toolStripDString,
                toolStripAString,
                toolStripEString
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

        private void AddToTab()
        {
            _sheet.AddTab(_currentSpacing, ReadStringsAndFrets());
            UpdateTab();

            DequeueFromQueue();
        }

        private void AddToTab(int numberOfEntries)
        {
            _sheet.AddTab(_currentSpacing, numberOfEntries, ReadStringsAndFrets());
            UpdateTab();

            DequeueFromQueue();
        }

        private void DequeueFromQueue()
        {
            if (listNotes.SelectedItem == null && _queueSheet.NoteQueue.Any())
                _queueSheet.DequeueNote();

            ResetTextBoxes();
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

        private void ResetTextBoxes()
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

        private void BackspaceTab()
        {
            _sheet.Backspace();
            UpdateTab();
        }

        private void listNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                EnableTabControls();
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
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var send = sender as RadioButton;
            _currentSorting = _toSortEnum[send.Text];
            LoadTabs(_toSortEnum[send.Text]);
        }

        private void Save()
        {
            if (!File.Exists(_filePath))
            {
                SaveAs();
            }
            else
            {
                Save(_filePath);
            }
        }

        private void Save(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    var sheet = _sheet.ToString();
                    writer.Write(sheet);
                }
            }
        }

        private void SaveAs()
        {
            if (DialogResult.OK == saveTabDialog.ShowDialog())
            {
                Save(saveTabDialog.FileName);
                _filePath = saveTabDialog.FileName;
            }
        }

        private void contextMenuItem_Click(object sender, EventArgs e)
        {
            var send = sender as ToolStripItem;
            switch (send.Name)
            {
                case "cItemClear":
                case "cItemNew":
                    if (DialogResult.Yes == MessageBox.Show("This will erase all your tabs, are you sure?\r\n\nThis action is irreversable.", "Clear canvas?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        _sheet = new Sheet(_tuning);
                        UpdateTab();
                    }
                    break;
                case "cItemRow":
                case "cItemRow2":
                    AddNewRow();
                    break;
                case "cItemBarLine":
                case "cItemBarLine2":
                    AddSplitter();
                    break;
                case "cItemBack":
                    BackspaceTab();
                    break;
                case "cItemTuning":
                case "cItemTuning2":
                    ChangeTuning();
                    break;
                case "cItemSave":
                case "cItemSave2":
                    Save();
                    break;
                case "cItemSaveAs":
                    SaveAs();
                    break;
                case "cItemExit":
                    this.Close();
                    break;
                case "cItemSpacing":
                    ChangeSpacing();
                    break;
                case "cItemEdit":
                case "cItemEdit2":
                    EditAsText();
                    break;
                case "cItemOpen":
                    OpenFile();
                    break;
                case "cItemUndo":
                case "cItemUndo2":
                    _sheet.Undo();
                    UpdateTab();
                    break;
            }
        }

        private void OpenFile()
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                try
                {
                    using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    using (StreamReader reader = new StreamReader(stream))
                        _sheet = new Sheet(reader.ReadToEnd());

                    _filePath = openFileDialog.FileName;
                    UpdateTab();
                }
                catch
                {
                    MessageBox.Show("The file you tried to open can't be converted to tabulature.", "Unable to convert.");
                }

            }
        }

        private void EditAsText()
        {
            EditAsTextForm formTextEditor = new EditAsTextForm(txtTabSheet.Text);
            if (DialogResult.OK == formTextEditor.ShowDialog())
            {
                _sheet = new Sheet(formTextEditor.Tabulature);
                UpdateTab();
            }
        }

        private void ChangeSpacing()
        {
            this.Enabled = false;
            if (_changeSpacing.ShowDialog() == DialogResult.OK && _changeSpacing.X >= 0)
            {
                _currentSpacing = _changeSpacing.X;
            }
            this.Enabled = true;
        }

        private void ChangeTuning()
        {
            TuningForm form = new TuningForm(this._tuning);
            this.Enabled = false;
            if (DialogResult.OK == form.ShowDialog())
            {
                this._tuning = form.Tuning;
                _sheet.Tuning = form.Tuning;
                _sheet.UpdateTuning();
                txtTabSheet.Text = _sheet.ToString();
                //lblTuning.Text = String.Join("\r\n", form.Tuning); TODO
            }
            this.Enabled = true;
        }

        private void cItemAdd_Click(object sender, EventArgs e)
        {
            var send = sender as ToolStripItem;

            bool sourceIsTextBox = send.Owner is ContextMenuStrip;
            TextBox box = null;
            int entries = 0;
            if (sourceIsTextBox)
            {
                box = _tabBoxes.FirstOrDefault(x => (send.Owner as ContextMenuStrip).SourceControl == x);
                AddToStringBoxes(box);
            }

            if (box != null || !sourceIsTextBox)
            {
                switch (send.Text.Last())
                {
                    case '1':
                        entries = 1;
                        break;
                    case '4':
                        entries = 4;
                        break;
                    case '8':
                        entries = 8;
                        break;
                    case '6':
                        entries = 16;
                        break;
                    case 'X':
                        if (sourceIsTextBox)
                            AddXToTab(box);
                        else
                            AddXToTab();
                        return;
                }
                if (entries > 0)
                {
                    AddToTab(entries);
                    UpdateTab();
                }
            }
        }

        private void AddXToTab(TextBox sender)
        {
            this.Enabled = false;
            if (_addXForm.ShowDialog() == DialogResult.OK && _addXForm.X > 0)
            {
                AddToStringBoxes(sender);
                AddToTab(_addXForm.X);
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

        private void timerBackspacer_Tick(object sender, EventArgs e)
        {
            BackspaceTab();
            timerBackspacer.Interval = 20;
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    BackspaceTab();
                    timerBackspacer.Interval = 1000;
                    timerBackspacer.Start();
                    break;
                case Keys.Return:
                    AddNewRow();
                    break;
            }
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                timerBackspacer.Stop();
        }

        private void toolStripELowString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                AddToTab();
                e.Handled = e.SuppressKeyPress = true;
            }


        }

        private void Queue_MouseEnter(object sender, EventArgs e)
        {
            _argbValueOfInfoLabel = 255;
            timerFader.Start();
        }

        void _queueSheet_MouseLeave(object sender, EventArgs e)
        {
            timerFader.Stop();
            label1.ForeColor = Color.White;
        }

        private void timerFader_Tick(object sender, EventArgs e)
        {
            if (_argbValueOfInfoLabel > 0)
            {
                label1.ForeColor = Color.FromArgb(_argbValueOfInfoLabel -= 15, _argbValueOfInfoLabel, _argbValueOfInfoLabel, _argbValueOfInfoLabel);
                label1.Update();
            }
            else
            {
                timerFader.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
