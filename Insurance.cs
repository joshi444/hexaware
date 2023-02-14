using System;
using System.Collections.Generic;
using System.Text;

namespace Insurancecompany
{
    internal class Insurance
    {
        public int age;
        public string consumername;
        public static int counter;
        public int credithistory;
        public string[] documents;
        public string insuranceid;

        static Insurance()
        {
            counter = 1000;
        }
        public Insurance()
        {
           this. age = 18;
           this. credithistory = 45000;
        }
        public Insurance(string consumername)
        {
            this.consumername = consumername;
        }

        public Insurance(string consumername, string[] documents)
        {
            this.consumername = consumername;
            this.documents = documents;
        }
        public Insurance (string consumername,int credithistory,int age , string[] documents)
        {
            this.consumername = consumername;
            this.documents = documents;
            this.age = age;
            this.credithistory = credithistory;
        }
        public bool checkeligibility()
        {
            bool res = false;
            if(age<18)
            {
                res = false;
            }
           else  if(age>18 && age<=30 && credithistory<=60000)
            {
                res= true;
            }
           else  if(age>30 && credithistory<=45000)
            {
                res= true;
            }
            else
            {
                res= false;
            }
            return res;
        }

        public bool checkdocuments(string[] accdocuments)
        {
            if(checkeligibility())
            {
                int res = 0;
               foreach(string doc in accdocuments)
                {
                    foreach(string document in documents)
                    {
                        if(doc.Equals(document))
                        {
                            res++;
                        }
                    }
                }
               if(res>=1)
                {
                    insuranceid = counter.ToString();
                    counter++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
