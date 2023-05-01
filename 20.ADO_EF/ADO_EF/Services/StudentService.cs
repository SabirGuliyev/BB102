using ADO_EF.Data;
using ADO_EF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF.Services
{
    internal class StudentService
    {
        private Sql _dataBase;
        public StudentService(Sql dataBase)
        {
            _dataBase = dataBase;
        }

        public void Add(Student student)
        {
            string command = $"INSERT INTO Students VALUES('{student.Name}','{student.Surname}',{student.Age}) ";
            _dataBase.ExecuteCommand(command);
        }

        public void Delete(int id)
        {
            string command = $"DELETE FROM Students WHERE Id={id}";
            _dataBase.ExecuteCommand(command);
        }

        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM Students";
            DataTable table=_dataBase.ExecuteQuery(query);


            List<Student> students = new List<Student>();

            foreach (DataRow item in table.Rows)
            {
                Student student = new Student
                {
                    Id = Convert.ToInt32(item["Id"]),
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    Age = Convert.ToInt32(item["Age"])
                };
                students.Add(student);
            }

            return students;

        }
    }
}
