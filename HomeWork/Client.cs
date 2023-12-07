using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public bool IsVIP { get; set; }
        public string GetServiceType
        {
            get
            {
                if (this.ServiceType == ServiceType.Credit) return "Кредитование";
                else if (this.ServiceType == ServiceType.Deposit) return "Открытие вклада";
                else if (this.ServiceType == ServiceType.Consultation) return "Консультация";
                else return "Не известно";
            }
        }
        public Client(int id, string name, ServiceType serviceType, bool isVIP = false)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
            IsVIP = isVIP;
        }

        public override string ToString()
        {
            return $"Информация о клиенте {Id}: {Name}, услуга: {GetServiceType}, VIP: {IsVIP}";
        }
    }

    public enum ServiceType
    {
        Credit,
        Deposit,
        Consultation
    }
}
