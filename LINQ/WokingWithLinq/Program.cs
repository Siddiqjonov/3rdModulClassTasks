using System.ComponentModel.DataAnnotations;

namespace WokingWithLinq;

internal class Program
{
    static void Main(string[] args)
    {
        // lambda expression/funksiya (anonim funksiya)

        // age => age > 18 // return type and argument(condition) 
        // perosn => person.Age // return type and argument (condition) 

        Student student1 = new Student("Lobar", "Odilova", 26, 100);
        Student student2 = new Student("Davron", "Rustamov", 18, 2000);
        Student student3 = new Student("Rustam", "Elbekov", 15, 700);
        Student student4 = new Student("Qodir", "Odilov", 35, 10000);
        Student student5 = new Student("Ali", "Odilov", 22, 8000);

        List<Student> students = new List<Student>();
        students.Add(student1);
        students.Add(student2);
        students.Add(student3);
        students.Add(student4);
        students.Add(student5);

        var res = students.Where(st => st.Age > 18).ToList();
        var res1 = students.Where(st => st.Cash < 1000).ToList();
        var res2 = students.Where(st => char.IsUpper(st.FirstName[0])).ToList();
        var res3 = students.Where(st => char.IsLower(st.LastName[0])).ToList();

        var res4 = students.Select(st => st.Age).ToList();

        var ints = new List<int>() { 2, 3, 4, 5, 6, 2, 3, 4, 9, 0 };
        var res5 = ints.Select(i => i % 2 == 0 ? i * 2 : i).ToList();

        var res6 = students.OrderBy(st => st.Age).ToList();
        var res7 = students.OrderBy(st => st.FirstName).ToList();

        var res8 = students.OrderByDescending(st => st.Cash).ToList();

        var res9 = students.Count(st => st.Age > 18);

        var res10 = students.Sum(st => st.Cash);

        var res11 = students.Where(st => st.Age > 18).Sum(st => st.Cash);

        var res12 = students.Min(st => st.Age);

        var res13 = students.Where(st => st.Age == students.Min(student => student.Age)).ToList();

        var res14 = students.Max(st => st.Age);

        var res15 = students.Average(st => st.Age); // Middle arifmrtics

        var res16 = students.All(st => st.Cash > 0); // true
        var res17 = students.All(st => st.Cash > 150); // false

        var res18 = students.Any(st => st.Age > 18); // if there is anyone older than 18 method returns true

        var res19 = students.First(st => st.Age > 18); // returns first student object in the list older than 18 if cant find EXEPTION

        var res20 = students.FirstOrDefault(st => st.Age > 18); // returns first student object in the list older than 18 if cant find returns defaul val

        var res21 = students.Last(st => st.Age > 18); // opposite of First()

        var res22 = students.LastOrDefault(st => st.Age > 28); // opposite of FirstOrDefault()
        //Console.WriteLine(res22.Age + " " + res22.LastName);

        var res23 = students.Single(st => st.Age <= 15);
        //Console.WriteLine(res23.Age);

        // var res24 = students.SingleOrDefault(st => st.Age > 20); // returns object (if more than one value saficifies the condition method throws and exeption)
        var res25 = students.SingleOrDefault(st => st.Age > 30);
        Console.WriteLine($"{res25.FirstName} {res25.LastName} {res25.Age}"); // returns object (if more than one value saficifies the condition method throws and exeption)

        var res26 = students.SingleOrDefault(st => ForLamda(st.Age));

        //Console.WriteLine(res19.Age);
        //Console.WriteLine(res21.Age);
    }
    public static bool Is18(int age)
    {
        return age > 18;
    }
    public static bool ForLamda(int age)
    {
        return (age > 18);
    }
}
