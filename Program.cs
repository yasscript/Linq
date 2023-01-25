using System.Collections.Generic;

// LA COLLECTION doit implementer IEnumerable<T>, ou Iqueryable pour pouvoir travailler avec Linq

List<string> Names = new List<string>(){
    "Red","Book","Car","Computer","Mobile","Program","Driver","Window","Key","Home",
    "Pen","Right","Play","Clic","Language33","Rule","Peace","Word", "File"
};

Console.WriteLine("\n\n############################################  WHERE > 3");
// Query syntaxe
var Result1 = from item in Names where item.Count() > 3 select item;
// Non Query syntaxe -- extension methodes syntaxe
 var Result2 = Names.Where(x => x.Length > 3);
foreach(var str in Result2){
    Console.Write(" " + str);
}

Console.WriteLine("\n\n############################################  CONTAINS 33");
//Query Syntaxe
var Result3 = from item in Names where item.Contains("33") select item; 
//Non Query
var Result4 = Names.Where(x=>x.Contains("33"));
foreach(var str in Result4){
    Console.WriteLine(str);
}


Console.WriteLine("\n\n############################################  StartWith 'R' && lenght=3");
//Query syntaxe
var Result5 = from item in Names where item.StartsWith("R") 
    && item.Length == 3 select item;
//Non Query syntaxe
var Result6 = Names.Where(x=>x.StartsWith("R") && x.Length==3);
foreach(var str in Result6){
    Console.WriteLine(str);
}

// Console.WriteLine("\n\n############################################  en cours");


IEnumerable<Student> Tclasse = new List<Student>(){
    new Student(4,"H","Yass",36,20.00),
    new Student(3,"H","Jerome",28,18.30),
    new Student(2,"X","Julian",22,12.75),
    new Student(1,"F","Marina",55,14.13),
    new Student(4,"F","Alain",47,12.33),
};

Console.WriteLine("\n\n####### La somme des notes des etudiants < 30 ans ");
//Query syntaxe
// var somme1 = from item in Tclasse where item.age<=30 select su 
//Non Query Syntaxe Somme des ages
var Somme2 = Tclasse.Where(z=>z.age<=30).Sum(z=>z.age);
//Non Query Syntaxe somme des notes
var Somme3 = Tclasse.Where(e=>e.age<=30).Sum(s=>s.note);
Console.WriteLine(Somme2);

Console.WriteLine("\n\n############################################  Orderby");

//Query
// Les étudiant qui ont plus que 30 par order decroissant
var order1 = from item in Tclasse where item.age > 30 orderby item.age,item.name descending select item;
foreach(var etud in order1){
    Console.WriteLine(etud.toString());
}
Console.WriteLine("---------------------------------------");

//Non-Query
var order2 = Tclasse.Where(e=>e.age > 30).OrderByDescending(e=>e.Id).ThenByDescending(e=>e.name);
foreach(var etud in order1){
    Console.WriteLine(etud.toString());
}
Console.WriteLine("------------ Les sommes---------------------------");
//Query
// int somme5 = (from item in Tclasse where(item.age > 30) select item).Max(); 
double Somme5 = (from num in Tclasse where num.age > 30 select num).Sum(e=>e.note);
Console.WriteLine("la somme en Query = {0}",Somme5 );

//Non-Query
//La  somme des notes des etudiants qui ont plus que 30 ans:
var Somme4 = Tclasse.Where(e=>e.age > 30).Sum(e=>e.note);
Console.WriteLine("La somme en N-Query = {0}", Somme4);


