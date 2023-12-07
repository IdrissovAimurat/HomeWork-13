using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class BQueue
    {
        private Queue<Client> queue = new Queue<Client>();
        private List<Client> servedClients = new List<Client>();
        private List<DateTime> enqueueTimes = new List<DateTime>();
        private double totalWaitTime = 0;

        public void EnqueueClient(Client client)
        {
            queue.Enqueue(client);
            enqueueTimes.Add(DateTime.Now);
            DisplayQueue();
        }

        public Client DequeueClient()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Очередь пуста.");
                return null;
            }

            Client client = queue.Dequeue();
            DateTime enqueueTime = enqueueTimes[0];
            enqueueTimes.RemoveAt(0);
            TimeSpan waitTime = DateTime.Now - enqueueTime;
            totalWaitTime += waitTime.TotalMinutes;

            servedClients.Add(client);
            Console.WriteLine($"Обслуживается клиент: {client}");
            Console.WriteLine($"Время ожидания клиента: {waitTime.TotalMinutes} минут.");

            DisplayQueue();
            return client;
        }

        public void DisplayAverageWaitTime()
        {
            if (servedClients.Count == 0)
            {
                Console.WriteLine("Нет данных для расчета среднего времени ожидания.");
                return;
            }

            double averageWaitTime = totalWaitTime / servedClients.Count;
            Console.WriteLine($"Среднее время ожидания: {averageWaitTime} минут.");
        }

        public void DisplayServedClientsHistory()
        {
            Console.WriteLine("История обслуженных клиентов:");
            foreach (var client in servedClients)
            {
                Console.WriteLine(client);
            }
        }

        private void DisplayQueue()
        {
            Console.WriteLine("Текущая очередь:");
            foreach (var client in queue)
            {
                Console.WriteLine(client);
            }
        }
    }
}
