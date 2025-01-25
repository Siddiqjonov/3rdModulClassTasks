using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIngletone;

public class MyClass
{
    private static MyClass instanse;
    public long Id { get; set; }
    private MyClass()
    {
        
    }
    public static MyClass GetInstanse()
    {
        if (instanse == null)
        {
            instanse = new MyClass();
        }
        return instanse;
    }
}
