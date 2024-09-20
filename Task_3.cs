using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_5_Dedok
{
    class CafeQueue
    {
        private Queue<string> visitorQueue = new Queue<string>();
        private List<string> reservedVisitors = new List<string>();
        private int totalTables;
        private int availableTables;

        public CafeQueue(int tables)
        {
            totalTables = tables;
            availableTables = tables;
        }
        public void AddVisitor(string visitor)
        {
            if (availableTables > 0)
            {
                availableTables--;
                Console.WriteLine($"{visitor} зайняв(-ла) вільний столик. Залишилось вільних столиків: {availableTables}");
            }
            else
            {
                visitorQueue.Enqueue(visitor);
                Console.WriteLine($"{visitor} став(-ла) в чергу.");
            }
        }
        public void AddReservedVisitor(string visitor)
        {
            reservedVisitors.Add(visitor);
            Console.WriteLine($"{visitor} зарезервував(-ла) столик.");
        }
        public void FreeTable()
        {
            Console.WriteLine("Столик звільнився.");
            availableTables++;
            if (reservedVisitors.Count > 0)
            {
                string reservedVisitor = reservedVisitors[0];
                reservedVisitors.RemoveAt(0);
                availableTables--;
                Console.WriteLine($"{reservedVisitor} зайняв(-ла) зарезервований столик.");
            }
            else if (visitorQueue.Count > 0)
            {
                string nextVisitor = visitorQueue.Dequeue();
                availableTables--;
                Console.WriteLine($"{nextVisitor} зайняв(-ла) столик із черги.");
            }
            else
            {
                Console.WriteLine("Немає відвідувачів у черзі або з резервом.");
            }
        }
        public void StartSimulation()
        {
            string[] visitors = { "Іван", "Ольга", "Дмитро", "Марія", "Петро", "Анастасія" };
            string[] reservedVisitors = { "Сергій", "Олександр" };

            foreach (string visitor in visitors)
            {
                AddVisitor(visitor);
                Thread.Sleep(1000);
            }

            foreach (string reservedVisitor in reservedVisitors)
            {
                AddReservedVisitor(reservedVisitor);
                Thread.Sleep(1000); 
            }
            for (int i = 0; i < 5; i++)
            {
                FreeTable();
                Thread.Sleep(2000);
            }
        }
    }
}
