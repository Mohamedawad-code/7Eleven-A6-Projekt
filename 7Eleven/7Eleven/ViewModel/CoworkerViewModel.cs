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
        private List<Coworker> _Coworkers;

        public Coworker CreateCoWorker( string Newname, int Newid)
        {
            var newcoworker = new Coworker(Newname, Newid);

            _Coworkers.Add(newcoworker);
            return newcoworker;
        }
    }
}
