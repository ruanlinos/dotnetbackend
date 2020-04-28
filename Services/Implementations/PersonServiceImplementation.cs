using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapi.Model;
using dotnetapi.Model.Context;

namespace dotnetapi.Services.Implementations {
    public class PersonServiceImplementation : IPersonService {

        private MySQLContext _context;

        public PersonServiceImplementation (MySQLContext context) {
            _context = context;
        }

        public Person Create (Person person) {
            try {
                _context.Add (person);
                _context.SaveChanges ();
            } catch (Exception error) {

                throw error;
            }
            return person;
        }

        public void Delete (long id) {
            var result = _context.persons.SingleOrDefault (p => p.Id.Equals (id));

            try {
                if (result != null) _context.persons.Remove (result);
                _context.SaveChanges ();
            } catch (Exception error) {

                throw error;
            }
        }

        public List<Person> FindAll () {
            return _context.persons.ToList ();
        }
        public Person FindById (long id) {
            return _context.persons.SingleOrDefault (p => p.Id.Equals (id));
        }

        public Person Update (Person person) {
            if (!Exist (person.Id)) return new Person ();

            var result = _context.persons.SingleOrDefault (p => p.Id.Equals (person.Id));

            try {
                _context.Entry (result).CurrentValues.SetValues (person);
                _context.SaveChanges ();
            } catch (Exception error) {

                throw error;
            }
            return person;
        }

        private bool Exist (long id) {
            return _context.persons.Any (p => p.Id.Equals (id));
        }
    }
}