public class Program
{
    public static void Main()
    {
        Materie daw = new Materie("Dezvoltarea aplicatiilor web", "1 semestru");
        Materie algo = new Materie("Algoritmi fundamentali", "1 semestru");
        Materie bd = new Materie("Baze de date", "1 an");
        Materie matematica = new Materie("Matematica", "3 semestre");

        Student student1 = new Student(
            "Popa",
            "Stefan",
            new DateTime(2000, 1, 1),
            "stefan@gmail.com"
        );
        student1.Materii.Add(daw);
        student1.Materii.Add(algo);
        student1.Materii.Add(matematica);

        Student student2 = new Student(
            "Vasiliu",
            "Veronica",
            new DateTime(2003, 07, 23),
            "vero_zero@yahoo.com"
        );
        
        student2.Materii.Add(algo);
        student2.Materii.Add(bd);

        var listaStudenti = new List<Student> { student1, student2 };

        foreach (var student in listaStudenti)
        {
            student.AfiseazaMaterii();
            Console.WriteLine();
        }
    }
}