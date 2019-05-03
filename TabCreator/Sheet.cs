using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace TabCreator
{
    public class Sheet
    {
        private const int FRET_COUNT = 24;
        private const int CHROMATIC_COUNT = 12;

        public List<TabulatureRow> Rows { get; set; }
        public string[] Tuning { get; set; }

        public readonly Dictionary<string, TabNote[]> FretboardMap = TabNote.GetFretboardMap();

        private List<int> _history;

        public TabulatureRow this[int index]
        {
            get
            {
                return Rows[index];
            }
            set
            {
                Rows[index] = value;
            }
        }

        public Sheet(string[] tuning)
        {
            _history = new List<int>();
            this.Tuning = tuning;
            this.Rows = new List<TabulatureRow>();
            this.Rows.Add(new TabulatureRow(Tuning));
        }

        public Sheet(string sheet)
        {
            _history = new List<int>();
            this.Rows = new List<TabulatureRow>();
            sheet = sheet.TrimEnd('\r', '\n');
            var splitIntoTabRows = sheet.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in splitIntoTabRows)
            {
                var splitIntoSingleLines = row.Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                Rows.Add(new TabulatureRow(row));
            }
            Tuning = Rows.Last().Tabulature.Select(x => new string(x.TakeWhile(t => t != '|').ToArray())).ToArray();
        }

        public void NewRow()
        {
            _history.Add(1);
            Rows.Add(new TabulatureRow(Tuning));
        }

        public void AddTab(int space, params TabNote[] notes)
        {
            _history.Add(Rows.Last().Add(space, notes));
        }

        public void AddTab(int space, int numberOfEntries, params TabNote[] notes)
        {
            _history.Add(Rows.Last().Add(space, numberOfEntries, notes));
        }

        public void AddSplitter()
        {
            _history.Add(1);
            Rows.Last().AddSplitter();
        }

        public void Backspace()
        {
            _history.Clear();
            if (Rows.Last().Length == 2 && Rows.Count > 1)
                Rows.Remove(Rows.Last());
            else
                Rows.Last().Backspace();
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                for (int i = 0; i < _history.Last(); i++)
                {
                    if (Rows.Last().Length == 2 && Rows.Count > 1)
                        Rows.Remove(Rows.Last());
                    else
                        Rows.Last().Backspace();
                }
                _history.RemoveAt(_history.Count - 1);
            }
        }

        public List<TabulatureRow> GenerateFromNote(string note, out TabNote[] notes)
        {
            var thisList = new List<TabulatureRow>();
            var collection = FretboardMap[note];
            notes = collection;

            for (int i = 0; i < collection.Count(); i++)
            {
                thisList.Add(new TabulatureRow(Tuning));
                thisList[i].Add(0, collection[i]);
            }

            return thisList;
        }

        public List<TabulatureRow> GenerateFromNote(string note, Sort sort, out TabNote[] notes)
        {
            var thisList = new List<TabulatureRow>();
            var collection = GetTabsFromNote(note, sort);

            for (int i = 0; i < collection.Count(); i++)
            {
                thisList.Add(new TabulatureRow(Tuning));
                thisList[i].Add(0, collection[i]);
            }

            notes = collection;
            return thisList;
        }

        private TabNote[] GetTabsFromNote(string note, Sort sort)
        {
            List<TabNote> collection = new List<TabNote>();

            var possibleNotes = "C C# D D# E F F# G G# A A# B".Split(' ');
            var stringIndex = 0;
            foreach (var guitarString in this.Tuning)
            {
                var position = Array.IndexOf(possibleNotes, guitarString.ToUpper());
                for (int i = 0; i <= FRET_COUNT; i++, position++)
                {
                    var currentNote = possibleNotes[position % CHROMATIC_COUNT];
                    if (currentNote == note)
                        collection.Add(new TabNote(stringIndex, i.ToString()));
                }

                stringIndex++;
            }

            switch (sort)
            {
                case Sort.Octaves:
                    collection = collection.OrderBy(x => x).ToList();
                    break;
                case Sort.Frets:
                    collection = collection.OrderBy(x => int.Parse(x.Input)).ToList();
                    break;
                case Sort.Strings:
                    collection = collection.OrderBy(x => x.StringIndex).ToList();
                    break;
            }

            return collection.ToArray();
        }

        //private TabNote[] GetTabsFromNote(string note, Sort sort)
        //{
        //    TabNote[] collection;
        //    switch (sort)
        //    {
        //        case Sort.Octaves:
        //            collection = FretboardMap[note];
        //            break;
        //        case Sort.Frets:
        //            collection = FretboardMap[note].OrderBy(x => int.Parse(x.Input)).ToArray();
        //            break;
        //        case Sort.Strings:
        //            collection = FretboardMap[note].OrderBy(x => x.GuitarString).ToArray();
        //            break;
        //        default:
        //            collection = FretboardMap[note];
        //            break;
        //    }
        //    return collection;
        //}

        public void UpdateTuning()
        {
            foreach (var row in Rows)
            {
                row.ChangeTuning(this.Tuning);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in Rows)
            {
                builder.Append(item.ToString());
                builder.Append("\r\n\r\n");
            }

            return builder.ToString();
        }
    }
}
