using Entities;
using Business;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodes nodes = new Nodes();
            Problem problemManager = new Problem();
            ReadCsv readCsv = new ReadCsv();
            List<Person> personList = new List<Person>();
            personList = readCsv.readExcelReturnPersonList();

            //List<Person> personList = new List<Person>();

            //var personList2 = personListOld.OrderBy(p => p.bornDate);



            personList = nodes.buildFamilyTree(personList);
            nodes.PrintFamilyTree(personList);

            
            while (true)
            {
                Console.WriteLine("1 -> Çocuğu olmayan düğümlerin listesinin yaş sıralaması");

                Console.WriteLine("2 -> Üvey kardeşler bulunarak harf sıralamasına göre kaydedilecektir");

                Console.WriteLine("3 -> Kan grubu A olanların listesi kaydedilerek gösterilecektir");

                Console.WriteLine("5 -> Soy ağacında aynı isme sahip kişilerin ismi ve yaşları gösterilecektir");

                Console.WriteLine("6 -> Kullanıcıdan alınacak 2 tane isim girdisinden sonra büyük olan kişinin küçük olan kişiye yakınlığı gösterilecektir");
                
                Console.WriteLine("8 -> Soy ağacının kaç nesilden oluştuğu bulunacaktır");

                Console.WriteLine("9 -> Kullanıcıdan alınan isim girdisinden sonra o isimden sonra kaç nesil geldiği bulunacaktır");

                
                int choice = int.Parse(Console.ReadLine());
                if (choice==1)
                {
                    List<Person> personListProblem1 = new List<Person>();
                    personListProblem1 = problemManager.problem1(personList);
                    nodes.printProblem1(personListProblem1);
                }
                else if (choice == 3)
                {
                    List<Person> personListProblem3 = new List<Person>();
                    personListProblem3 = problemManager.problem3(personList);
                    personListProblem3 = nodes.buildFamilyTree(personListProblem3);
                    nodes.printProblem3(personListProblem3);
                }
                else if (choice==5)
                {
                    List<Person> personListProblem5 = new List<Person>();
                    personListProblem5 = problemManager.problem5(personList);
                    nodes.printProblem5(personListProblem5);
                }
                else if (choice==8)
                {
                    Console.WriteLine("NESIL -> " + " " + problemManager.problem8(personList));
                }
                else
                {
                    break;
                }
            }
            

        }
    }
}