using Estudos.LG.NHibernate.Models;
using Estudos.LG.NHibernate.Services;
using System;
using Estudos.LG.NHibernate.Utils;
using System.Collections.Generic;

namespace Estudos.LG.NHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish;
            var listOfAllCostumers = new List<Costumer>();
            do
            {
                listOfAllCostumers = CostumerServices.GetAllCostumers();
                Console.WriteLine("*********** COSTUMERS ***********");
                foreach (var costumer in listOfAllCostumers)
                {
                    Console.WriteLine($"{costumer.Id} - {costumer}");
                }
                Console.WriteLine();
                isFinish = Util.SelectService(Util.DisplayMenu());
                Console.Clear();
            } while (!isFinish);
        }
    }
}
