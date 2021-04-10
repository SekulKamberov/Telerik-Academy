namespace XMLProcessing
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Xsl;

    public class Program
    {
        public static void Main(string[] args)
        {
            // recopy for each start of the program
            string newFilePath = "../../catalogue.xml";
            string originalFile = "../../catalogueCopy.xml";
            File.Copy(originalFile, newFilePath, true);

            // 02
            XmlDocument doc = new XmlDocument();
            doc.Load(newFilePath);

            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> albumsCount = CountAlbumsByAuthorDOM(rootNode);
            Console.WriteLine("===== 02 =====");
            foreach (var artist in albumsCount)
            {
                Console.WriteLine("Artist: {0} AlbumsCount: {1}", artist.Key, artist.Value);
            }

            // 03
            Console.WriteLine();
            Console.WriteLine("===== 03 =====");
            albumsCount = CountAlbumsByAuthorXPath(doc);
            foreach (var artist in albumsCount)
            {
                Console.WriteLine("Artist: {0} AlbumsCount: {1}", artist.Key, artist.Value);
            }

            // 04
            Console.WriteLine();
            Console.WriteLine("===== 04 =====");
            DeleteNodesWithHigherPrice(doc, 20);

            // 05
            Console.WriteLine();
            Console.WriteLine("===== 05 =====");
            var songs = GetSongsTitlesXmlReader(newFilePath);
            foreach (var song in songs)
            {
                Console.WriteLine("Song title: {0}", song);
            }

            // 06
            Console.WriteLine();
            Console.WriteLine("===== 06 =====");
            var songTitles = GetSongsTitlesXDocument(newFilePath);
            foreach (var title in songTitles)
            {
                Console.WriteLine("Song Title: {0}", title);
            }

            // 07
            Console.WriteLine();
            Console.WriteLine("===== 07 =====");
            string personInfoXmlFilePath = "../../personInfo.xml";
            string personInfoTextFilePath = "../../personInfo.txt";
            TransformTextFileToXml(personInfoTextFilePath, personInfoXmlFilePath);

            // 08
            Console.WriteLine();
            Console.WriteLine("===== 08 =====");
            string albumsXmlFilePath = "../../albums.xml";
            WriteAlbumsInfoToXml(newFilePath, albumsXmlFilePath);
            
            // 09
            Console.WriteLine();
            Console.WriteLine("===== 09 =====");
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings() { Encoding = encoding, Indent = true, IndentChars = "\t" };
            string directoryPath = "..\\..\\MainDirectory";
            string xmlFileForDirectoriesPath = "..\\..\\direcoties.xml";
            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFileForDirectoriesPath, xmlWriterSettings))
            {
                MapDirectoryContentToXmlFile(xmlWriter, directoryPath);
            }

            // 10
            Console.WriteLine();
            Console.WriteLine("===== 10 =====");
            MapDirectoryContentToXmlFileXDocument("..\\..\\MainDirectory", "..\\..\\direcotiesXDoc.xml");

            // 11
            Console.WriteLine();
            Console.WriteLine("===== 11 =====");
            IDictionary<string, double> albums = GetAlbumsPriceByDatePublishedXPath(doc, DateTime.Now.AddYears(-5));
            foreach (var album in albums)
            {
                Console.WriteLine("Album: {0} Price: {1}", album.Key, album.Value);
            }

            // 12
            Console.WriteLine();
            Console.WriteLine("===== 12 =====");
            GetAlbumsPriceByDatePublishedLinq(newFilePath, DateTime.Now.AddYears(-5));

            // 13
            Console.WriteLine();
            Console.WriteLine("===== 13 =====");
            string catalogXslFilePath = "../../catalogue.xsl";
            string catalogHtmlFilePath = "../../catalogue.html";
            TransformXmlToHtml(newFilePath, catalogXslFilePath, catalogHtmlFilePath);

            doc.Save(newFilePath);
            // doc.Save(Console.Out);
        }

        // 02
        private static Dictionary<string, int> CountAlbumsByAuthorDOM(XmlNode catalogue)
        {
            var artistAlbumsCountCatalogue = new Dictionary<string, int>();

            foreach (XmlNode album in catalogue.ChildNodes)
            {
                var artist = album["artist"].InnerText;

                if (!artistAlbumsCountCatalogue.ContainsKey(artist))
                {
                    artistAlbumsCountCatalogue[artist] = 0;
                }

                artistAlbumsCountCatalogue[artist] += 1;
            }

            return artistAlbumsCountCatalogue;
        }

        // 03
        private static Dictionary<string, int> CountAlbumsByAuthorXPath(XmlDocument doc)
        {
            var artistAlbumsCountCatalogue = new Dictionary<string, int>();

            string xPathQuery = "/albums/album";
            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                string artistName = album.SelectSingleNode("artist").InnerText;
                if (!artistAlbumsCountCatalogue.ContainsKey(artistName))
                {
                    string xPathAlbumsQuery = "/albums/album[artist='" + artistName + "']";
                    int albumsCount = doc.SelectNodes(xPathAlbumsQuery).Count;
                    artistAlbumsCountCatalogue[artistName] = albumsCount;
                }
            }

            return artistAlbumsCountCatalogue;
        }

        // 04
        private static void DeleteNodesWithHigherPrice(XmlDocument doc, double maxPriceAllowed)
        {
            XmlNode rootNode = doc.DocumentElement;
            var albums = rootNode.ChildNodes;

            var nodesToDelete = new List<XmlNode>();

            foreach (XmlNode album in albums)
            {
                string priceAsString = album["price"].InnerText;
                double price;
                bool isPriceCorrect = double.TryParse(priceAsString, out price);
                if (isPriceCorrect && price > maxPriceAllowed)
                {
                    nodesToDelete.Add(album);
                }
            }

            foreach (var node in nodesToDelete)
            {
                rootNode.RemoveChild(node);
            }
        }

        // 05
        private static IList GetSongsTitlesXmlReader(string documentPath)
        {
            var songsTitles = new List<string>();
            using (XmlReader xmlReader = XmlReader.Create(documentPath))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element &&
                            xmlReader.Name == "title")
                    {
                        var title = xmlReader.ReadElementString();
                        songsTitles.Add(title);
                    }
                }
            }

            return songsTitles;
        }

        // 06
        private static IEnumerable<string> GetSongsTitlesXDocument(string documentPath)
        {
            XDocument doc = XDocument.Load(documentPath);
            IEnumerable<string> songsTitles =
                from element in doc.Descendants()
                where element.Name == "title"
                select element.Value;

            return songsTitles;
        }

        // 07
        private static void TransformTextFileToXml(string textFilePath, string xmlFilePath)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(textFilePath))
                {
                    XmlDocument doc = new XmlDocument();

                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement root = doc.DocumentElement;
                    doc.InsertBefore(xmlDeclaration, root);

                    XmlElement person = doc.CreateElement(string.Empty, "person", string.Empty);
                    doc.AppendChild(person);

                    XmlElement personName = doc.CreateElement(string.Empty, "name", string.Empty);
                    string name = streamReader.ReadLine();
                    personName.InnerText = name;
                    person.AppendChild(personName);

                    XmlElement personAddress = doc.CreateElement(string.Empty, "address", string.Empty);
                    string address = streamReader.ReadLine();
                    personAddress.InnerText = address;
                    person.AppendChild(personAddress);

                    XmlElement personPhone = doc.CreateElement(string.Empty, "phone", string.Empty);
                    string phone = streamReader.ReadLine();
                    personPhone.InnerText = phone;
                    person.AppendChild(personPhone);

                    doc.Save(xmlFilePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        // 08
        private static void WriteAlbumsInfoToXml(string originalXmlFilePath, string albumsXmlFilePath)
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings() { Encoding = encoding, Indent = true, IndentChars = "\t" };

            using (XmlWriter xmlWriter = XmlWriter.Create(albumsXmlFilePath, xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("albums");

                using (XmlReader xmlReader = XmlReader.Create(originalXmlFilePath))
                {
                    while (xmlReader.ReadToFollowing("album"))
                    {
                        xmlReader.ReadToFollowing("name");
                        string name = xmlReader.ReadElementContentAsString();
                        xmlReader.ReadToFollowing("artist");
                        string artist = xmlReader.ReadElementContentAsString();

                        xmlWriter.WriteStartElement("album");
                        xmlWriter.WriteElementString("name", name);
                        xmlWriter.WriteElementString("artist", artist);
                        xmlWriter.WriteEndElement();
                    }

                    // string albumName = null;
                    // string authorName;

                    // while (xmlReader.Read())
                    // {
                    // if (xmlReader.NodeType == XmlNodeType.Element &&
                    // xmlReader.Name == "name")
                    // {
                    // albumName = xmlReader.ReadElementString();
                    // }
                    // else if (xmlReader.NodeType == XmlNodeType.Element &&
                    // xmlReader.Name == "artist")
                    // {
                    // authorName = xmlReader.ReadElementString();

                    // xmlWriter.WriteStartElement("album");
                    // xmlWriter.WriteElementString("name", albumName);
                    // xmlWriter.WriteElementString("artist", authorName);
                    // xmlWriter.WriteEndElement();
                    // }
                    // }
                }

                xmlWriter.WriteEndDocument();
            }
        }

        // 09
        private static void MapDirectoryContentToXmlFile(XmlWriter xmlWriter, string directoryPath)
        {
            xmlWriter.WriteStartDocument();

            MapInnerDirectories(xmlWriter, directoryPath);

            xmlWriter.WriteEndDocument();
        }

        // 09
        private static void MapInnerDirectories(XmlWriter xmlWriter, string directoryPath)
        {
            string currentDirectory = directoryPath.Substring(directoryPath.LastIndexOf('\\') + 1);

            xmlWriter.WriteStartElement("dir");
            xmlWriter.WriteAttributeString("name", currentDirectory);

            var directories = Directory.EnumerateDirectories(directoryPath);
            foreach (var directory in directories)
            {
                MapInnerDirectories(xmlWriter, directory);
            }

            var files = Directory.EnumerateFiles(directoryPath);
            foreach (var file in files)
            {
                string currentFile = file.Substring(file.LastIndexOf('\\') + 1);
                int lastDotIndex = currentFile.LastIndexOf('.');
                string fileName = currentFile.Substring(0, lastDotIndex);
                string fileExtension = currentFile.Substring(lastDotIndex + 1);
                xmlWriter.WriteStartElement("file");
                xmlWriter.WriteAttributeString("name", fileName);
                xmlWriter.WriteAttributeString("type", fileExtension);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        // 10
        private static void MapDirectoryContentToXmlFileXDocument(string directoryPath, string xmlFileDirectory)
        {
            XElement element = MapInnerDirectoryContentToXmlFileXDocument(directoryPath);
            XDocument document = new XDocument(element);
            document.Save(xmlFileDirectory);
        }

        // 10
        private static XElement MapInnerDirectoryContentToXmlFileXDocument(string directoryPath)
        {
            string currentDirectory = directoryPath.Substring(directoryPath.LastIndexOf('\\') + 1);
            var currentDocument = new XElement("dir", new XAttribute("name", currentDirectory));

            var directories = Directory.EnumerateDirectories(directoryPath);
            foreach (var directory in directories)
            {
                currentDocument.Add(MapInnerDirectoryContentToXmlFileXDocument(directory));
            }

            var files = Directory.EnumerateFiles(directoryPath);
            foreach (var file in files)
            {
                string currentFileName = file.Substring(file.LastIndexOf('\\') + 1);
                int lastDotIndex = currentFileName.LastIndexOf('.');
                string fileName = currentFileName.Substring(0, lastDotIndex);
                string fileExtension = currentFileName.Substring(lastDotIndex + 1);

                var currentFile = new XElement("file", new XAttribute("name", fileName), new XAttribute("type", fileExtension));
                currentDocument.Add(currentFile);
            }

            return currentDocument;
        }

        // 11
        private static IDictionary<string, double> GetAlbumsPriceByDatePublishedXPath(XmlDocument doc, DateTime beforeDate)
        {
            var albumsByDate = new Dictionary<string, double>();
            XmlNode rootNode = doc.DocumentElement;
            var albums = rootNode.ChildNodes;
            var nodesToDelete = new List<XmlNode>();
            foreach (XmlNode album in albums)
            {
                string yearAsString = album["year"].InnerText;
                int year;
                bool isYearCorrect = int.TryParse(yearAsString, out year);

                if (isYearCorrect && year < beforeDate.Year)
                {
                    string priceAsString = album["price"].InnerText;
                    double price;
                    bool isPriceCorrect = double.TryParse(priceAsString, out price);
                    if (isPriceCorrect)
                    {
                        albumsByDate.Add(album["name"].InnerText, price);
                    }
                }
            }

            return albumsByDate;
        }

        // 12
        private static void GetAlbumsPriceByDatePublishedLinq(string filePath, DateTime beforeDate)
        {
            XDocument doc = XDocument.Load(filePath);
            int year;
            double price = 0;
            var albumsAndPrices =
                from album in doc.Descendants("album")
                where int.TryParse(album.Element("year").Value, out year) &&
                    year < beforeDate.Year &&
                    double.TryParse(album.Element("price").Value, out price)
                select new { Title = album.Element("name").Value, Price = price };

            foreach (var album in albumsAndPrices)
            {
                Console.WriteLine("Album: {0} Price: {1}", album.Title, album.Price);
            }
        }

        // 13
        private static void TransformXmlToHtml(string xmlFilePath, string xslFilePath, string htmlFilePath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslFilePath);
            xslt.Transform(xmlFilePath, htmlFilePath);
        }
    }
}
