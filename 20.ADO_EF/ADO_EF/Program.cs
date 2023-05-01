using ADO_EF.Data;
using ADO_EF.Models;
using ADO_EF.Services;
using System.Data;
using System.Data.SqlClient;

namespace ADO_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ADO.NET intro
            //string con = "server=MSI;database=ADONET;Trusted_connection=true;Integrated security=true;";
            //using (SqlConnection connection = new SqlConnection(con))
            //{    //non-query
            //    connection.Open();
            //    string cmd = "INSERT INTO Students VALUES('Revan','Isgenderov',20)";
            //    using (SqlCommand command = new SqlCommand(cmd, connection))
            //    {
            //        int result = command.ExecuteNonQuery();
            //        if (result > 0)
            //        {
            //            Console.WriteLine("Student successfully created");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Error occured");
            //        }
            //    }
            //    //query
            //    string qr = "SELECT * FROM Students";
            //    using (SqlDataAdapter query=new SqlDataAdapter(qr, connection))
            //    {
            //        DataTable table=new DataTable();
            //        query.Fill(table);

            //        foreach (DataRow tr in table.Rows)
            //        {
            //            Console.WriteLine(tr["Id"]+" "+tr["Name"] + " " + tr["Surname"]);
            //        }

            //    } 
            #endregion



            StudentService service = new StudentService(new Sql());

            Student student=new Student { Name="Natiq",Surname="Memmedov",Age=20};

            service.Add(student);




            var students=service.GetAllStudents();


            foreach (var item in students)
            {
                Console.WriteLine(item.Id+" "+item.Name+" "+item.Surname+" "+item.Age);
            }

        }
               

      
           
        


        
    }
}