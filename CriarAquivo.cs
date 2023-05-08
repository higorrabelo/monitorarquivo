using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileChecker {
    internal class CriarAquivo {
        public static void criarArquivo() {
            try {
                string path = Directory.GetCurrentDirectory();
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(conteudoArquivo());
                sw.Close();
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }
        public static string conteudoArquivo() { 
            string conteudo = null;
            conteudo = "Conteudo do arquivo não modificado";
            return conteudo;
        }
        public static string lerArquivo() {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory());
            string linha = sr.ReadLine();  
            while(linha != "") {
                Console.WriteLine(linha);
                linha = sr.ReadLine();
            }
            sr.Close();
            return linha;
        }
    }



}
