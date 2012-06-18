using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MPacApplication
{
    static class Import
    {
        private static StreamReader reader = null;

        /// <summary>
        /// Import a csv file into a list of message objects.
        /// </summary>
        /// <param name="filename">The filename and directory to import from.</param>
        /// <returns>Returns a list of messages</returns>
        public static List<MessageFormat> ToMessages(string filename)
        {
            List<MessageFormat> messages = new List<MessageFormat>();

            try
            {
                reader = new StreamReader(filename);
                reader.ReadLine(); // trash header line
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    messages.Add(new MessageFormat(line));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                reader = null;
            }
            return messages;
        }
    }
}
