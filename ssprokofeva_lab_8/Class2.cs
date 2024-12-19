using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssprokofeva_lab_8
{
    internal class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Person(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
