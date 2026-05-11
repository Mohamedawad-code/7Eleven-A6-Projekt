using _7Eleven.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace _7Eleven.ViewModel
{
    public class CoworkerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Coworker> _coworkers = new ObservableCollection<Coworker>();
        private CoworkerRepository _repo = new CoworkerRepository();
        public ObservableCollection<Coworker> Coworkers
        {
            get => _coworkers;
            set
            {
                _coworkers = value;
                OnPropertyChanged(nameof(Coworkers));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string NewName { get; set; }
        public int NewId { get; set; }
        public Coworker SelectedCoworker { get; set; }


        public ICommand CreateCoWorkerCommand { get; }
        public ICommand DeleteWorkerCommand { get; }
        public ICommand EditCoworkerCommand { get; }

        public void ExcuteCreateCoWorker()
        {
            CreateCoWorker(NewName, NewId);
        }

        public void ExcuteDeleteWorker()
        {
            if (SelectedCoworker is null)
                return;
            DeleteWorker(SelectedCoworker.Id);
        }

        public void ExcuteEditCoworker()
        {
            if (SelectedCoworker is null)
                return;
            EditCoWorker(NewName, NewId, SelectedCoworker.Id);
        }



        public CoworkerViewModel()
        {
            CreateCoWorkerCommand = new RelayCommand(ExcuteCreateCoWorker);
            DeleteWorkerCommand = new RelayCommand(ExcuteDeleteWorker);
            EditCoworkerCommand = new RelayCommand(ExcuteEditCoworker);

            var result = _repo.GetAll();
            Coworkers = new ObservableCollection<Coworker>(result);
        }





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
            Coworkers = new ObservableCollection<Coworker>(result);
            return Coworkers;

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
