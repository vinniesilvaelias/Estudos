using Estudos.LG.NHibernate.Models;
using Estudos.LG.NHibernate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.LG.NHibernate.Utils
{
    public static class Util
    {
        public static int DisplayMenu()
        {
            int option;
            do
            {
                Console.WriteLine("[ 0 ] FINISH");
                Console.WriteLine("[ 1 ] CREATE");
                Console.WriteLine("[ 2 ] UPDATE");
                Console.WriteLine("[ 3 ] DELETE");
                Console.Write("\n >> ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (option < 0 || option > 3);
            return option;
        }

        public static bool SelectService(int option)
        {
            switch (option)
            {
                case 1: CostumerServices.CreateCostumer(Create());
                    return false;
                case 2:
                    CostumerServices.UpdateCostumer(Update());
                    return false;
                case 3:
                    CostumerServices.DeleteCostumer(
                        CostumerServices.GetCostumerById(GetValidID()));
                    return false;
                default:
                    return true;
            }
        }

        private static Costumer Create()
        {
            var costumer = new Costumer();
            SetCostumerFields(costumer);
            return costumer;
        }

        private static Costumer Update()
        {
            var costumer =  CostumerServices.GetCostumerById(GetValidID());
            SetCostumerFields(costumer);
            return costumer;
        }

        private static int GetValidID()
        {
            int validID;
            do
            {
                Console.Clear();
                Console.Write("Enter to Costumer ID: ");
                validID = int.Parse(Console.ReadLine());

            } while (validID < 0);
            return validID;
        }

        private static void SetCostumerFields(Costumer costumer)
        {
            do
            {
                Console.Clear();
                Console.Write("Enter to First name: ");
                costumer.FirstName = Console.ReadLine()
                                            .ToUpper();
                Console.Write("Enter to Last name: ");
                costumer.LastName = Console.ReadLine()
                                           .ToUpper();
            } while (String.IsNullOrEmpty(costumer.FirstName) ||
                    String.IsNullOrEmpty(costumer.LastName));
        }
    }
}
