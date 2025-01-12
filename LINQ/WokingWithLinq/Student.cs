using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace WokingWithLinq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double Cash { get; set; }

    public Student(string fN, string lN, int age, double cash)
    {
        FirstName = fN;
        LastName = lN;
        Age = age;
        Cash = cash;
    }
}
    


