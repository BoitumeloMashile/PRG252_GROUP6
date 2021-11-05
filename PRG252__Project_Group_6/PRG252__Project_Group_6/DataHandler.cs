using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace PRG252__Project_Group_6
{
    class DataHandler
    {
        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
      
        public DataHandler()
        {
                connection.DataSource = @"DESKTOP-TP8Q05K\SQLEXPRESS";
                connection.InitialCatalog = "BelgiumCampusStudents";
                connection.IntegratedSecurity = true;
            
        }


        public DataSet ReadData(string tableName)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT * FROM {0}", tableName);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, tableName);
                adapter.Fill(rawData, tableName);

            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return rawData;

        }

        public void InsertStudent(int studentNumber, string studentName, string studentSurname, int dateOfBirth, string gender, int phone, string address, string moduleCode) 
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " + "tbl_Students (studentNumber,studentName, studentSurname, dateOfBirth, gender, phone, address, moduleCode)" + "VALUES ('{0}','{1}',{2},{3},'{4}',{5}'{6}')", studentName, studentSurname, dateOfBirth, gender, phone, address, moduleCode);
            using (SqlCommand command = new SqlCommand(qry, conn))
            {
                command.Parameters.AddWithValue("@studentNumber", studentNumber);
                command.Parameters.AddWithValue("@studentName", studentName);
                command.Parameters.AddWithValue("@studentSurname", studentSurname);
                command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@moduleCode", moduleCode);
                command.ExecuteNonQuery();
                MessageBox.Show("Data has been sucessfully");
            }
        }

        public void UpdateStudent(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE tbl_Student SET studentName = '{0}', " +
                "studentNumber = '{1}' studentName = '{2}', studentSurname = {3} , dateOfBirth ={4} , gender = '{5}', phone ={6} , address = '{7}', moduleCode = '{8}'"
                , list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8]);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        public void DeleteStudent(int studentNumber, string studentName, string studentSurname, int dateOfBirth, string gender, int phone, string address, string moduleCode)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE FROM tbl_Students WHERE studentNumber = {0}", studentNumber);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetStudent(int StudentNumber)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT studentNumber,studentName, studentSurname, dateOfBirth, gender, phone, address, moduleCode FROM tbl_Students INNER JOIN ", StudentNumber);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, "tbl_Student");
                adapter.Fill(rawData, "tbl_Student");
            }
            catch (SqlException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return rawData;

        }

        public void CreateModule(string moduleCode, string moduleName, string moduleDescription, string links)
        {

            using (SqlConnection conn = new SqlConnection(connection.ToString()))
            {
                conn.Open();
                string qry = string.Format("INSERT INTO " +
                "tbl_Modules (ModuleCode,ModuleName,ModuleDescription,Links)" +
                " VALUES (@moduleCode,@moduleName,@moduleDescription,@links)");
                using (SqlCommand command = new SqlCommand(qry, conn))
                {
                    command.Parameters.AddWithValue("@moduleCode", moduleCode);
                    command.Parameters.AddWithValue("@moduleName", moduleName);
                    command.Parameters.AddWithValue("@moduleDescription", moduleDescription);
                    command.Parameters.AddWithValue("@links", links);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully inserted data");
                }

            }


        }



        public void UpdateModuleTable(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE tbl_Modules SET ModuleName = '{0}', " +
                "ModuleDescription = '{1}', Links = '{2}' WHERE ModuleCode = '{3}' "
                , list[0], list[1], list[2], list[3]);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        public void DeleteModules(string moduleCode)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE FROM tbl_Module WHERE Module = {0}", moduleCode);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetRelatedModules(string moduleCode)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT ModuleCode, ModuleName, ModuleDescription, Link FROM tbl_Modules WHERE tbl_Module.ModuleCode = '{0}'", moduleCode);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, "tbl_Module");
                adapter.Fill(rawData, "tbl_Module");
            }
            catch (SqlException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return rawData;

        }




    }
}
