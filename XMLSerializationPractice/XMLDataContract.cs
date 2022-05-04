using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace XMLSerializationPractice {
    class XMLDataContract {
        
        // Main Func
        static void Main(string[] args) {
            WriteXML();
            ReadXML();
        }
        

        // The Basic Data that will be stored
        [DataContract]
        public class Book {
            [DataMember(Name = "title")]
            public String title;
            [DataMember(Name = "author")]       // as far as I understand it the "Name" property is only used to overwrite the default name which is the name of the variable/datatype so this line of code is redundant
            private String author;

            public String Author {
                get { return author; }
                set { author = value; }
            }
        }

        // How to write data
        public static void WriteXML() {

            // Initialize the Data that we will store
            Book book1 = new Book();
            book1.title = "Serialization Overview";
            book1.Author = "John Doe";

            //Book book2 = new Book();
            //book2.title = "DataContract Overview";
            //book2.Author = "Jane Doe";

            Book book3 = new Book();
            book3.title = "A Third Book";
            book3.Author = "Bob Dillan";

            List<Book> library = new List<Book> { book1, /*book2,*/ book3 };

            // Create a serializer for the data type Book
            DataContractSerializer writer = new DataContractSerializer(typeof(List<Book>));

            // create the path in which the data will be stored
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//DataContractListOverview.xml";

            // use the path to create the file & a pointer to the file
            XmlWriter file = XmlWriter.Create(path);

            // write the book's data to the file & close the file pointer
            writer.WriteObject(file, library);
            file.Close();
        }

        // How to read data
        public static void ReadXML() {
            DataContractSerializer reader = new DataContractSerializer(typeof(List<Book>));

            // the path in which the data is stored
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//DataContractListOverview.xml";
            XmlReader file = XmlReader.Create(path);

            //Book overview = (Book)reader.ReadObject(file);
            List<Book> library = (List<Book>)reader.ReadObject(file);
            file.Close();

            //Console.WriteLine(overview.title);
            //Console.WriteLine(overview.Author);

            foreach (Book book in library) {
                Console.WriteLine("Title: " + book.title);
                Console.WriteLine("Author: " + book.Author + "\n");
            }
        }
    }
}
