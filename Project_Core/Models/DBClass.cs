using System.Data;
using System.Data.SqlClient;

namespace Project_Core.Models
{
    public class DBClass
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-MLD832KF\SQLEXPRESS;database=ProjectDB;Integrated Security=true");

        public string InsertDB(Registeration objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("core_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@na", objcls.name);
                cmd.Parameters.AddWithValue("@ag", objcls.age);
                cmd.Parameters.AddWithValue("@addr", objcls.address);
                cmd.Parameters.AddWithValue("@em", objcls.email);
                cmd.Parameters.AddWithValue("@un", objcls.username);
                cmd.Parameters.AddWithValue("@pwd", objcls.password);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted Successfully!");
            }
            catch (Exception ex)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();  
                }
                return ex.Message.ToString();
            }
        }
        public string LoginDB(Registeration objcls)
        {
            try
            {
                string cid = "", msg = "";
                SqlCommand cmd = new SqlCommand("core_pview2", con);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(@"un", objcls.username);
                cmd.Parameters.AddWithValue(@"pwd", objcls.password);
                con.Open();
                cid = cmd.ExecuteScalar().ToString();
                con.Close();
                if (cid == "1")
                {
                    msg = "Success";
                }
                else
                {
                    msg = "Incorrect";
                }
                return msg;
            }
            catch(Exception ex)
            {
                if(con.State == ConnectionState.Open) 
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
        public List<BookTabs> BookDB(BookTabs objcls)
        {
            var list = new List<BookTabs>();
            try
            {
                SqlCommand cmd = new SqlCommand("core_viewbooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var o = new BookTabs
                    {
                        BookId = Convert.ToInt32(sdr["BookId"]),
                        BookName = sdr["BookName"].ToString(),
                        BookSummary = sdr["BookSummary"].ToString()
                    };
                    list.Add(o);
                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
        public Registeration ProfileDB(int id)
        {
            var getdata = new Registeration();
            try
            {
                SqlCommand cmd = new SqlCommand("core_profile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"eid", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getdata = new Registeration
                    {
                        eid = Convert.ToInt32(sdr["Id"]),
                        name = sdr["Name"].ToString(),
                        age = Convert.ToInt32(sdr["Age"]),
                        address = sdr["Address"].ToString(),
                        email = sdr["Email"].ToString(),
                    };
                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}
