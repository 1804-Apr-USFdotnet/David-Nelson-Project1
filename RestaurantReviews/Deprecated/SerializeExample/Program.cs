using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
namespace SerializeExample
{
    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            t.SerializeCollection("DavidsXML.xml");
        }

        private void SerializeCollection(string filename)
        {
           /* Employees Emps = new Employees();
            // Note that only the collection is serialized -- not the   
            // CollectionName or any other public property of the class.  
            Emps.CollectionName = "Employees";
            Employee John100 = new Employee("John", "100xxxxxxxxxxxx");
            Emps.Add(John100);
            XmlSerializer x = new XmlSerializer(typeof(Employees));
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, Emps);*/

            ArrayList firstName = new ArrayList();
            firstName.Add("Nandy");
            firstName.Add("Karl");
            firstName.Add("Ferry");

            ArrayList lastName = new ArrayList();
            lastName.Add("Johnson");
            lastName.Add("Tomson");
            lastName.Add("Smithingson");
            lastName.Add("SJimmm");
            lastName.Add("Adventureman");

            Guild Adventure = new Guild();
            Heroics newb = new Heroics();
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                     newb = new Heroics((string)firstName[i], (string)lastName[j], i+j );
                    Adventure.Add(newb);
                }
            }

            XmlSerializer xmlSerial = new XmlSerializer(typeof(Guild));
            TextWriter writer = new StreamWriter(filename);
            xmlSerial.Serialize(writer, Adventure);

        }
    }
    public class Employees : ICollection
    {
        public string CollectionName;
        private ArrayList empArray = new ArrayList();

        public Employee this[int index]
        {
            get { return (Employee)empArray[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            empArray.CopyTo(a, index);
        }
        public int Count
        {
            get { return empArray.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return empArray.GetEnumerator();
        }

        public void Add(Employee newEmployee)
        {
            empArray.Add(newEmployee);
        }
    }

    public class Employee
    {
        public string EmpName;
        public string EmpID;
        public Employee() { }
        public Employee(string empName, string empID)
        {
            EmpName = empName;
            EmpID = empID;
        }
    }

    public class Heroics
    {
        public string Feat, Deed;
        int Age;
        public Heroics(string feat, string deed, int age)
        {
            Feat = feat;
            Deed = deed;
            Age = age;
        }
        public Heroics()
        {

        }
    }

    public class Guild : ICollection
    {
        private ArrayList heroArray = new ArrayList();

        public Heroics this[int index]
        {
            get { return (Heroics)heroArray[index]; }
        }
        public int Count
        {
            get { return heroArray.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return heroArray.GetEnumerator();
        }

        public void Add(Heroics newHero)
        {
            heroArray.Add(newHero);
        }

        public void CopyTo(Array array, int index)
        {
            heroArray.CopyTo(array, index);
        }
    }
}
