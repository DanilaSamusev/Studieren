using System;
using System.Threading;

namespace SPO_lab2_3_Ostapenko
{
    class MyThread
    {
        private int _count;
        private int _countLimit;
        private static bool _stop = false;
        private static string _currentName;

        public Thread thread;

        public int Count
        {
            get => _count;
            set
            {
                if (value > 0)
                {
                    _count = value;
                }
            }
        }

        public int CountLimit
        {
            get => _countLimit;
            set => _countLimit = value;
        }

        // Создаем новый поток. Обратите внимание на то, что этот конструктор в действительности не запускает потоки на выполнение.
        public MyThread(string name, int countLimit)
        {
            Count = 0;
            thread = new Thread(new ThreadStart(this.Run))
            {
                Name = name
            };
            _currentName = name;
            CountLimit = countLimit;
        }

        // Начинаем выполнение нового потока.

        private void Run()
        {
            Console.WriteLine("Поток " + thread.Name + " стартовал. ");
            do
            {
                Count++;
                if (_currentName != thread.Name)
                {
                    _currentName = thread.Name;
                    Console.WriteLine("В потоке " + _currentName);
                }
            } while (_stop == false && Count < 1000000);
            _stop = true;
            Console.WriteLine("Поток " + thread.Name + " завершен.");
        }
    }
}