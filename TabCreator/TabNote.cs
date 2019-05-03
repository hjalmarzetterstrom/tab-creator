using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCreator
{
    public struct TabNote : IComparable<TabNote>
    {
        private string[] _chromatic;

        public int StringIndex { get; set; }
        public string Input { get; set; }
        public string[] Tuning { get; set; }
        public string StringTuning { get { return this.Tuning[this.StringIndex].ToUpper(); } }

        public TabNote(int str, string input)
            : this()
        {
            this.StringIndex = str;
            this.Input = input;

            this._chromatic = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            this.Tuning = new[] { "E", "B", "G", "D", "A", "D" };
        }

        public TabNote(int str, string input, string[] tuning)
            : this()
        {
            this.StringIndex = str;
            this.Input = input;
            this.Tuning = tuning;

            this._chromatic = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        }

        public static Dictionary<string, TabNote[]> GetFretboardMap()
        {
            var cTab = GetCTabs().OrderBy(x => x).ToArray();
            var dTab = GetDTabs().OrderBy(x => x).ToArray();
            var eTab = GetETabs().OrderBy(x => x).ToArray();
            var fTab = GetFTabs().OrderBy(x => x).ToArray();
            var gTab = GetGTabs().OrderBy(x => x).ToArray();
            var aTab = GetATabs().OrderBy(x => x).ToArray();
            var bTab = GetBTabs().OrderBy(x => x).ToArray();

            var cSharpTab = GetCSharpTabs().OrderBy(x => x).ToArray();
            var dSharpTab = GetDSharpTabs().OrderBy(x => x).ToArray();
            var fSharpTab = GetFSharpTabs().OrderBy(x => x).ToArray();
            var gSharpTab = GetGSharpTabs().OrderBy(x => x).ToArray();
            var aSharpTab = GetASharpTabs().OrderBy(x => x).ToArray();

            return new Dictionary<string, TabNote[]>() {
            {"C", cTab},
            {"C#", cSharpTab},
            {"Db", cSharpTab},
            {"D", dTab},
            {"D#", dSharpTab},
            {"Eb", dSharpTab},
            {"E", eTab},
            {"F", fTab},
            {"F#", fSharpTab},
            {"Gb", fSharpTab},
            {"G", gTab},
            {"G#", gSharpTab},
            {"Ab", gSharpTab},
            {"A", aTab},
            {"A#", aSharpTab},
            {"Bb", aSharpTab},
            {"B", bTab}};
        }
        private static TabNote[] GetBTabs()
        {
            return new TabNote[] { 
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
                new TabNote(1, "24")};
        }
        private static TabNote[] GetASharpTabs()
        {
            return new TabNote[] { 
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
                new TabNote(1, "23")};
        }
        private static TabNote[] GetATabs()
        {
            return new TabNote[] { 
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
                new TabNote(4, "24")};
        }
        private static TabNote[] GetGSharpTabs()
        {
            return new TabNote[] {
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
                new TabNote(4, "23")};
        }
        private static TabNote[] GetGTabs()
        {
            return new TabNote[] { 
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
                new TabNote(2, "24")};
        }
        private static TabNote[] GetFSharpTabs()
        {
            return new TabNote[] { 
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
                new TabNote(2, "23")};
        }
        private static TabNote[] GetFTabs()
        {
            return new TabNote[] { 
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
                new TabNote(2, "22")};
        }
        private static TabNote[] GetETabs()
        {
            return new TabNote[] { 
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
                new TabNote(5, "24")};
        }
        private static TabNote[] GetDSharpTabs()
        {
            return new TabNote[] { 
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
                new TabNote(5, "23")};
        }
        private static TabNote[] GetDTabs()
        {
            return new TabNote[] { 
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
                new TabNote(3, "24")};
        }
        private static TabNote[] GetCSharpTabs()
        {
            return new TabNote[] { 
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
                new TabNote(3, "23")};
        }
        private static TabNote[] GetCTabs()
        {
            return new TabNote[] { 
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
                new TabNote(3, "22")};
        }

        public int CompareTo(TabNote note)
        {
            int thisFret = 0;
            int compareFret = 0;
            bool compareIsInt = int.TryParse(note.Input, out compareFret);
            bool thisIsInt = int.TryParse(this.Input, out thisFret);

            if (compareIsInt && thisIsInt)
            {
                if (Enumerable.SequenceEqual(note.Tuning, this.Tuning, StringComparer.InvariantCultureIgnoreCase))
                {
                    int spaceBetweenStrings = Math.Abs(note.StringIndex - this.StringIndex);
                    int thisValue = thisFret;
                    int compareValue = compareFret;
                    switch (this.StringIndex.CompareTo(note.StringIndex))
                    {
                        case -1://This is less
                            MoveToSameString(this, spaceBetweenStrings, ref thisValue);
                            break;
                        case 1://This is greater
                            MoveToSameString(note, spaceBetweenStrings, ref compareValue);
                            break;
                    }

                    compareValue /= 12;
                    thisValue /= 12;
                    return thisValue.CompareTo(compareValue);
                }
                else
                {
                    var result = this.StringIndex.CompareTo(note.StringIndex);
                    if (result == 0)
                        return thisFret.CompareTo(compareFret);
                    else
                        return result;
                }
            }
            else
            {
                throw new NotFiniteNumberException("Fret position of one of the notes is not a number.");
            }
        }

        private void MoveToSameString(TabNote lesserNote, int spaceBetweenStrings, ref int valueToIncrease)
        {
            var tuning = lesserNote.Tuning;
            for (int i = 0, j = lesserNote.StringIndex; i < spaceBetweenStrings; i++, j++)
            {
                var indexOfThis = Array.IndexOf(_chromatic, tuning[j]);
                var indexOfNext = Array.IndexOf(_chromatic, tuning[j + 1]);
                var spaceBetweenNotes = indexOfThis - indexOfNext;
                if (spaceBetweenNotes < 0)
                    spaceBetweenNotes += 12;
                valueToIncrease += spaceBetweenNotes;
            }
        }

        private void ThisIsGreater(ref TabNote note, ref int spaceBetweenStrings, ref int compareValue)
        {
            bool passedBString = note.StringIndex < 2 && spaceBetweenStrings > 1 || note.StringIndex == 1;
            if (passedBString)
            {
                spaceBetweenStrings--;
                compareValue += 4;
            }
            compareValue += (spaceBetweenStrings * 5);
        }

        private void ThisIsLess(ref int spaceBetweenStrings, ref int thisValue)
        {
            bool passedBString = this.StringIndex < 2 && spaceBetweenStrings > 1 || this.StringIndex == 1;
            if (passedBString)
            {
                spaceBetweenStrings--;
                thisValue += 4;
            }
            thisValue += (spaceBetweenStrings * 5);
        }
    }
}




