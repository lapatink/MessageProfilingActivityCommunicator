using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MPACApplication
{
    class Configuration //I might make this static later
    {
        private const int CONNECTION_LIMIT = 10;
        private string connectionString = string.Empty;
        private string filename = "config.xml";
        private Connection[] connections = new Connection[CONNECTION_LIMIT];
        private int count = -1;
        public int Count
        {
            get { return count; }
        }

        public Configuration()
        {

        }
        public Configuration(string filename)
        {
            this.filename = filename;
        }
        public string[] Read()
        {
            XmlReader reader = XmlReader.Create(filename);
            bool flag = true;

            while (reader.Read() && flag)
            {
                if (!reader.IsStartElement())
                    continue;

                switch (reader.Name)
                {
                    case "file":
                        Configuration config = new Configuration(reader.ReadInnerXml());
                        config.Read();
                        Connection[] conn = config.connections;

                        foreach (Connection c in conn)
                        {
                            if (c == null)
                                break;
                            count++;
                            if (count > CONNECTION_LIMIT)
                            {
                                flag = false;
                                break;
                            }

                            connections[count] = c;
                        }
                        break;
                    case "connection":
                        count++;

                        if (count > CONNECTION_LIMIT)
                        {
                            flag = false;
                            break;
                        }
                        connections[count] = new Connection();
                        break;
                    case "source":
                        connections[count].source = reader.ReadInnerXml();
                        break;
                    case "catalog":
                        connections[count].catalog = reader.ReadInnerXml();
                        break;
                    case "table":
                        connections[count].table = reader.ReadInnerXml();
                        break;
                    case "user":
                        connections[count].user = reader.ReadInnerXml();
                        break;
                    case "password":
                        connections[count].password = reader.ReadInnerXml();
                        break;
                    case "config":
                        break;
                    default:
                        Console.WriteLine("Configuration defaulted and received the node " + reader.Name + ".");
                        break;
                }

            }

            string[] s = new string[count + 1];

            for (int i = 0; i <= count; i++)
                s[i] = connections[i].getConnectionString();

            return s;

        }

        #region Nested Connection Class

        private class Connection
        {
            public string table = "";
            public string catalog = "";
            public string user = "";
            public string password = "";
            public string source = "";

            public string getConnectionString()
            {
                return "Data Source=" + source + ";Initial Catalog=" + catalog + ";User ID=" + user + ";Password=" + password + ";";
            }
        }

        #endregion

    }




}

