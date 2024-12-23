using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YCProyectoMVVM.Models
{
    internal class Note
    {
        public string YCFilename { get; set; }
        public string YCText { get; set; }
        public DateTime Date { get; set; }
        public void Save() =>
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, YCFilename), YCText);
        public Note()
        {
            YCFilename = $"{Path.GetRandomFileName()}.notes.txt";
            Date = DateTime.Now;
            YCText = "";
        }
        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, YCFilename));
        public static Note Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);

            return
                new()
                {
                    YCFilename = Path.GetFileName(filename),
                    YCText = File.ReadAllText(filename),
                    Date = File.GetLastWriteTime(filename)
                };
        }
        public static IEnumerable<Note> LoadAll()
        {
            string appDataPath = FileSystem.AppDataDirectory;
            return Directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")
                    .Select(filename => Note.Load(Path.GetFileName(filename)))
                    .OrderByDescending(note => note.Date);
        }
        
    }
}

