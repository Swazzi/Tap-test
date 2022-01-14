using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class Person : IDriver
    {
        private string name;
        private string surname;
        private string email;

        public Person()
        {
        }

        public Person(string name, string surname, string email)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Person> GetPeople()
        {
            List<Person> listPerson = new List<Person>();
            TextEditor text = new TextEditor();
            List<string> person = text.ReadFile("Person.txt");
            if (person == null) return null;

            foreach (var item in person)
            {
                string[] newPerson = item.Split(",");
                this.Name = newPerson[0];
                this.Surname = newPerson[1];
                this.Email = newPerson[2];

                listPerson.Add(new Person(this.Name, this.Surname, this.Email));
            }
            return listPerson;
        }

        public void AddPerson()
        {
            TextEditor text = new TextEditor();
            string line = string.Format("{0},{1},{2}", this.Name, this.Surname, this.Email);
            text.WriteLine("Person.txt", line);
        }

        public Person UpdatePerson(int userID, List<Person> listPerson)
        {
            TextEditor text = new TextEditor();
            Console.Clear();
            Console.WriteLine("Please enter new Name.");
            listPerson[userID - 1].name = System.Console.ReadLine();
            Console.WriteLine("Please enter new Surename.");
            listPerson[userID - 1].surname = System.Console.ReadLine();
            Console.WriteLine("Please enter new Email.");
            listPerson[userID - 1].email = System.Console.ReadLine();

            string[] arrayPerson = new string[listPerson.Count];
            int i = 0;

            foreach (var person in listPerson)
            {
                arrayPerson[i] = string.Format("{0},{1},{2}", person.Name, person.Surname, person.Email);
                i++;
            }
            text.WriteFile("Person.txt", arrayPerson, false);
            return this;
        }

        public Person DeletePerson(int userID, List<Person> listPerson)
        {
            TextEditor text = new TextEditor();

            listPerson.RemoveAt(userID - 1);

            string[] arrayPerson = new string[listPerson.Count];
            int i = 0;

            foreach (var person in listPerson)
            {
                arrayPerson[i] = string.Format("{0},{1},{2}", person.Name, person.Surname, person.Email);
                i++;
            }
            text.WriteFile("Person.txt", arrayPerson, false);
            return this;
        }
    }
}