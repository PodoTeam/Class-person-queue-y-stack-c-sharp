using System;
namespace Isaac_Haro_Queue
{
    class PERSON
    {
        public int[] Age;
        public string[] Name;
        public PERSON(int a)
        {
            Name = new string[a];
            Age = new int[a];
            for (int cont=0; cont<a; cont++)
            {
                Age[cont] = -1;
                Name[cont] = null;
            }
        }
    }
    class COLAPQ
    {
        private int start, final;
        private int[]AgePerson;
        private string []NamePerson;
        public COLAPQ(PERSON PERSON1)
        {
            start = -1;
            final = -1;
            AgePerson = PERSON1.Age;
            NamePerson = PERSON1.Name;
        }
        public void ENTER_PERSON(int a)
        {
            for (int cont = final + 1; cont < a; cont++)
            {
                Console.WriteLine("Introduce the name of the person:");
                NamePerson[cont] = Console.ReadLine();
                Console.WriteLine("Introduce the age of the person:");
                AgePerson[cont] = int.Parse(Console.ReadLine());
            }
        }
        public void PRINT(int number)
        {
            for (int cont = start + 1; cont < number; cont++)
            {
                if (AgePerson[cont].Equals(-1))
                    cont++;
                else
                    Console.WriteLine("Name:{0}, Age:{1}", NamePerson[cont], AgePerson[cont]);
            }
        }
        public void ORDER(int number)
        {
            string auxn = "";
            int aux = 0, cont;
            for (int i = final + 1; i < number - 1; i++)
            {
                for (cont = 0; cont < number - 1; cont++)
                {
                    if (AgePerson[cont] > AgePerson[cont + 1])
                    {
                        aux = AgePerson[cont];
                        AgePerson[cont] = AgePerson[cont + 1];
                        AgePerson[cont + 1] = aux;
                        auxn = NamePerson[cont];
                        NamePerson[cont] = NamePerson[cont + 1];
                        NamePerson[cont + 1] = auxn;
                    }
                }
                cont = 0;
                final++;
            }
            if ((final + 1).Equals(number - 1))
                final = -1;
            if (start.Equals(final))
                Console.WriteLine("Queue is full, it does not support adding elements");
        }
        public bool EMPTY()
        {
            if (start.Equals(final))
                return true;
            else
                return false;
        }
        public void REMOVE(int REMOVE_AGE)
        {
            if (EMPTY())
                Console.WriteLine("Queue is empty, it does not possible remove more elements");
            for (int aux = start + 1; aux < REMOVE_AGE; aux++)
            {
                AgePerson[aux] = -1;
                NamePerson[aux] = null;
            }
        }
        public void ADD_PERSONS(int ing, int sali)
        {
            for (int cont = ing; cont < (ing+sali); cont++)
            {
                Console.WriteLine("Introduce the name of the person:");
                NamePerson[cont] = Console.ReadLine();
                Console.WriteLine("Introduce the age of the person:");
                AgePerson[cont] = int.Parse(Console.ReadLine());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int number,number2, REMOVE_AGE;
            Console.WriteLine("Introduce the number of persons with you want to work");
            number = int.Parse(Console.ReadLine());
            PERSON PERSON1 = new PERSON(20);
            COLAPQ COLAPQ1 = new COLAPQ(PERSON1);
            COLAPQ1.ENTER_PERSON(number);
            COLAPQ1.ORDER(number);
            COLAPQ1.PRINT(number);
            Console.WriteLine("If you want to remove persons, introduce the number of persons to remove");
            REMOVE_AGE = int.Parse(Console.ReadLine());
            COLAPQ1.REMOVE(REMOVE_AGE);
            COLAPQ1.PRINT(number);
            Console.WriteLine("If you want to insert persons, introduce the number of persons to insert");
            number2 = int.Parse(Console.ReadLine());
            COLAPQ1.ADD_PERSONS(number, number2);
            COLAPQ1.ORDER(number+number2);
            COLAPQ1.PRINT(number + number2);
        }
    }
}
