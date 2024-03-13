using Microsoft.Data.SqlClient;
using RunLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.Repository
{
    internal class MemberRepositoryDB : IMemberRepository
    {

        private const String insertSql = "insert into RunningMember values(@Name,@Mobile,@Team,@Price)";
        public void Add(Member Members)
        {
            SqlConnection connection = new SqlConnection(Secret.GetConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(insertSql, connection);
            cmd.Parameters.AddWithValue("@Name", Members.Name);
            cmd.Parameters.AddWithValue("@Phone", Members.Mobile);
            cmd.Parameters.AddWithValue("@Team", Members.Team);
            cmd.Parameters.AddWithValue("@Price", Members.Price);

            int row = cmd.ExecuteNonQuery();
            Console.WriteLine("Rows affected " + row);


            connection.Close();

        }


        public List<Member> GetAll()
        {
            List<Member> Members = new List<Member>();

            SqlConnection connection = new SqlConnection(Secret.GetConnectionString);
            connection.Open();

            String sql = "select * from RunningMember";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Member members = ReadMembers(reader);
                Members.Add(members);
            }

            connection.Close();
            return Members;
        }


        private Member ReadMembers(SqlDataReader reader)
        {
            Member members = new Member();

            members.Id = reader.GetInt32(0);
            members.Name = reader.GetString(1);
            members.Mobile = reader.GetString(2);
            members.Team = reader.GetString(3);
            members.Price = reader.GetDouble(4);

            return members;
        }

        private Member GetById(int id)
        {
            SqlConnection connection = new SqlConnection(Secret.GetConnectionString);
            connection.Open();

            string getByIdSql = "SELECT * FROM RunningMember WHERE Id = @Id";
            using (SqlCommand getByIdCmd = new SqlCommand(getByIdSql, connection))
            {
                getByIdCmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = getByIdCmd.ExecuteReader();
                if (reader.Read())
                {
                    return ReadMembers(reader);

                }

                connection.Close();
                return Member;
            }
        }

        public List<Member> Search(int? id, string? name, string? team)
        {
            throw new NotImplementedException();
        }

        public Member Update(int id, Member member)
        {
            throw new NotImplementedException();
        }
        Member IMemberRepository.Add(Member m)
        {
            throw new NotImplementedException();
        }

        Member IMemberRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Member Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
