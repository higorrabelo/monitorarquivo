using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChecker {
    internal class Program {

        private static FileSystemWatcher _monitorar;

        public static void MonitorarArquivos(string path, string filtro) {
            try {
                _monitorar = new FileSystemWatcher(path, filtro) {
                    IncludeSubdirectories = false
                };
                _monitorar.Created += OnFileChanged;
                _monitorar.Changed += OnFileChanged;
                _monitorar.Deleted += OnFileChanged;
                _monitorar.Renamed += OnFileRenamed;

                _monitorar.EnableRaisingEvents = true;


                Console.WriteLine($"Monitorando arquivos e: {filtro}");
            }
            catch(ArgumentException ag) {
                Console.WriteLine(ag.Message);
            }

        }
        private static void OnFileChanged(Object sender, FileSystemEventArgs e) {
            Console.WriteLine($"O arquivo {e.Name} {e.ChangeType}");
        }
        private static void OnFileRenamed(object sender, RenamedEventArgs e) {
            Console.WriteLine($"O arquivo {e.OldName}{e.ChangeType} para {e.Name}");
        }
        static void Main(string[] args) {
            Console.WriteLine("Monitorando Arquivo com: FileSystemWatcher");
            string path = Directory.GetCurrentDirectory();
            string filtro = "teste.txt";
            MonitorarArquivos(path, filtro);
            Console.ReadLine();
        }
    }
}
