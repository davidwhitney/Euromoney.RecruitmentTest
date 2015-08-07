using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string[] badWords = new string[] { "swine", "bad", "nasty", "horrible" };//can be obtained from datastore getBadWords() would call a stored procedure to return the latest set of bad words
            /*Along these line sorry this one happens to be MySql, but they are pretty similar
             public DataTable getQuestions(int categoryID)
        {
            DataTable dt = new DataTable();
            string query = "sp_getQuestions";

            using (MySqlConnection con = new MySqlConnection(cGlobal.CatsConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("category", categoryID);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                con.Close();
            }
            return dt;
        }*/
            string content =
               "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            ConsoleOutput noBad = new ConsoleOutput(badWords, content, false);//The trueShow boolean could be provided from a datastore
            noBad.SpaceText();
            ConsoleOutput withBad = new ConsoleOutput(badWords, content, true);//You wouldn't normally call them both!
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

    }

}
