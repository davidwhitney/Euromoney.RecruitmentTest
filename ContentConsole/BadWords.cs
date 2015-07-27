using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class BadWords
    {
        public void GetBadWords()
        {
            List<string> bad_words_list = new List<string>();

            using (SqlConnection connection = new SqlConnection("place your connection string here"))
            {
                string query = "SELECT Column1 FROM Table1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bad_words_list.Add(reader.GetString(0));
                        }
                    }
                }
            }
            Variables.SetList(bad_words_list);
        }

        public void AddBadWord(string new_word)
        {
            string insert = "INSERT INTO Tabel1 (Column1) VALUES (@new_word)";

            using (SqlConnection connection = new SqlConnection("place your connection string here"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insert, connection))
                {
                    command.Parameters.AddWithValue("@new_word", new_word);
                    command.ExecuteNonQuery();
                }           
            }
        }
    }
}



