using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    internal class Song
    {
        public string Name { get; }
        public string Author { get; }
        public Song PreviousSong { get; }

        public Song(string name, string author, Song previousSong)
        {
            Name = name;
            Author = author;
            PreviousSong = previousSong;
        }

        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            PreviousSong = null;
        }

        public Song()
        {
            Name = null;
            Author = null;
            PreviousSong = null;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} by {Author}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Song)obj;
            return (Name == other.Name && Author == other.Author);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Name?.GetHashCode() ?? 0);
                hash = hash * 23 + (Author?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}