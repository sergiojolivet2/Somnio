using NHibernate;
using NHibernate.Criterion;
using Somnio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Somnio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ISession session = MvcApplication.SessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(PurchaseHistory));
                IList<PurchaseHistory> purchaseHistoryList = criteria.List<PurchaseHistory>();

                return View(purchaseHistoryList);
            }
        }

        public ActionResult FilterByCost()
        {
            using (ISession session = MvcApplication.SessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(PurchaseHistory));
                criteria.Add(Restrictions.Gt("TotalCost", 1000M));
                IList<PurchaseHistory> purchaseHistoryList = criteria.List<PurchaseHistory>();

                return PartialView("_PurchaseHistoryTable", purchaseHistoryList);
            }
        }

        public ActionResult SortByDateDesc()
        {
            using (ISession session = MvcApplication.SessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(PurchaseHistory));
                criteria.AddOrder(Order.Desc("Date"));
                IList<PurchaseHistory> purchaseHistoryList = criteria.List<PurchaseHistory>();

                return PartialView("_PurchaseHistoryTable", purchaseHistoryList);
            }
        }
    }
}