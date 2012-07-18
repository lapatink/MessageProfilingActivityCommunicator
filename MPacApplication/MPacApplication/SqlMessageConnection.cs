﻿using System;
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
        /// <param name="table">The database table to read/write to/from.</param>
        public SqlMessageConnection(string connection, string table)
        {
            this.connection = connection;
            conn = new SqlConnection(this.connection);
            this.table = table.Split(' ')[0].Trim(); //TODO: parameterize this
        }

        /// <summary>
        /// Instantiates an instance of the SqlMessageConnection
        /// </summary>
        /// <param name="connection">The complete connection string from the configuration file.</param>
        public SqlMessageConnection(string connection)
        {
            this.connection = connection.Substring(0, connection.LastIndexOf(';') + 1);
            conn = new SqlConnection(this.connection);
            this.table = connection.Substring(connection.LastIndexOf(';') + 1);
            this.table = this.table.Split(' ')[0].Trim(); //TODO: parameterize this

        }

        /// <summary>
        /// Reads the message table into a list of objects.
        /// </summary>
        /// <returns>Returns a list of Message objects.</returns>
        public List<MessageFormat> GetMessageList()
        {
            List<MessageFormat> messages = new List<MessageFormat>();
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

                    MessageFormat m = new MessageFormat();

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
                if (conn!=null)
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
        public bool Write(MessageFormat message)
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

        public bool Remove(int id)
        {
            bool flag = true;
            try
            {
                conn.Open();
                cmd = new SqlCommand("DELETE FROM " + table + " WHERE id = @id", conn);

                cmd.Parameters.AddWithValue("id", id);

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

        public bool Remove(MessageFormat m)
        {
            return Remove(m.Id);
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
