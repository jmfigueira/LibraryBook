using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryModel.DB
{
    public class BookRepository : AbstractRepository<Book, int>
    {
        public override void Delete(Book entity)
        {
            using (var connection = new SqlConnection(StringConnection))
            {
                const string sql = "DELETE Book Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public override void DeleteById(int id)
        {
            using (var connection = new SqlConnection(StringConnection))
            {
                const string sql = "DELETE Book Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public override List<Book> GetAll(string order = null, string type = null)
        {
            var sql = "Select Id, Title, Author, Description, Width, Height, Language, Launch, Price, PublishingCompany, Tradutor FROM Book ORDER BY " + order + " " + type;
            using (var connection = new SqlConnection(StringConnection))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                List<Book> list = new List<Book>();
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var b = new Book
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Description = reader["Description"].ToString(),
                                Width = Convert.ToDouble(reader["Width"]),
                                Height = Convert.ToDouble(reader["Height"]),
                                Language = reader["Language"].ToString(),
                                Launch = Convert.ToDateTime(reader["Launch"]),
                                Price = Convert.ToDouble(reader["Price"]),
                                PublishingCompany = reader["PublishingCompany"].ToString(),
                                Tradutor = reader["Tradutor"].ToString()
                            };
                            list.Add(b);
                        }
                    }
                }
                catch
                {
                    return null;
                }
                return list;
            }
        }

        public override Book GetById(int id)
        {
            using (var connection = new SqlConnection(StringConnection))
            {
                const string sql = "Select Id, Title, Author, Description, Width, Height, Language, Launch, Price, PublishingCompany, Tradutor FROM Book WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Book b = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                b = new Book
                                {
                                    Id = (int)reader["Id"],
                                    Title = reader["Title"].ToString(),
                                    Author = reader["Author"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Width = Convert.ToDouble(reader["Width"]),
                                    Height = Convert.ToDouble(reader["Height"]),
                                    Language = reader["Language"].ToString(),
                                    Launch = Convert.ToDateTime(reader["Launch"]),
                                    Price = Convert.ToDouble(reader["Price"]),
                                    PublishingCompany = reader["PublishingCompany"].ToString(),
                                    Tradutor = reader["Tradutor"].ToString()
                                };
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }
                return b;
            }
        }

        public override void Save(Book entity)
        {
            using (var connection = new SqlConnection(StringConnection))
            {
                const string sql = "INSERT INTO Book (Title, Author, Description, Width, Height, Language, Launch, Price, PublishingCompany, Tradutor) VALUES (@Title, @Author, @Description, @Width, @Height, @Language, @Launch, @Price, @PublishingCompany, @Tradutor)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@Author", entity.Author);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Width", entity.Width);
                cmd.Parameters.AddWithValue("@Height", entity.Height);
                cmd.Parameters.AddWithValue("@Launch", entity.Launch);
                cmd.Parameters.AddWithValue("@Language", entity.Language);
                cmd.Parameters.AddWithValue("@Price", entity.Price);
                cmd.Parameters.AddWithValue("@PublishingCompany", entity.PublishingCompany);
                cmd.Parameters.AddWithValue("@Tradutor", entity.Tradutor);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public override void Update(int id, Book entity)
        {
            using (var connection = new SqlConnection(StringConnection))
            {
                const string sql = "UPDATE Book SET Title=@Title, Author=@Author, Description=@Description, Width=@Width, Height=@Height, Language=@Language, Launch=@Launch, Price=@Price, PublishingCompany=@PublishingCompany, Tradutor=@Tradutor Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Author", entity.Author);
                cmd.Parameters.AddWithValue("@Width", entity.Width);
                cmd.Parameters.AddWithValue("@Height", entity.Height);
                cmd.Parameters.AddWithValue("@Launch", entity.Launch);
                cmd.Parameters.AddWithValue("@Language", entity.Language);
                cmd.Parameters.AddWithValue("@Price", entity.Price);
                cmd.Parameters.AddWithValue("@PublishingCompany", entity.PublishingCompany);
                cmd.Parameters.AddWithValue("@Tradutor", entity.Tradutor);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
