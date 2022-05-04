using System;
using System.Xml.Serialization;
using System.IO;

namespace XMLSerializationPractice {
    public class XMLSerialize {
        /*
        // Main Func
        static void Main(string[] args) {
            WriteXML();
            ReadXML();
        }
        */

        // The Basic Data that will be stored
        [Serializable()]
        public class Book {
            public String title;
            private String author;
            
            public String Author {
                get { return author; }
                set { author = value; }
            }
        }

        // How to write data
        public static void WriteXML() {

            // Initialize the Data that we will store
            Book overview = new Book();
            overview.title = "Serialization Overview";
            overview.Author = "John Doe";
            

            // Create a serializer for the data type Book
            XmlSerializer writer = new XmlSerializer(typeof(Book));
            
            // create the path in which the data will be stored
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            
            // use the path to create the file & a pointer to the file
            FileStream file = File.Create(path);
            
            // write the book's data to the file & close the file pointer
            writer.Serialize(file, overview);
            file.Close();
        }

        // How to read data
        public static void ReadXML() {
            XmlSerializer reader = new XmlSerializer(typeof(Book));

            // the path in which the data is stored
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            StreamReader file = new StreamReader(path);

            Book overview = (Book)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.title);
            Console.WriteLine(overview.Author);
        }
    }
}
