using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TabCreator
{
    class QueueSheetPanel : Panel
    {
        struct Range
        {
            public int Start { get; set; }
            public int End { get; set; }

            public bool isBetween(int value)
            {
                return value >= Start && value < End;
            }

            public int ToPointY()
            {
                return (int)new int[] { Start, End }.Average();
            }

            public override string ToString()
            {
                return String.Format("{0} to {1}", Start, End);
            }
        }

        private System.Windows.Forms.RadioButton radioSharp;
        private System.Windows.Forms.RadioButton radioFlat;
        private System.Windows.Forms.RadioButton radioNatural;
        List<PictureBox> notes;
        Dictionary<int, string> YToNote;
        Dictionary<Range, NoteShape> YToShape;
        Dictionary<Range, int> coordinateToY;
        Dictionary<NoteAccidental, string> accidentalToSymbol;
        string[] possibleNotes;
        int nextX;
        int lastX;

        public Queue<Note> NoteQueue { get; set; }

        public event EventHandler<NoteEventArgs> CurrentNoteChanged;

        public QueueSheetPanel()
            : base()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.radioSharp = new System.Windows.Forms.RadioButton();
            this.radioFlat = new System.Windows.Forms.RadioButton();
            this.radioNatural = new System.Windows.Forms.RadioButton();

            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = (Image)new Bitmap(@"..\..\Images\blanksheet.png");
            this.BackgroundImageLayout = ImageLayout.Center;
            this.Controls.Add(this.radioSharp);
            this.Controls.Add(this.radioFlat);
            this.Controls.Add(this.radioNatural);
            this.Size = new System.Drawing.Size(931, 120);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormSheetMusic_MouseClick);
            this.radioSharp.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioSharp.BackgroundImage = (Image)new Bitmap(@"..\..\Images\sharp.png");
            this.radioSharp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.radioSharp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.radioSharp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.radioSharp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioSharp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioSharp.Location = new System.Drawing.Point(900, 72);
            this.radioSharp.Size = new System.Drawing.Size(23, 23);
            this.radioFlat.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioFlat.BackgroundImage = (Image)new Bitmap(@"..\..\Images\flat.png");
            this.radioFlat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioFlat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.radioFlat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.radioFlat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioFlat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioFlat.Location = new System.Drawing.Point(900, 26);
            this.radioFlat.Size = new System.Drawing.Size(23, 23);
            this.radioNatural.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioNatural.BackgroundImage = (Image)new Bitmap(@"..\..\Images\natural.png");
            this.radioNatural.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioNatural.Checked = true;
            this.radioNatural.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.radioNatural.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.radioNatural.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioNatural.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioNatural.Location = new System.Drawing.Point(900, 49);
            this.radioNatural.Size = new System.Drawing.Size(23, 23);

            notes = new List<PictureBox>();
            coordinateToY = new Dictionary<Range, int>();
            YToNote = new Dictionary<int, string>();
            YToShape = new Dictionary<Range, NoteShape>();
            accidentalToSymbol = new Dictionary<NoteAccidental, string>();
            NoteQueue = new Queue<Note>();
            nextX = 100;
            lastX = 100;
            possibleNotes = "E Eb Db D D# C C# Bb B Ab A A# Gb G G# F F#".Split(' ');

            string[] pitches = "E D C B A G F E D C B A G F E D C B A G F E".Split(' ');
            for (int coordinate = 10, i = 0; coordinate <= 115; coordinate += 5, i++)
            {
                YToNote.Add(coordinate, pitches[i]);
                coordinateToY.Add(new Range() { Start = coordinate - 2, End = coordinate + 3 }, coordinate);
            }

            YToShape.Add(new Range() { Start = 0, End = 35 }, NoteShape.UpsideDownStrikeThrough);
            YToShape.Add(new Range() { Start = 35, End = 60 }, NoteShape.UpsideDown);
            YToShape.Add(new Range() { Start = 60, End = 90 }, NoteShape.Normal);
            YToShape.Add(new Range() { Start = 90, End = 999 }, NoteShape.NormalStrikeThrough);

            accidentalToSymbol.Add(NoteAccidental.Sharp, "#");
            accidentalToSymbol.Add(NoteAccidental.Flat, "b");
            accidentalToSymbol.Add(NoteAccidental.Natural, "");

            CurrentNoteChanged += ((sender, e) => System.Diagnostics.Debug.Print(this.Name + ": Current note changed to " + e.Pitch));
        }

        private void FormSheetMusic_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    AddNoteOnMousePosition(e);
                    break;
                case MouseButtons.Right:
                    if (this.Controls.Count > 3)
                    {
                        DequeueLastNote();
                    }
                    break;
            }
        }

        public void DequeueNote()
        {
            NoteQueue.Dequeue();

            if (NoteQueue.Any())
                CurrentNoteChanged(this, new NoteEventArgs(NoteQueue.Peek().ToString()));

            DeleteFirstDrawnNote();

            if (!NoteQueue.Any())
                Clear();
        }

        private void DeleteFirstDrawnNote()
        {
            if (this.Controls[3] is Accidental)
                this.Controls.RemoveAt(3);
            this.Controls.RemoveAt(3);
        }

        private void DeleteLastDrawnNote()
        {
            if (this.Controls[this.Controls.Count - 2] is Accidental)
            {
                this.Controls.RemoveAt(this.Controls.Count - 1);
                nextX -= 10;
                lastX -= 10;
            }

            this.Controls.RemoveAt(this.Controls.Count - 1);
            nextX -= 25;
            lastX -= 25;
        }

        public void DequeueLastNote()
        {
            DeleteLastQueuedNote();
            DeleteLastDrawnNote();

            if (!NoteQueue.Any())
                Clear();
        }

        private void DeleteLastQueuedNote()
        {
            var temp = new Queue<Note>();
            var newCount = NoteQueue.Count - 1;

            for (int i = 0; i < newCount; i++)
                temp.Enqueue(NoteQueue.Dequeue());

            NoteQueue = temp;
        }

        private void AddNoteOnMousePosition(MouseEventArgs e)
        {
            if (lastX < 870 && coordinateToY.Any(x => x.Key.isBetween(e.Y)))
            {
                var Y = coordinateToY.Single(x => x.Key.isBetween(e.Y)).Value;
                var shape = YToShape.Single(x => x.Key.isBetween(Y)).Value;
                var accidental = GetAccidental();
                var pitch = new StringBuilder(YToNote[Y]);
                var imagePosition = new Point(nextX, Y - 10);
                var newNote = new Note(pitch.ToString(), accidental);

                pitch.Append(accidentalToSymbol[accidental]);
                if (possibleNotes.Contains(pitch.ToString()))
                {
                    imagePosition = AddAccidental(accidental, imagePosition);

                    if (!NoteQueue.Any()) //First note.
                        CurrentNoteChanged(this, new NoteEventArgs(pitch.ToString()));
                    Y -= (int)shape % 2 == 0 ? 30 : 5; //Reposition image for note.

                    imagePosition = new Point(nextX, Y);
                    newNote.Draw(imagePosition, shape);

                    this.Controls.Add(newNote);
                    NoteQueue.Enqueue(newNote);
                    nextX += 25;
                }
            }
        }

        private Point AddAccidental(NoteAccidental accidental, Point imagePosition)
        {
            switch (accidental)
            {
                case NoteAccidental.Flat:
                    imagePosition.Y -= 5;
                    var newAccidental = new Accidental(imagePosition, accidental);
                    this.Controls.Add(newAccidental);
                    nextX += 10;
                    break;
                case NoteAccidental.Sharp:
                    newAccidental = new Accidental(imagePosition, accidental);
                    this.Controls.Add(newAccidental);
                    nextX += 10;
                    break;
            }
            return imagePosition;
        }

        public void Clear()
        {
            NoteQueue.Clear();
            for (int i = 3; i < this.Controls.Count; i++)
            {
                this.Controls.RemoveAt(3);
            }
            nextX = 100;
            lastX = 100;
        }

        private NoteAccidental GetAccidental()
        {
            var accidental = NoteAccidental.Natural;
            if (radioFlat.Checked)
                accidental = NoteAccidental.Flat;
            if (radioSharp.Checked)
                accidental = NoteAccidental.Sharp;
            return accidental;
        }
    }
}
