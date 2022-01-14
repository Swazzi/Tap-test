using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IDriver
    {
        List<Person> GetPeople();
        void AddPerson();
        Person UpdatePerson(int userID, List<Person> listPerson);
        Person DeletePerson(int userID, List<Person> listPerson);
    }
}
