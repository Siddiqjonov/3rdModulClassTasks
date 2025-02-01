using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates;

public class MyClass
{
    public delegate void PrintDelegate(int number);
    //public PrintDelegate MyClassPrintDelegate { get; set; }

    public static void PrintNumbers(PrintDelegate printDelegate)
    {
        for (int i = 0; i < 10; i++)
        {
            printDelegate.Invoke(i);
        }
    }
}
