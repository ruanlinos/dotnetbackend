using System;
using System.Collections.Generic;
using System.Threading;
using dotnetapi.Model;

namespace dotnetapi.Services.Implementations {
    public class PersonServiceImplementation : IPersonService {
        private volatile int count;

        public Person Create (Person person) {
            return person;
        }

        public void Delete (long id) { }

        public List<Person> FindAll () {
            List<Person> persons = new List<Person> ();
            for (int i = 0; i < 8; i++) {
                Person person = MockPerson (i);
                persons.Add (person);
            };

            return persons;
        }

        private Person MockPerson (int i) {
            return new Person {
                Id = IncrementAndGet (),
                    FirstName = "Ruan" + i,
                    LastName = "Linos" + i,
                    Address = "Guarapuava/PR" + i,
                    Gender = "M"
            };
        }

        private long IncrementAndGet () {
            return Interlocked.Increment (ref count);
        }

        public Person FindById (long id) {
            return new Person {
                Id = IncrementAndGet (),
                    FirstName = "Ruan",
                    LastName = "Linos",
                    Address = "Guarapuava/PR",
                    Gender = "M"
            };
        }

        public Person Update (Person person) {
            return person;
        }
    }
}