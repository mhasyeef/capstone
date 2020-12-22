﻿using System;
using System.Collections.Generic;

namespace ConstosoModel
{
    public class Course
    {

        private string _name; // variables
        public string name
        {
            get { return _name; }
            set
            {
                // logic
                _name = value;
            }
        }

        public int id { get; set; }
        public List<Student> students { get; set; } = new List<Student>();

        public double CalculateAverage()
        {
            if (students.Count == 0) { return 0; }
            int runningtotal = 0;
            foreach (Student stud in students)
            {
                runningtotal = stud.marks + runningtotal;
            }
            return (runningtotal / students.Count);
        }

        public bool Validate()
        {

            return true;
        }

    }
    public class Student
    {

        public int id { get; set; }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _marks;

        public int marks
        {
            get { return _marks; }
            set { _marks = value; }
        }

        private string _courseName;

        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        public bool Validate()
        {
            return true;
        }

        public int courseId { get; set; }
    }
}
