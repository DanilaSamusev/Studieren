using System;

namespace lab1_Ostapenko
{
    class Program
    {
        static void Main(string[] args)
        {
            Table defaultTable = new Table();
            Console.WriteLine(defaultTable.GetFields());
            Console.WriteLine($"Стоимость: $ {defaultTable.GetPrice():f2}");

            Console.WriteLine();

            Table table1 = new Table("Table1", 900);
            Console.WriteLine($"Название стола: {table1.Name} \t Площадь стола: {table1.Square} см кв. \t Стоимость стола: $ {table1.GetPrice():f2}");

            Console.WriteLine();

            table1.Name = "Table1.2";
            table1.Square = 950;
            Console.WriteLine($"Название стола: {table1.Name} \t Площадь стола: {table1.Square} см кв. \t Стоимость стола: $ {table1.GetPrice():f2}");
        }
    }
}