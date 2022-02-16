using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.Repositories
{
    internal class NoteRepository : DatabaseConnector, IRepository<Note>
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public List<Note> GetAll()
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
                                          FROM Note";

                    List<Note> noteEntries = new List<Note>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Note entry = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };
                        noteEntries.Add(entry);
                    }
                    reader.Close();

                    return noteEntries;
                }
            }
        }

        public Note Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())

                {
                    cmd.CommandText = @"SELECT n.Id AS JournalId,
                                               n.Title,
                                               n.Content,
                                               n.CreateDateTime,
                                               n.Id AS TagId,
                                               n.Name
                                          FROM Note n
                                               LEFT JOIN NoteTag nt on n.Id = nt.NoteId
                                               LEFT JOIN Tag n on n.Id = nt.TagId
                                          WHERE n.id = @id";


                    Note entry = null;

                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (entry == null)
                        {
                            entry = new Note()
                            {
                                Id = id,
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                            };
                        }
                    }

                    reader.Close();

                    return entry;
                }
            }
        }

        public void Insert(Note entry)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title, Content, CreateDateTime )
                                                     VALUES (@title, @content, @createDateTime)";
                    cmd.Parameters.AddWithValue("@title", entry.Title);
                    cmd.Parameters.AddWithValue("@content", entry.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", entry.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
