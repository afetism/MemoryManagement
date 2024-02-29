using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagment.Moduls
{
    internal class FlashDisk:Storage
    {
        public FlashDisk(string name, string model, int size) : base(name, model, size, speed: 3)
        {
        }

        public override void Copy(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));

            if (FreeMemory < data.Length)
                throw new OverflowException("Not enough memory");

            Current += data.Length;
            var ms = data.Length / Speed * 1000;
            var san = ms/1000;
            while (san>0)
            {
                Console.WriteLine($"Coping to Flash... {san}");
                san--;
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
