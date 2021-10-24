using Estudos.LG.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estudos.LG.NHibernate.Services
{
    public static class CostumerServices
    {
        public static void CreateCostumer(Costumer costumer)
        {
            using (var session = Session.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(costumer);
                    session.Flush();
                    transaction.Commit();
                }
            }
        }

        public static void DeleteCostumer(Costumer costumer)
        {
            using (var session = Session.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(costumer);
                    session.Flush();
                    transaction.Commit();
                }
            }
        }

        public static Costumer GetCostumerById(int costumerID)
        {
            using (var session = Session.GetSession())
            {
                return session.Query<Costumer>()
                    .Where(x => x.Id == costumerID)
                    .FirstOrDefault();
            }
        }

        public static Costumer GetCostumerName(string nameCostumer)
        {
            using (var session = Session.GetSession())
            {
                return session.Query<Costumer>()
                    .Where(x => x.FirstName == nameCostumer)
                    .FirstOrDefault();
            }

        }

        internal static object GetCostumerById(object getValidID)
        {
            throw new NotImplementedException();
        }

        public static List<Costumer> GetAllCostumers()
        {
            using (var session = Session.GetSession())
            {
                return session.Query<Costumer>().ToList();
            }
        }

        public static void UpdateCostumer(Costumer costumer)
        {
            using (var session = Session.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(costumer);
                    session.Flush();
                    transaction.Commit();
                }
            }
        }
    }
}
