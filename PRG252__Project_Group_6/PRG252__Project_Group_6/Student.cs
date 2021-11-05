using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace PRG252__Project_Group_6
{
    class Student
    {
        int studentNumber;
        string studentName;
        string studentSurname;
        int dateOfBirth;
        string gender;
        int phone;
        string address;
        string moduleCode;

        public int StudentNumber { get => studentNumber; set => studentNumber = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public string StudentSurname { get => studentSurname; set => studentSurname = value; }
        public int DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string ModuleCode { get => moduleCode; set => moduleCode = value; }

        public Student(int studentNumber, string studentName, string studentSurname, int dateOfBirth, string gender, int phone, string address, string moduleCode)
        {
            this.studentNumber = studentNumber;
            this.studentName = studentName;
            this.studentSurname = studentSurname;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.moduleCode = moduleCode;
        }

        public Student()
        { }

        public void InsertStudent(int studentNumber, string studentName, string studentSurname, int dateOfBirth, string gender, int phone, string address, string moduleCode)
        {
            DataHandler db = new DataHandler();
            db.InsertStudent(studentNumber, studentName, studentSurname, dateOfBirth, gender, phone, address, moduleCode);
        }

        public void UpdateStudent(ArrayList list)
        {
            DataHandler db = new DataHandler();
            db.UpdateStudent(list);
        }

        public void DeleteStudent(int studentNumber)
        {
            DataHandler db = new DataHandler();
            db.DeleteStudent(studentNumber, studentName, studentSurname, dateOfBirth, gender, phone, address, moduleCode);
        }


        public List<Student> PopulateStudents()
        {
            List<Student> studentList = new List<Student>();
            DataHandler db = new DataHandler();
            DataSet rawData = db.ReadData("tbl_Student");
            foreach (DataRow item in rawData.Tables["tbl_Student"].Rows)
            {

                studentList.Add(
                    new Student(int.Parse(item["studentNumber"].ToString()),
                    item["studentName"].ToString(),
                    item["studentSurname"].ToString(),
                    int.Parse(item["dateOfBirth"].ToString()),
                    item["gender"].ToString(),
                    int.Parse(item["phone"].ToString()),
                    item["gender"].ToString(),
                    item["module"].ToString()));
            }



            return studentList;
        }

        public List<Student> GetStudent(int studentNumber)
        {
            List<Student> studentList = new List<Student>();
            DataHandler db = new DataHandler();
            DataSet ds = db.GetStudent(studentNumber);
            foreach (DataRow item in ds.Tables["tbl_Student"].Rows)
            {
                studentList.Add(
              new Student(int.Parse(item["studentNumber"].ToString()),
              item["studentName"].ToString(),
              item["studentSurname"].ToString(),
              int.Parse(item["dateOfBirth"].ToString()),
              item["gender"].ToString(),
              int.Parse(item["phone"].ToString()),
              item["gender"].ToString(),
              item["module"].ToString()));
            }

            return studentList;
        }
    }

    

}