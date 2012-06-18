using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MPacApplication
{
    static class Export
    {
        private static StreamWriter writer = null;
        private static string header = "id, version_major, version_minor, name, id_high, id_low, length, format";

        /// <summary>
        /// Export a set of messages to a csv file.
        /// </summary>
        /// <param name="messages">List of Message objects.</param>
        /// <param name="filename">Filename and directory to export to.</param>
        /// <returns>Returns true on success.</returns>
        public static bool FromMessages(List<Message> messages, string filename)
        {
            try
            {
                writer = new StreamWriter(filename);
                writer.WriteLine(header);
                foreach (Message m in messages)
                    writer.WriteLine(m.ToCSVString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
            return true;

        }
        /// <summary>
        /// Export a formatted string to a csv file.
        /// </summary>
        /// <param name="csvString">String to write to file.</param>
        /// <param name="filename">Filename and directory to export to.</param>
        /// <returns>Returns true on success.</returns>
        public static bool FromString(string csvString, string filename)
        {
            try
            {
                writer = new StreamWriter(filename);
                writer.WriteLine(header);
                writer.Write(csvString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
            return true;
        }

    }
}
