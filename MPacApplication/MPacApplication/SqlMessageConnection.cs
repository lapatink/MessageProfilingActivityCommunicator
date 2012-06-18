using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MPacApplication
{
    class SqlMessageConnection
    {
        private string connection = "";
        private string table = "";
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        /// <summary>
        /// Instantiates an instance of the SqlMessageConnnection object.
        /// </summary>
        /// <param name="connection">The connection string for the database.</param>
        public SqlMessageConnection(string connection, string table)
        {
            this.connection = connection;
            conn = new SqlConnection(connection);
            this.table = table.Split(' ')[0].Trim(); //TODO: parameterize this
        }

        /// <summary>
        /// Reads the message table into a list of objects.
        /// </summary>
        /// <returns>Returns a list of Message objects.</returns>
        public List<Message> GetMessageList()
        {
            List<Message> messages = new List<Message>();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT id, version_major, version_minor, name, id_high, id_low, length, format FROM " + table, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string line = safeRead(reader, "id") + "," +
                        ((byte[])safeRead(reader, "version_major"))[0].ToString() + "," +
                        ((byte[])safeRead(reader, "version_minor"))[0].ToString() + "," +
                        safeRead(reader, "name") + "," +
                        ((byte[])safeRead(reader, "id_high"))[0].ToString() + "," +
                        ((byte[])safeRead(reader, "id_low"))[0].ToString() + "," +
                        ((byte[])safeRead(reader, "length"))[0].ToString() + "," +
                        safeRead(reader, "format");

                    Message m = new Message();

                    m.FromCSVString(line);
                    messages.Add(m);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
                cmd = null;
                reader = null;
            }

            return messages;
        }

        /// <summary>
        /// Writes the values of a Message object to the database in a new row.
        /// </summary>
        /// <param name="message">Message object to write from.</param>
        /// <returns>Returns true on success.</returns>
        public bool Write(Message message)
        {
            bool flag = true;
            try
            {
                conn.Open();
                cmd = new SqlCommand("INSERT INTO " + table + " (version_major, version_minor, name, id_high, id_low, length, format) " +
                    "VALUES (@version_major, @version_minor, @name, @id_high, @id_low, @length, @format)", conn);

                cmd.Parameters.AddWithValue("version_major", message.version_major);
                cmd.Parameters.AddWithValue("version_minor", message.version_minor);
                cmd.Parameters.AddWithValue("name", message.name);
                cmd.Parameters.AddWithValue("id_high", message.id_high);
                cmd.Parameters.AddWithValue("id_low", message.id_low);
                cmd.Parameters.AddWithValue("length", message.length);
                cmd.Parameters.AddWithValue("format", message.format);

                flag = (cmd.ExecuteNonQuery() > 0);

            }
            catch (Exception e)
            {
                flag = false;
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
                cmd = null;
            }
            return flag;
        }


        private object safeRead(SqlDataReader r, string s)
        {
            if (r[s] == DBNull.Value)
                return string.Empty;
            return r[s];
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Dispose();
            if (cmd != null)
                cmd.Dispose();
            if (reader != null)
                reader.Dispose();
        }

    }
}
