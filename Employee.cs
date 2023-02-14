using System;
using System.Collections.Generic;
using System.Text;

namespace Organization
{
    internal class Employee
    {
       public static int empid = 1001;
        public DateTime dateofbirth ;
        public string[] dependents;
        public string empname;
        public  bool gender;
       public  static int nextempnumber;
        public  short noofdependents;

        static Employee()
        {
            nextempnumber = 1001;
        }
        public Employee()
        {
            nextempnumber = empid++;
            dependents  = new string[3];

        }

        public Employee (string empname,DateTime dateofbirth, bool gender)
        {
            this.empname = empname;
            this.dateofbirth = dateofbirth;
            this.gender = gender;
        }

        public Employee(string empname, DateTime dateofbirth, bool gender,short noofdependents)
        {
            this.empname = empname;
            this.dateofbirth = dateofbirth;
            this.gender = gender;
            if (noofdependents < 0)
            {
                this.noofdependents = 0;
            }
            else if (noofdependents > 3)
            {
                this.noofdependents = 3;
            }
            else
            {
                this.noofdependents = noofdependents;
            }
        }

        public short addependent(string dependentname)
        {
           if(noofdependents<3)
            {
                dependents[noofdependents++] = dependentname;
                return noofdependents;
            }
            else
            {
                return 0;
            }
        }

        public bool updatedependents(string dependentname,int dependentid)
        {
            if(dependentid >0 && dependentid <= noofdependents)
            {
                dependents[dependentid - 1] = dependentname;
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
