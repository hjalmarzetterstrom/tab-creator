using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCreator
{
    public enum Sort
    {
        Octaves,
        Frets,
        Strings
    }

    public struct TabNote : IComparable<TabNote>
    {
        public int GuitarString { get; set; }
        public string Input { get; set; }

        public TabNote(int str, string input)
            : this()
        {
            this.GuitarString = str;
            this.Input = input;
        }

        public static Dictionary<string, TabNote[]> GetFretboardMap()
        {
            var map = new Dictionary<string, TabNote[]>() {
            {"C", (new TabNote[] { 
                new TabNote(1, "1"), 
                new TabNote(4, "3"), 
                new TabNote(2, "5"), 
                new TabNote(0, "8"),
                new TabNote(5, "8"),
                new TabNote(3, "10"),
                new TabNote(1, "13"),
                new TabNote(4, "15"),
                new TabNote(2, "17"),
                new TabNote(0, "20"),
                new TabNote(5, "20"),
                new TabNote(3, "22")}).OrderBy(x=>x).ToArray()},
            {"C#", (new TabNote[] { 
                new TabNote(1, "2"), 
                new TabNote(4, "4"), 
                new TabNote(2, "6"), 
                new TabNote(0, "9"),
                new TabNote(5, "9"),
                new TabNote(3, "11"),
                new TabNote(1, "14"),
                new TabNote(4, "16"),
                new TabNote(2, "18"),
                new TabNote(0, "21"),
                new TabNote(5, "21"),
                new TabNote(3, "23")}).OrderBy(x=>x).ToArray()},
            {"D", (new TabNote[] { 
                new TabNote(3, "0"),
                new TabNote(1, "3"), 
                new TabNote(4, "5"), 
                new TabNote(2, "7"), 
                new TabNote(0, "10"),
                new TabNote(5, "10"),
                new TabNote(3, "12"),
                new TabNote(1, "15"),
                new TabNote(4, "17"),
                new TabNote(2, "19"),
                new TabNote(0, "22"),
                new TabNote(5, "22"),
                new TabNote(3, "24")}).OrderBy(x=>x).ToArray()},
            {"D#", (new TabNote[] { 
                new TabNote(3, "1"),
                new TabNote(1, "4"), 
                new TabNote(4, "6"), 
                new TabNote(2, "8"), 
                new TabNote(0, "11"),
                new TabNote(5, "11"),
                new TabNote(3, "13"),
                new TabNote(1, "16"),
                new TabNote(4, "18"),
                new TabNote(2, "20"),
                new TabNote(0, "23"),
                new TabNote(5, "23")}).OrderBy(x=>x).ToArray()},
            {"E", (new TabNote[] { 
                new TabNote(0, "0"),
                new TabNote(5, "0"),
                new TabNote(3, "2"),
                new TabNote(1, "5"), 
                new TabNote(4, "7"), 
                new TabNote(2, "9"), 
                new TabNote(0, "12"),
                new TabNote(5, "12"),
                new TabNote(3, "14"),
                new TabNote(1, "17"),
                new TabNote(4, "19"),
                new TabNote(2, "21"),
                new TabNote(0, "24"),
                new TabNote(5, "24")}).OrderBy(x=>x).ToArray()},
            {"F", (new TabNote[] { 
                new TabNote(0, "1"),
                new TabNote(5, "1"),
                new TabNote(3, "3"),
                new TabNote(1, "6"), 
                new TabNote(4, "8"), 
                new TabNote(2, "10"), 
                new TabNote(0, "13"),
                new TabNote(5, "13"),
                new TabNote(3, "15"),
                new TabNote(1, "18"),
                new TabNote(4, "20"),
                new TabNote(2, "22")}).OrderBy(x=>x).ToArray()},
            {"F#", (new TabNote[] { 
                new TabNote(0, "2"),
                new TabNote(5, "2"),
                new TabNote(3, "4"),
                new TabNote(1, "7"), 
                new TabNote(4, "9"), 
                new TabNote(2, "11"), 
                new TabNote(0, "14"),
                new TabNote(5, "14"),
                new TabNote(3, "16"),
                new TabNote(1, "19"),
                new TabNote(4, "21"),
                new TabNote(2, "23")}).OrderBy(x=>x).ToArray()},
            {"G", (new TabNote[] { 
                new TabNote(2, "0"),
                new TabNote(0, "3"),
                new TabNote(5, "3"),
                new TabNote(3, "5"),
                new TabNote(1, "8"), 
                new TabNote(4, "10"), 
                new TabNote(2, "12"), 
                new TabNote(0, "15"),
                new TabNote(5, "15"),
                new TabNote(3, "17"),
                new TabNote(1, "20"),
                new TabNote(4, "22"),
                new TabNote(2, "24")}).OrderBy(x=>x).ToArray()},
            {"G#", (new TabNote[] {
                new TabNote(2, "1"),
                new TabNote(0, "4"),
                new TabNote(5, "4"),
                new TabNote(3, "6"),
                new TabNote(1, "9"), 
                new TabNote(4, "11"), 
                new TabNote(2, "13"), 
                new TabNote(0, "16"),
                new TabNote(5, "16"),
                new TabNote(3, "18"),
                new TabNote(1, "21"),
                new TabNote(4, "23")}).OrderBy(x=>x).ToArray()},
            {"A", (new TabNote[] { 
                new TabNote(4, "0"),
                new TabNote(2, "2"),
                new TabNote(0, "5"),
                new TabNote(5, "5"),
                new TabNote(3, "7"),
                new TabNote(1, "10"), 
                new TabNote(4, "12"), 
                new TabNote(2, "14"), 
                new TabNote(0, "17"),
                new TabNote(5, "17"),
                new TabNote(3, "19"),
                new TabNote(1, "22"),
                new TabNote(4, "24")}).OrderBy(x=>x).ToArray()},
            {"A#", (new TabNote[] { 
                new TabNote(4, "1"),
                new TabNote(2, "3"),
                new TabNote(0, "6"),
                new TabNote(5, "6"),
                new TabNote(3, "8"),
                new TabNote(1, "11"), 
                new TabNote(4, "13"), 
                new TabNote(2, "15"), 
                new TabNote(0, "18"),
                new TabNote(5, "18"),
                new TabNote(3, "20"),
                new TabNote(1, "23")}).OrderBy(x=>x).ToArray()},
            {"B", (new TabNote[] { 
                new TabNote(1, "0"),
                new TabNote(4, "2"),
                new TabNote(2, "4"),
                new TabNote(0, "7"),
                new TabNote(5, "7"),
                new TabNote(3, "9"),
                new TabNote(1, "12"), 
                new TabNote(4, "14"), 
                new TabNote(2, "16"), 
                new TabNote(0, "19"),
                new TabNote(5, "19"),
                new TabNote(3, "21"),
                new TabNote(1, "24")}).OrderBy(x=>x).ToArray()}};


            return map;
        }

        public int CompareTo(TabNote note)
        {
            int thisFret = 0;
            int compareFret = 0;
            bool compareIsInt = int.TryParse(note.Input, out compareFret);
            bool thisIsInt = int.TryParse(this.Input, out thisFret);

            if (compareIsInt && thisIsInt)
            {
                int spaceBetweenStrings = Math.Abs(note.GuitarString - this.GuitarString);
                int thisValue = thisFret;
                int compareValue = compareFret;
                bool passedBString;
                switch (this.GuitarString.CompareTo(note.GuitarString))
                {
                    case -1:
                        passedBString = this.GuitarString < 2 && spaceBetweenStrings > 1 || this.GuitarString == 1;
                        if (passedBString)
                        {
                            spaceBetweenStrings--;
                            thisValue += 4;
                        }
                        thisValue += (spaceBetweenStrings * 5);
                        break;
                    case 1:
                        passedBString = note.GuitarString < 2 && spaceBetweenStrings > 1 || note.GuitarString == 1;
                        if (passedBString)
                        {
                            spaceBetweenStrings--;
                            compareValue += 4;
                        }
                        compareValue += (spaceBetweenStrings * 5);
                        break;
                }

                compareValue /= 12;
                thisValue /= 12;
                return thisValue.CompareTo(compareValue);
            }
            else
            {
                throw new NotFiniteNumberException("Fret position of one of the notes is not a number.");
            }
        }
    }

    public class TabulatureRow
    {
        private StringBuilder[] _tabBuilder;
        public string[] Tabulature
        {
            get
            {
                return _tabBuilder.Select(x => x.ToString()).ToArray();
            }
        }

        public int Length
        {
            get
            {
                return _tabBuilder[0].Length;
            }
        }

        public TabulatureRow(string[] tuning)
        {
            _tabBuilder = tuning.Select(x => new StringBuilder(x + "|")).ToArray();
        }

        public TabulatureRow(string[] tuning, string[] tabulature)
            : this(tuning)
        {
            for (int i = 0; i < tabulature.Length; i++)
            {
                _tabBuilder[i].Append(tabulature[i].Skip(tabulature[i].Length - 6));
            }
        }

        public void Add(int space, params TabNote[] notes)
        {
            foreach (var item in notes)
            {
                _tabBuilder[item.GuitarString].Append('-', space);
                _tabBuilder[item.GuitarString].Append(item.Input);
            }

            for (int i = 0; i < 6; i++)
            {
                int dif = _tabBuilder.Max(x => x.Length) - _tabBuilder[i].Length;
                _tabBuilder[i].Append('-', dif);
            }
        }

        public void Add(int space, int numberOfEntries, params TabNote[] notes)
        {
            foreach (var item in notes)
            {
                for (int i = 0; i < numberOfEntries; i++)
                {
                    _tabBuilder[item.GuitarString].Append('-', space);
                    _tabBuilder[item.GuitarString].Append(item.Input);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int dif = _tabBuilder.Max(x => x.Length) - _tabBuilder[i].Length;
                _tabBuilder[i].Append('-', dif);
            }
        }

        public void AddSplitter()
        {
            foreach (var item in _tabBuilder)
            {
                item.Append('|');
            }
        }

        public void Undo()
        {
            if (Length > 2)
                _tabBuilder = _tabBuilder.Select(x => x.Remove(x.Length - 1, 1)).ToArray();
        }

        public override string ToString()
        {
            StringBuilder tab = new StringBuilder();

            foreach (var item in Tabulature)
            {
                tab.Append(item + "\r\n");
            }

            return tab.ToString();
        }
    }

    public class Sheet
    {
        public List<TabulatureRow> Rows { get; set; }
        public string[] Tuning { get; set; }

        public Dictionary<string, TabNote[]> FretboardMap = TabNote.GetFretboardMap();

        TabulatureRow this[int index]
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
            this.Tuning = tuning;
            Rows = new List<TabulatureRow>();
            Rows.Add(new TabulatureRow(Tuning));
        }

        public void NewRow()
        {
            Rows.Add(new TabulatureRow(Tuning));
        }

        public void AddTab(int space, params TabNote[] notes)
        {
            Rows.Last().Add(space, notes);
        }

        public void AddTab(int space, int numberOfEntries, params TabNote[] notes)
        {
            Rows.Last().Add(space, numberOfEntries, notes);
        }

        public void AddSplitter()
        {
            Rows.Last().AddSplitter();
        }

        public void Undo()
        {
            if (Rows.Last().Length == 2 && Rows.Count > 1)
                Rows.Remove(Rows.Last());
            else
                Rows.Last().Undo();
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
            TabNote[] collection;
            switch (sort)
            {
                case Sort.Octaves:
                    collection = FretboardMap[note];
                    break;
                case Sort.Frets:
                    collection = FretboardMap[note].OrderBy(x => int.Parse(x.Input)).ToArray();
                    break;
                case Sort.Strings:
                    collection = FretboardMap[note].OrderBy(x => x.GuitarString).ToArray();
                    break;
                default:
                    collection = FretboardMap[note];
                    break;
            }
            notes = collection;

            for (int i = 0; i < collection.Count(); i++)
            {
                thisList.Add(new TabulatureRow(Tuning));
                thisList[i].Add(0, collection[i]);
            }

            return thisList;
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