Console.WriteLine("\n\n############################################  GroubBy ");
IEnumerable<Book> Library = new List<Book>(){
    new Book(6,"C#","Kamal Younes", 11.75),
    new Book(7,"Java","Khalid Essadani",12.33),
    new Book(4,"Perl","Ismael Rachid",7.99),
    new Book(7,"C#","Khalid Essadani",15),
    new Book(7,"C++","Hamid Makboul",14.25),
    new Book(7,"PHP","Khalid Essadani",33.5),
    new Book(7,"Ruby","Ahmed Rouchdi",25.75 )
};
//Query
Console.WriteLine("ALL---------------------------------------");
var Books = from item in Library orderby item.Id, item.Title select item;
foreach (var item in Books)
{
    Console.WriteLine(item.tostring());
}
Console.WriteLine("GrouByAuthor Query---------------------------------------");
var Groups = from item in Library group item by item.Author;
// double MoyennePrixByAuthor = (from item in Library group item by item.Author).Sum(from item in );
foreach (var item in Groups)
{
    Console.WriteLine(item.Key);
    foreach (var book in item)
    {
        Console.WriteLine("    - {0}" , book.tostring());
    }
}
Console.WriteLine("GrouByAuthor N-Query---------------------------------------");

//N-Query
var groups2 = Library.GroupBy(e=>e.Author) ;
foreach (var item in groups2)
{
    Console.WriteLine(item.Key);
    foreach (var book in item)
    {
        Console.WriteLine("    - {0}" , book.tostring());
    }
}

Console.WriteLine("\n\n############################################  Join ");

    IEnumerable<Prof> Profs = new List<Prof>(){
        new Prof("Yass", 50),
        new Prof("Ced",55),
        new Prof("Jerome",45),
    };
    IEnumerable<Eleve> Eleves = new List<Eleve>(){
        new Eleve("Yass",38),
        new Eleve("Ced",26),
        new Eleve("Julain",24),
        new Eleve("Marina",44),
        new Eleve("Alex",33)
    };

    Console.WriteLine("Query Join---------------------------------------");

    // Query Les personnes qui sont aussi profs et leves:
    var personnes = from prof in Profs
                    join eleve in Eleves
                    on prof.name equals eleve.name 
                    select prof;
    foreach (var item in personnes)
    {
        Console.WriteLine(item.toString());
    }
    
    Console.WriteLine("N-Query Join---------------------------------------");

    // N-Query Les personnes qui sont aussi profs et leves:
    personnes = Profs.Join(Eleves, p=>p.name, e=>e.name,(p,e)=>p);
    foreach (var item in personnes)
    {
        Console.WriteLine(item.toString());
    }

Console.WriteLine("\n\n############################ Concat, Distinctn Union ");
//Concat 
    Console.WriteLine("Query Join All---------------------------------------");

    // var T = Profs.Concat(Eleves);
    string[] group1 = {"Yass","Ced","Jerome","Julian"};
    string[] group2 = {"Marina","Ced","Pierre","Jerome"};

    //Query
    var Groups1 = group1.Concat(group2);
    foreach (var item in Groups1)
    {
        Console.Write(" {0}",item);
    }
    Console.WriteLine("\nQuery Join Distinct---------------------------------------");
    var Groups2 = group1.Concat(group2).Distinct();
    foreach (var item in Groups2)
    {
        Console.Write(" {0}",item);
    }
    Console.WriteLine("\nQuery Union = Concat + Distinct --------------------------");

    var Group3 = group1.Union(group2);
    foreach (var item in Groups2)
    {
        Console.Write(" {0}",item);
    }

Console.WriteLine("\n\n############################################  Intersect except ");
    Console.Write("Group1: ");
    foreach (var item in group1)
    {
        Console.Write(" {0}",item);
    }
    Console.Write("\nGroup2: ");
    foreach (var item in group2)
    {
        Console.Write(" {0}",item);
    }
    
    Console.WriteLine("\nQuery Intersect ---------------------------------------");
    var Groups4 = group1.Intersect(group2);
    foreach (var item in Groups4)
    {
        Console.Write(" {0}",item);
    }

    Console.WriteLine("\nQuery Except ---------------------------------------");
    var Groups5 = group1.Except(group2);
    foreach (var item in Groups5)
    {
        Console.Write(" {0}",item);
    }

