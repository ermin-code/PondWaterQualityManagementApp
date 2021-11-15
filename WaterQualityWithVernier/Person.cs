using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterQualityWithVernier
{
    class Person
    {
        string name;
        string mail;
        string company;
        int age;

        public Person(string n, int a, string m, string c)
        {
            name = n;
            mail = m;
            company = c;
            age = a;
        }

        public string Name { get => name; set => name = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Company { get => company; set => company = value; }
        public int Age { get => age; set => age = value; }

    }
}
