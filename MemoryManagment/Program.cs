// See https://aka.ms/new-console-template for more information
using MemoryManagment.Moduls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

void menu()
{
    Console.WriteLine(@"1.Copy to DVD
2.Copy to HDD
3.Copy to Flash");
}

int copyData(Storage memoryDevice,string model)
{
    try
    {
        if (memoryDevice as DvdDisk is not null)
        {
            memoryDevice.Copy(model);
        }
        else if (memoryDevice as HddDisk is not null)
        {
            memoryDevice.Copy(model);
        }
        else if (memoryDevice as FlashDisk is not null)
        {
            memoryDevice.Copy(model);
        }
        return 0;
    }
    catch(Exception ex )
    {
        Console.WriteLine(ex.Message); 
        return -1;
    }
}



while (true)
{
    menu:
    menu();
    Console.Write("Enter Choose:(1,2 or 3): ");
    string? input=Console.ReadLine();
    if (int.TryParse(input, out int value))
    {
        if (value>0 && value<=3)
        {
            Data:
            Console.Clear();
            Console.Write("Enter Title: ");
            string? title = Console.ReadLine();
            Console.Write("Enter Model: ");
            
            string? model = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(title))
                goto Data;


            int result=0;
            if (value==1)
            {
                result= copyData(new DvdDisk(title!, model!, 100), model!);
            }
            else if (value==2)
            {
                result=copyData(new HddDisk(title!, model!, 100), model!);
            }
            else if (value == 3)
            {
                result=copyData(new FlashDisk(title!, model!, 100), model!);
            }

            if (result==0)
            {
                Console.WriteLine("Successfully Oparation!,Enter Key!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter AnyKey");
                Console.ReadKey();
                goto Data;
            }
            Console.Clear();
        }
        else
        {
            Console.Clear();
            goto menu;
        }
    }
    else
    {
        Console.Clear();
        goto menu;
    }
}