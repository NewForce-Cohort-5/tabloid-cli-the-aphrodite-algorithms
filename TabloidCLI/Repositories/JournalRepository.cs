using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    public class JournalRepository : DatabaseConnector, IRepository<Journal>
    {
        public JournalRepository(string connectionString) : base(connectionString) { }

        public List<Journal> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               Title,
                                               Content,
                                               CreateDateTime
                                          FROM Journal";

                    List<Journal> journalEntries = new List<Journal>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Journal journalEntry = new Journal()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };
                        journalEntries.Add(journalEntry);
                    }

                    reader.Close();

                    return journalEntries;
                }
            }
        }

        public Journal Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT j.Id AS JournalId,
                                               j.Title,
                                               j.Content,
                                               j.CreateDateTime,
                                               t.Id AS TagId,
                                               t.Name
                                          FROM Journal j
                                               LEFT JOIN JournalTag jt on j.Id = jt.JournalId
                                               LEFT JOIN Tag t on t.Id = jt.TagId
                                          WHERE j.id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    Journal journalEntry = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (journalEntry == null)
                        {
                            journalEntry = new Journal()
                            {
                                Id = id,
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                            };
                        }

                    }

                    reader.Close();

                    return journalEntry;
                }
            }
        }

        public void Insert(Journal journalEntry)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Journal (Title, Content, CreateDateTime )
                                                     VALUES (@Title, @Content, @CreateDateTime)";
                    cmd.Parameters.AddWithValue("@Title", journalEntry.Title);
                    cmd.Parameters.AddWithValue("@Content", journalEntry.Content);
                    cmd.Parameters.AddWithValue("@CreateDateTime", journalEntry.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Journal journalEntry)
        {
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"UPDATE Journal 
        //                                   SET Title = @Title,
        //                                       Content = @Content
        //                                 WHERE id = @id";

        //            cmd.Parameters.AddWithValue("@Title", journalEntry.Title);
        //            cmd.Parameters.AddWithValue("@Content", journalEntry.Content);
        //            cmd.Parameters.AddWithValue("@id", journalEntry.Id);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        }

        public void Delete(int id)
        {
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"DELETE FROM Journal WHERE id = @id";
        //            cmd.Parameters.AddWithValue("@id", id);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        }

        //public void InsertTag(Author author, Tag tag)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"INSERT INTO AuthorTag (AuthorId, TagId)
        //                                               VALUES (@authorId, @tagId)";
        //            cmd.Parameters.AddWithValue("@authorId", author.Id);
        //            cmd.Parameters.AddWithValue("@tagId", tag.Id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void DeleteTag(int authorId, int tagId)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"DELETE FROM AuthorTAg 
        //                                 WHERE AuthorId = @authorid AND 
        //                                       TagId = @tagId";
        //            cmd.Parameters.AddWithValue("@authorId", authorId);
        //            cmd.Parameters.AddWithValue("@tagId", tagId);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
