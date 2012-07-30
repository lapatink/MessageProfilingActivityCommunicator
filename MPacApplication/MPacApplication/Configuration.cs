using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MPacApplication
{
    class Configuration
    {
        #region Member Variables
        private const int CONNECTION_LIMIT = 10;
        private string connectionString = string.Empty;
        private string filename = "config.xml";
        private Connection[] connections = new Connection[CONNECTION_LIMIT];
        private int count = -1;
        private bool isAdmin = false;
        /// <summary>
        /// The number of database connections found in the configuration files. Default value is -1.
        /// </summary>
        public int Count
        {
            get { return count; }
        }
        /// <summary>
        /// Is the user authorized as an administrator?
        /// </summary>
        public bool IsAdministrator
        {
            get { return isAdmin; }
        }
        #endregion

        public Configuration()
        {

        }
        public Configuration(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Reads all relevant configuration files. The default file is config.xml in the current directory.
        /// </summary>
        /// <returns>Returns an array of connection strings with the table name concatenated at the end.</returns>
        public string[] Read()
        {
            XmlReader reader = null;
            try { reader = XmlReader.Create(filename); }
            catch { }
            bool flag = true;
            if (reader != null)
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
                    case "admin":
                        isAdmin = (reader.ReadInnerXml() == "true" ? true : false);
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
                return "Data Source=" + source + ";Initial Catalog=" + catalog + ";User ID=" + user + ";Password=" + password + ";" + table;
            }
        }

        #endregion

    }




}