//var map = new Dictionary<string, TabNote[]>() {
//            {"C", (new TabNote[] { 
//                new TabNote(1, "1"), 
//                new TabNote(4, "3"), 
//                new TabNote(2, "5"), 
//                new TabNote(0, "8"),
//                new TabNote(5, "8"),
//                new TabNote(3, "10"),
//                new TabNote(1, "13"),
//                new TabNote(4, "15"),
//                new TabNote(2, "17"),
//                new TabNote(0, "20"),
//                new TabNote(5, "20"),
//                new TabNote(3, "22")}).OrderBy(x=>x).ToArray()},
//            {"C#", (new TabNote[] { 
//                new TabNote(1, "2"), 
//                new TabNote(4, "4"), 
//                new TabNote(2, "6"), 
//                new TabNote(0, "9"),
//                new TabNote(5, "9"),
//                new TabNote(3, "11"),
//                new TabNote(1, "14"),
//                new TabNote(4, "16"),
//                new TabNote(2, "18"),
//                new TabNote(0, "21"),
//                new TabNote(5, "21"),
//                new TabNote(3, "23")}).OrderBy(x=>x).ToArray()},
//            {"Db", (new TabNote[] { 
//                new TabNote(1, "2"), 
//                new TabNote(4, "4"), 
//                new TabNote(2, "6"), 
//                new TabNote(0, "9"),
//                new TabNote(5, "9"),
//                new TabNote(3, "11"),
//                new TabNote(1, "14"),
//                new TabNote(4, "16"),
//                new TabNote(2, "18"),
//                new TabNote(0, "21"),
//                new TabNote(5, "21"),
//                new TabNote(3, "23")}).OrderBy(x=>x).ToArray()},
//            {"D", (new TabNote[] { 
//                new TabNote(3, "0"),
//                new TabNote(1, "3"), 
//                new TabNote(4, "5"), 
//                new TabNote(2, "7"), 
//                new TabNote(0, "10"),
//                new TabNote(5, "10"),
//                new TabNote(3, "12"),
//                new TabNote(1, "15"),
//                new TabNote(4, "17"),
//                new TabNote(2, "19"),
//                new TabNote(0, "22"),
//                new TabNote(5, "22"),
//                new TabNote(3, "24")}).OrderBy(x=>x).ToArray()},
//            {"D#", (new TabNote[] { 
//                new TabNote(3, "1"),
//                new TabNote(1, "4"), 
//                new TabNote(4, "6"), 
//                new TabNote(2, "8"), 
//                new TabNote(0, "11"),
//                new TabNote(5, "11"),
//                new TabNote(3, "13"),
//                new TabNote(1, "16"),
//                new TabNote(4, "18"),
//                new TabNote(2, "20"),
//                new TabNote(0, "23"),
//                new TabNote(5, "23")}).OrderBy(x=>x).ToArray()},
//            {"Eb", (new TabNote[] { 
//                new TabNote(3, "1"),
//                new TabNote(1, "4"), 
//                new TabNote(4, "6"), 
//                new TabNote(2, "8"), 
//                new TabNote(0, "11"),
//                new TabNote(5, "11"),
//                new TabNote(3, "13"),
//                new TabNote(1, "16"),
//                new TabNote(4, "18"),
//                new TabNote(2, "20"),
//                new TabNote(0, "23"),
//                new TabNote(5, "23")}).OrderBy(x=>x).ToArray()},
//            {"E", (new TabNote[] { 
//                new TabNote(0, "0"),
//                new TabNote(5, "0"),
//                new TabNote(3, "2"),
//                new TabNote(1, "5"), 
//                new TabNote(4, "7"), 
//                new TabNote(2, "9"), 
//                new TabNote(0, "12"),
//                new TabNote(5, "12"),
//                new TabNote(3, "14"),
//                new TabNote(1, "17"),
//                new TabNote(4, "19"),
//                new TabNote(2, "21"),
//                new TabNote(0, "24"),
//                new TabNote(5, "24")}).OrderBy(x=>x).ToArray()},
//            {"F", (new TabNote[] { 
//                new TabNote(0, "1"),
//                new TabNote(5, "1"),
//                new TabNote(3, "3"),
//                new TabNote(1, "6"), 
//                new TabNote(4, "8"), 
//                new TabNote(2, "10"), 
//                new TabNote(0, "13"),
//                new TabNote(5, "13"),
//                new TabNote(3, "15"),
//                new TabNote(1, "18"),
//                new TabNote(4, "20"),
//                new TabNote(2, "22")}).OrderBy(x=>x).ToArray()},
//            {"F#", (new TabNote[] { 
//                new TabNote(0, "2"),
//                new TabNote(5, "2"),
//                new TabNote(3, "4"),
//                new TabNote(1, "7"), 
//                new TabNote(4, "9"), 
//                new TabNote(2, "11"), 
//                new TabNote(0, "14"),
//                new TabNote(5, "14"),
//                new TabNote(3, "16"),
//                new TabNote(1, "19"),
//                new TabNote(4, "21"),
//                new TabNote(2, "23")}).OrderBy(x=>x).ToArray()},
//            {"Gb", (new TabNote[] { 
//                new TabNote(0, "2"),
//                new TabNote(5, "2"),
//                new TabNote(3, "4"),
//                new TabNote(1, "7"), 
//                new TabNote(4, "9"), 
//                new TabNote(2, "11"), 
//                new TabNote(0, "14"),
//                new TabNote(5, "14"),
//                new TabNote(3, "16"),
//                new TabNote(1, "19"),
//                new TabNote(4, "21"),
//                new TabNote(2, "23")}).OrderBy(x=>x).ToArray()},
//            {"G", (new TabNote[] { 
//                new TabNote(2, "0"),
//                new TabNote(0, "3"),
//                new TabNote(5, "3"),
//                new TabNote(3, "5"),
//                new TabNote(1, "8"), 
//                new TabNote(4, "10"), 
//                new TabNote(2, "12"), 
//                new TabNote(0, "15"),
//                new TabNote(5, "15"),
//                new TabNote(3, "17"),
//                new TabNote(1, "20"),
//                new TabNote(4, "22"),
//                new TabNote(2, "24")}).OrderBy(x=>x).ToArray()},
//            {"G#", (new TabNote[] {
//                new TabNote(2, "1"),
//                new TabNote(0, "4"),
//                new TabNote(5, "4"),
//                new TabNote(3, "6"),
//                new TabNote(1, "9"), 
//                new TabNote(4, "11"), 
//                new TabNote(2, "13"), 
//                new TabNote(0, "16"),
//                new TabNote(5, "16"),
//                new TabNote(3, "18"),
//                new TabNote(1, "21"),
//                new TabNote(4, "23")}).OrderBy(x=>x).ToArray()},
//            {"Ab", (new TabNote[] {
//                new TabNote(2, "1"),
//                new TabNote(0, "4"),
//                new TabNote(5, "4"),
//                new TabNote(3, "6"),
//                new TabNote(1, "9"), 
//                new TabNote(4, "11"), 
//                new TabNote(2, "13"), 
//                new TabNote(0, "16"),
//                new TabNote(5, "16"),
//                new TabNote(3, "18"),
//                new TabNote(1, "21"),
//                new TabNote(4, "23")}).OrderBy(x=>x).ToArray()},
//            {"A", (new TabNote[] { 
//                new TabNote(4, "0"),
//                new TabNote(2, "2"),
//                new TabNote(0, "5"),
//                new TabNote(5, "5"),
//                new TabNote(3, "7"),
//                new TabNote(1, "10"), 
//                new TabNote(4, "12"), 
//                new TabNote(2, "14"), 
//                new TabNote(0, "17"),
//                new TabNote(5, "17"),
//                new TabNote(3, "19"),
//                new TabNote(1, "22"),
//                new TabNote(4, "24")}).OrderBy(x=>x).ToArray()},
//            {"A#", (new TabNote[] { 
//                new TabNote(4, "1"),
//                new TabNote(2, "3"),
//                new TabNote(0, "6"),
//                new TabNote(5, "6"),
//                new TabNote(3, "8"),
//                new TabNote(1, "11"), 
//                new TabNote(4, "13"), 
//                new TabNote(2, "15"), 
//                new TabNote(0, "18"),
//                new TabNote(5, "18"),
//                new TabNote(3, "20"),
//                new TabNote(1, "23")}).OrderBy(x=>x).ToArray()},
//            {"Bb", (new TabNote[] { 
//                new TabNote(4, "1"),
//                new TabNote(2, "3"),
//                new TabNote(0, "6"),
//                new TabNote(5, "6"),
//                new TabNote(3, "8"),
//                new TabNote(1, "11"), 
//                new TabNote(4, "13"), 
//                new TabNote(2, "15"), 
//                new TabNote(0, "18"),
//                new TabNote(5, "18"),
//                new TabNote(3, "20"),
//                new TabNote(1, "23")}).OrderBy(x=>x).ToArray()},
//            {"B", (new TabNote[] { 
//                new TabNote(1, "0"),
//                new TabNote(4, "2"),
//                new TabNote(2, "4"),
//                new TabNote(0, "7"),
//                new TabNote(5, "7"),
//                new TabNote(3, "9"),
//                new TabNote(1, "12"), 
//                new TabNote(4, "14"), 
//                new TabNote(2, "16"), 
//                new TabNote(0, "19"),
//                new TabNote(5, "19"),
//                new TabNote(3, "21"),
//                new TabNote(1, "24")}).OrderBy(x=>x).ToArray()}};