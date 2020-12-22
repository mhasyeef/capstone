using ConstosoModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CourseStudentDataAccess
    {
        private string connectionString = "Data Source=DESKTOP-FB05FVS;Initial Catalog=ContonsoConsoleDB;Integrated Security=True";
        public bool SaveCourse(Course obj)
        {
            
            SqlConnection conn = new SqlConnection(connectionString);       // 1. Open Connection
            conn.Open();
            SqlCommand comm = new SqlCommand();         // 2. Create SQL insert into
            comm.CommandText = "insert into tblCourse(coursename) values('" + obj.name + "')";
            comm.Connection = conn;
            comm.ExecuteNonQuery();     // 3. Executed
            conn.Close();               // 4. Close Connection
            return true;

        }

        public bool SaveStudent(Student obj)
        {

            SqlConnection conn = new SqlConnection(connectionString);       // 1. Open Connection
            conn.Open();
            SqlCommand comm = new SqlCommand();         // 2. Create SQL insert into
            comm.CommandText = "insert into tblStudent(studentname, studentmarks, courseid_fk) values('"
                                + obj.name + "'," + obj.marks + "," + obj.courseId + ")";
            comm.Connection = conn;
            comm.ExecuteNonQuery();     // 3. Executed
            conn.Close();               // 4. Close Connection
            return true;

        }
        public int FindCourse(string courseName)
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select Id from tblCourse where CourseName='" + courseName +"'";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            dr.Read(); //go to first row and get the id
            int id = Convert.ToInt32(dr["id"]);
            conn.Close();
            return id;
            
        }
        public List<Course> getCourses()
        {
            List<Course> courses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select id, CourseName from tblCourse";
            comm.Connection = conn;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Course temp = new Course();
                temp.id = Convert.ToInt32(dr["id"]);
                temp.name = dr["CourseName"].ToString();
                courses.Add(temp);
            }
            conn.Close();
            return courses;
        }
        


    
    }
    
}
