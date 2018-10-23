using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entity;
using Reviews.DAL.Interface;

namespace Reviews.DAL.DAO
{
    public class ReviewDao : IReviewDao
    {
        private readonly string _connectionString;

        public ReviewDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Reviews"].ConnectionString;
        }

        public void AddReview(int userId, Review review)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddReview";

                var sqlUserId = new SqlParameter("@userId", SqlDbType.Int)
                {
                    Value = userId
                };

                var name = new SqlParameter("@name", SqlDbType.VarChar)
                {
                    Value = review.Name
                };


                var comment = new SqlParameter("@comment", SqlDbType.VarChar)
                {
                    Value = review.Comment
                };


                command.Parameters.AddRange(new[] {sqlUserId, name, comment});

                connection.Open();

                command.ExecuteScalar();
            }
        }

        public int DeleteReview(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteReview";

                var userId = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                return (int) command.ExecuteNonQuery();
            }
        }

        public Review GetReviewById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetReviewById";

                var userId = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new Review
                    {
                        Id = (int) reader["Id"],
                        Name = (string) reader["Name"],
                        Comment = (string) reader["Comment"]
                    };
                }
            }

            return null;
        }

        public IEnumerable<Review> GetReviews()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetReviews";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Review
                    {
                        Id = (int) reader["Id"],
                        Name = (string) reader["Name"],
                        Comment = (string) reader["Comment"]
                    };
                }
            }
        }

        public IEnumerable<Review> GetReviewsForUsers(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllReviewsForUser";

                var userId = new SqlParameter("@userId", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Review
                    {
                        Id = (int) reader["Id"],
                        Name = (string) reader["Name"],
                        Comment = (string) reader["Comment"]
                    };
                }
            }
        }

        public int UpdateReview(int id, string name, string comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateReview";

                var userid = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = id
                };

                var userName = new SqlParameter("@name", SqlDbType.VarChar)
                {
                    Value = name
                };

                var userComment = new SqlParameter("@comment", SqlDbType.VarChar)
                {
                    Value = comment
                };

                command.Parameters.AddRange(new[] {userid, userName, userComment});

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }
    }
}