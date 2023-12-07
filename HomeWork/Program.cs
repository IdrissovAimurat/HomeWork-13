using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Program
    {
        static BQueue bankQueue = new BQueue();
        static int clientIdCounter = 1;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n1. Встать в очередь\n2. Обслужить следующего клиента\n3. Показать среднее время ожидания\n4. Показать историю обслуженных клиентов\n5. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnqueueClient();
                        break;
                    case "2":
                        bankQueue.DequeueClient();
                        break;
                    case "3":
                        bankQueue.DisplayAverageWaitTime();
                        break;
                    case "4":
                        bankQueue.DisplayServedClientsHistory();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
        }

        private static void EnqueueClient()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            ServiceType serviceType = ChooseServiceType();
            bool isVip = AskIfVIP();

            bankQueue.EnqueueClient(new Client(clientIdCounter++, name, serviceType, isVip));
        }

        private static ServiceType ChooseServiceType()
        {
            Console.WriteLine("Выберите тип услуги:\n1. Кредитование\n2. Открытие вклада\n3. Консультация");
            Console.Write("Ваш выбор: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return ServiceType.Credit;
                case "2":
                    return ServiceType.Deposit;
                default:
                    return ServiceType.Consultation;
            }
        }

        private static bool AskIfVIP()
        {
            string response;
            while (true)
            {
                Console.Write("Это VIP клиент? (да/нет): ");
                response = Console.ReadLine();
                if (response == "да" || response == "нет") break;

            }
            return response.Equals("да", StringComparison.OrdinalIgnoreCase);
        }
    }
}