using System;
using System.Collections.Generic;

public class Student
{
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public DateTime ZiDeNastere { get; set; }
    public int Varsta
    {
        get
        {
            return DateTime.Now.Year - ZiDeNastere.Year;
        }
    }
    public string AdresaDeEmail { get; set; }
    public List<Materie> Materii { get; set; } = new List<Materie>();

    public Student(string nume, string prenume, DateTime ziDeNastere, string adresaDeEmail)
    {
        Nume = nume;
        Prenume = prenume;
        ZiDeNastere = ziDeNastere;
        AdresaDeEmail = adresaDeEmail;
    }

    public override string ToString()
    {
        return $"{Prenume} {Nume} ({Varsta} de ani)";
    }

    public void AfiseazaMaterii()
    {
        Console.WriteLine(this);
        Console.WriteLine("Materii: ");
        foreach (Materie materie in Materii)
        {
            Console.WriteLine(materie);
        }
    }
}