using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCreator
{
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
            {"Db", (new TabNote[] { 
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
            {"Eb", (new TabNote[] { 
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
            {"Gb", (new TabNote[] { 
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
            {"Ab", (new TabNote[] {
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
            {"Bb", (new TabNote[] { 
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
                switch (this.GuitarString.CompareTo(note.GuitarString))
                {
                    case -1:
                        thisIsLess(ref spaceBetweenStrings, ref thisValue);
                        break;
                    case 1:
                        thisIsGreater(ref note, ref spaceBetweenStrings, ref compareValue);
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

        private void thisIsGreater(ref TabNote note, ref int spaceBetweenStrings, ref int compareValue)
        {
            bool passedBString = note.GuitarString < 2 && spaceBetweenStrings > 1 || note.GuitarString == 1;
            if (passedBString)
            {
                spaceBetweenStrings--;
                compareValue += 4;
            }
            compareValue += (spaceBetweenStrings * 5);
        }

        private void thisIsLess(ref int spaceBetweenStrings, ref int thisValue)
        {
            bool passedBString = this.GuitarString < 2 && spaceBetweenStrings > 1 || this.GuitarString == 1;
            if (passedBString)
            {
                spaceBetweenStrings--;
                thisValue += 4;
            }
            thisValue += (spaceBetweenStrings * 5);
        }
    }
}
