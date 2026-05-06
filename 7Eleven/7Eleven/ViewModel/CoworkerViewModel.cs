using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _7Eleven.ViewModel
{
    public class CoworkerViewModel
    {
        private ObservableCollection<Coworker> _coworkers = new ObservableCollection<Coworker>();
        private CoworkerRepository _repo = new CoworkerRepository();

        public Coworker CreateCoWorker( string Newname, int Newid)
        {
            var newcoworker = new Coworker(Newname, Newid);

            _coworkers.Add(newcoworker);
            _repo.AddCoworker(newcoworker);
            return newcoworker;
        }

        public void DeleteWorker(int id)
        {
            var coworker = _coworkers.FirstOrDefault(e => e.Id == id);
            if (coworker is null)
                throw new ArgumentException("Invalid");

            _coworkers.Remove(coworker);
            _repo.DeleteCoworker(coworker.Id);
        }


        public Coworker EditCoWorker(string updatedName, int UpdatedId, int id)
        {
            var updatedcoworker = _coworkers.FirstOrDefault(e => e.Id == id);
            if (updatedcoworker is null)
                throw new ArgumentException("Invalid");

            updatedcoworker.Name = updatedName;
            updatedcoworker.Id = UpdatedId;

            _repo.UpdateCoworker(updatedcoworker);
                
            return updatedcoworker;
        }

        public ObservableCollection<Coworker> GetAllCoworkers()
        {
            var result = _repo.GetAll();
            _coworkers = new ObservableCollection<Coworker>(result);
            return _coworkers;
        }

        public Coworker GetByIdCoworker(int id)
        {
            var coworker = _repo.GetById(id);
            if (coworker is null)
                throw new ArgumentException("Invalid or doesnt exist");

            return coworker;
        }
    }
}
