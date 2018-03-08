using System;

namespace CorsoEnaip2018_ProjectManagement.Models
{
    public class Project
    {
        public Project() { }

        public Project(
            int id,  string name, string client, string manager,
            int dayStart, int monthStart, int yearStart,
            int dayFinish, int monthFinish, int yearFinish,
            int dayDelivery, int monthDelivery, int yearDelivery,
            decimal price, decimal cost)
        {
            Id = id;
            Name = name;
            Client = client;
            Manager = manager;
            StartDate = new DateTime(dayStart, monthStart, yearStart);
            FinishDate = new DateTime(dayFinish, monthFinish, yearFinish);
            DeliveryDate = new DateTime(dayDelivery, monthDelivery, yearDelivery);
            Price = price;
            Cost = cost;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string Manager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
}
}
