using Master.Rotas.Dominio.Dto;
using System.Xml.Linq;

namespace Master.Rotas.Infra.Servicos
{
    public class FileBaseRota
    {
        
        private readonly XElement _root = new XElement("ROTAS",
            new XElement("ROTA",
                new XElement("ORIGEM", "GRU"),
                new XElement("DESTINO", "BRC"),
                new XElement("VALOR", "10")),
            new XElement("ROTA",
                new XElement("ORIGEM", "BRC"),
                new XElement("DESTINO", "SCL"),
                new XElement("VALOR", "5")),
            new XElement("ROTA",
                new XElement("ORIGEM", "GRU"),
                new XElement("DESTINO", "CDG"),
                new XElement("VALOR", "75")),
            new XElement("ROTA",
                new XElement("ORIGEM", "GRU"),
                new XElement("DESTINO", "SCL"),
                new XElement("VALOR", "20")),
            new XElement("ROTA",
                new XElement("ORIGEM", "GRU"),
                new XElement("DESTINO", "ORL"),
                new XElement("VALOR", "56")),
            new XElement("ROTA",
                new XElement("ORIGEM", "ORL"),
                new XElement("DESTINO", "CDG"),
                new XElement("VALOR", "5")),
            new XElement("ROTA",
                new XElement("ORIGEM", "SCL"),
                new XElement("DESTINO", "ORL"),
                new XElement("VALOR", "20"))
            );
        

        public void FileBaseRotaService()
        {
            string completeFolderPath = Path.Combine(@"C:\", "FILE_BASE_ROTA");
            string completeFIlePath = Path.Combine(completeFolderPath, "fileDados.xml");
            if (!Directory.Exists(completeFolderPath))
            {
                Directory.CreateDirectory(completeFolderPath);
            }

            StreamWriter sw = new StreamWriter(completeFIlePath);
            sw.WriteLine(_root);
            sw.Close();
        }

        public string LerFileBaseRotaService()
        {
            string completeFolderPath = Path.Combine(@"C:\", "FILE_BASE_ROTA");
            string completeFIlePath = Path.Combine(completeFolderPath, "fileDados.xml");
            StreamReader sr = new StreamReader(completeFIlePath);
            var result = sr.ReadToEnd();
            sr.Close();
            return result;
        }
    }
}