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
        private List<Coworker> _Coworkers = new List<Coworker>();

        public Coworker CreateCoWorker( string Newname, int Newid)
        {
            var newcoworker = new Coworker(Newname, Newid);

            _Coworkers.Add(newcoworker);
            return newcoworker;
        }

        public void DeleteWorker(int id)
        {
            var coworker = _Coworkers.FirstOrDefault(e => e.Id == id);
            if (coworker is null)
                throw new ArgumentException("Invalid");

            _Coworkers.Remove(coworker);
        }


        public Coworker EditCoWorker(string updatedName, int UpdatedId, int id)
        {
            var updatedcoworker = _Coworkers.FirstOrDefault(e => e.Id == id);
            if (updatedcoworker is null)
                throw new ArgumentException("Invalid");

            updatedcoworker.Name = updatedName;
            updatedcoworker.Id = UpdatedId;

            return updatedcoworker;
        }
    }
}
