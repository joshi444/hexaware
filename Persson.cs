using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace School_management
{
    class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public Person(int id, string name, string address, long phone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;

        }
        public virtual string Getdetails()
        {
            return $"id:{id},name:{name},address:{address},phone:{phone}";
        }
    }
    class Student : Person
    {

        public int classname { get; set; }
        public float marks { get; set; }
        public string grade { get; set; }
        public float fees { get; set; }


        public Student(int id, string name, string address, long phone, int classname, float marks, string grade, float fees) : base(id, name, address, phone)
        {


            this.classname = classname;
            this.marks = marks;
            this.grade = grade;
            this.fees = fees;

        }
        public override string Getdetails()
        {
            return $"{base.Getdetails()},{classname}:classname,marks:{marks},grade:{grade},fees:{fees}";
        }


    }
    class Staff : Person
    {
        public string designation { get; set; }
        public int salary { get; set; }
        public Staff(int id, string name, string address, long phone, string designation, int salary) : base(id, name, address, phone)
        {
            this.designation = designation;
            this.salary = salary;
        }
        public override string Getdetails()
        {
            return $"{base.Getdetails()},{designation}:designation,{salary}:salary";
        }
    }
    class Teachingstaff : Staff
    {


        public string qualification { get; set; }
        public string subject { get; set; }
        public Teachingstaff(int id, string name, string address, long phone, string designation, int salary, string qualification, string subject) : base(id, name, address, phone, designation, salary)
        {
            this.qualification = qualification;
            this.subject = subject;

        }
        public override string Getdetails()
        {
            return $"{base.Getdetails()},{qualification}:qualification,{subject}:subject";
        }

    }
    class NonTeachingstaff : Staff
    {

        public string deptname { get; set; }
        public int managerid { get; set; }
        public NonTeachingstaff(int id, string name, string address, long phone, string designation, int salary, string deptname, int managerid) : base(id, name, address, phone, designation, salary)
        {
            this.deptname = deptname;
            this.managerid = managerid;
        }
        public override string Getdetails()
        {
            return $"{base.Getdetails()},{deptname}:deptname,{managerid}:managerid";
        }
    }

}