Console.WriteLine("\n\n#######################################  First/FirstOrDefault ");
  Console.Write("Group1: ");
    foreach (var item in group1)
    {
        Console.Write(" {0}",item);
    }
    Console.WriteLine("\n First   ---------------------------------------");
    var per1 = group1.First();
    var per2 = group2.First(f=>f.StartsWith("J"));
    Console.WriteLine(" La premiere valeur du tableau: {0} ", per1);
    Console.WriteLine(" La premiere dont le nom commance par J: {0} ", per2);
    Console.WriteLine("la difference ente First/FirstOrDefault et que" 
    + "si l element recherché est null avec FirstOrDefault pas d'exeption");

Console.WriteLine("\n\n#######################################  Last/LastOrDefault ");
    Console.Write("Group1: ");
    foreach (var item in group1)
    {
        Console.Write(" {0}",item);
    }
    var per3 = group1.LastOrDefault();
    var per4 = group2.LastOrDefault(f=>f.StartsWith("C"));
    Console.WriteLine("\n La derniere valeur du tableau: {0} ", per3);
    Console.WriteLine(" La derniere dont le nom commance par C: {0} ", per4);

Console.WriteLine("\n\n#######################################  Single/SingOrDefault ");
    Console.WriteLine("l'extesion Single ramène la seul valeur de la collection"
    + "Si il y a plus qu une valeur => exeption"
    + "elle est utilisé pour s'assuerer qu il y a une seule valeur dans la collection !");
    // var single = group1.SingleOrDefault();
    // Console.WriteLine("La valeur de single: {0} ", single==null);

Console.WriteLine("\n\n#######################################  ElementAt/ElementAtOrdefault ");
Console.Write("Group1: ");
    foreach (var item in group1)
    {
        Console.Write(" {0}",item);
    }
    var element = group1.ElementAt(1);
    if(element.Equals("Ced")) Console.WriteLine("\nCed est bien a la 2 eme case du tableau");
    var element2 = group1.ElementAtOrDefault(99);
    Console.WriteLine("la ElementAtOrDefault ne retourne pas une exception meme si on est hors Lenght du tableau");
    
Console.WriteLine("\n\n####################################### Sum/Min/Max/Average  ");
    int[] numbers = {1,2,3,4,5,6,7,8,9,10};
    foreach (var item in numbers)
    {
        Console.Write(" {0}",item);
    }
    var Somme = numbers.Where(n=>n>5).Sum();
    var max = numbers.Max();
    var min = numbers.Min();
    var avg = numbers.Average();

    Console.WriteLine("\nLa somme des chiffre > 5:  {0}", Somme);
    Console.WriteLine("La plus grande valeur du tableau:  {0}", max);
    Console.WriteLine("La plus petite valeur du tableau:  {0}", min);
    Console.WriteLine("La Moyenne des valeurs du tableau:  {0}", avg);
// Console.WriteLine("\n\n############################################  Classes ");

class Personne
{
    public string? name {get; set;}
    public int? age {get; set;}

    public string toString(){
        return this.name + " " + this.age;
    }   
}
class Prof : Personne
{   
    public Prof(string name, int age){
        this.name = name ;
        this.age = age ;
    }

}
class Eleve : Personne
{
    public Eleve(string name, int age){
        this.name = name ;
        this.age = age ;
    }
}


public class Student{
    public int Id {get; set;}
    public string? sexe {get; set;}
    public string? name {get; set;}
    public int? age {get; set;}
    public double note {get; set;}

    public Student(int Id, string sexe, string name, int age, double note){
        this.Id = Id;
        this.sexe = sexe;
        this.name = name;
        this.age = age;
        this.note = note;
    }
    public Student(){}

    public string toString(){
        return this.Id + " " + this.name + " " + this.sexe + " " + this.age + " " + this.note;
    }   
}
class Book{
    public int Id {get;set;}
    public string? Title {get;set;}
    public string? Author {get;set;}
    public double prix {get;set;}


    public Book(int Id, string Title, string Author, double prix){
        this.Id = Id;
        this.Title = Title;
        this.Author = Author;
        this.prix = prix;
    }
    public string tostring(){
        return this.Id + " " + this.Title + " " + this.Author + " " + this.prix;
    }
}