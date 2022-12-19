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


            /*
            List<Person> personListProblem3 = new List<Person>();
            personListProblem3 = problemManager.problem3(personList);
            personListProblem3 = nodes.buildFamilyTree(personListProblem3);
            nodes.printProblem3(personListProblem3);
            */
        }
    }
}