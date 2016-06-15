using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.Model
{
    public class Experience
    {
        public Experience(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
