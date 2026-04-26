using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _7Eleven.ViewModel
{
    public class CoworkerViewModel
    {
        private List<Coworker> _coworkers = new List<Coworker>();

        public Coworker CreateCoWorker( string Newname, int Newid)
        {
            var newcoworker = new Coworker(Newname, Newid);

            _coworkers.Add(newcoworker);
            return newcoworker;
        }

        public void DeleteWorker(int id)
        {
            var coworker = _coworkers.FirstOrDefault(e => e.Id == id);
            if (coworker is null)
                throw new ArgumentException("Invalid");

            _coworkers.Remove(coworker);
        }


        public Coworker EditCoWorker(string updatedName, int UpdatedId, int id)
        {
            var updatedcoworker = _coworkers.FirstOrDefault(e => e.Id == id);
            if (updatedcoworker is null)
                throw new ArgumentException("Invalid");

            updatedcoworker.Name = updatedName;
            updatedcoworker.Id = UpdatedId;

            return updatedcoworker;
        }

        public List<Coworker> GetAllCoworkers()
        {
            return _coworkers;
        }

        public Coworker GetByIdCoworker(int id)
        {
            var coworker = _coworkers.FirstOrDefault(c => c.Id == id);
            if (coworker is null)
                throw new ArgumentException("Invalid or doesnt exist");

            return coworker;
        }
    }
}
