using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationRecordTuple.Models
{
    internal record StudentRecord:PersonRecord
    {
        private string _group;

        public string Group { get { return _group; } init { _group = value; } }

        public StudentRecord(string name,string surname):base(name,surname)
        {

        }
    }
}
