using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CrudWindowsFormADO.net
{
    public class peopledb
    {


        private string connectionString = "Data Source=LAPTOP-AUJ2U0CR; Initial Catalog=crudWindowsForm; Integrated Security=SSPI";


        public bool Ok()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
            }
            catch
            {

                return false;
            }
            return true;
            
        }


        public List<People> Get()
        {
            List<People> people = new List<People>();

            string query = "select id,name,age from people";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        People oPeaple = new People();
                        oPeaple.id = reader.GetInt32(0);
                        oPeaple.name = reader.GetString(1);
                        oPeaple.age = reader.GetInt32(2);
                        people.Add(oPeaple);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                }
            }

            return people;
        }

        public People Get(int Id)
        {
       

            string query = "select id,name,age from people" + "where is=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    
                        People oPeaple = new People();
                        oPeaple.id = reader.GetInt32(0);
                        oPeaple.name = reader.GetString(1);
                        oPeaple.age = reader.GetInt32(2);
                        reader.Close();
                        connection.Close();
                        return oPeaple;

                    
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                }

                return null;
            }

            
        }


        public void Add(int Id, string Name, int Age)
        {
            string query = "insert into people(id,name,age) values"+"(@id,@name,@age)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Age);
                try
                {
                    connection.Open();
                   command.ExecuteNonQuery();
      
                    connection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                }
            }
        }
    }

    public class People
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
