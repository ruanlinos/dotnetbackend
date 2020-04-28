using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using dotnetapi.Model;
using dotnetapi.Model.Context;

namespace dotnetapi.Services.Implementations {
    public class PersonServiceImplementation : IPersonService {

        private MySQLContext _context;

        public PersonServiceImplementation (MySQLContext context) {
            _context = context;
        }

        private volatile int count;

        public Person Create (Person person) {
            try {
                _context.Add (person);
                _context.SaveChanges ();
            } catch (Exception error) {

                throw error;
            }
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
            return _context.persons.SingleOrDefault (p => p.Id.Equals (id));
        }

        public Person Update (Person person) {
            return person;
        }
    }
}