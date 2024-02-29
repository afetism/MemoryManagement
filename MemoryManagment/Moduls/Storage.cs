using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MemoryManagment.Moduls
{
    internal abstract class Storage
    {
        protected Storage(string name, string model, int size, int speed)
        {
            Name=name;
            Model=model;
            Size=size;
            Current=0;
            Speed=speed;
        }

        public string Name { get; set; }
        public string Model {  get; set; }
        public int Size { get; init; }
        public int Current {  get; set; }
        protected int Speed { get; set; }
        public int FreeMemory => Size - Current;

        public void PrintDeviceInfo()
        {
            Console.WriteLine($"Name: {Name} \n Size: {Size} \n Free: {FreeMemory}");
        }
        public abstract void Copy(string data);
    }
}
