using ExpenseTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpenseDbContext _expenseDbContext;

        public HomeController(ILogger<HomeController> logger, ExpenseDbContext expenseDbContext)
        {
            _logger = logger;
            _expenseDbContext = expenseDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expense()
        {
            //converting all the expenses data to lists
            var allexpenses = _expenseDbContext.ExpenseData.ToList();

            //calculate the total
            var total = allexpenses.Sum(expense => expense.Value);


            //store the total
            ViewBag.Expenses = total;

            return View(allexpenses); 
        }

        public IActionResult AddExpense(int? id)
        {
            if(id != null)
            {

                var expenseInDb = _expenseDbContext.ExpenseData.SingleOrDefault(expense => expense.Id == id);
                return View(expenseInDb);

            }

            return View();
        }

        public IActionResult DeleteExpenses(int id)
        {
            var expenseInDb = _expenseDbContext.ExpenseData.SingleOrDefault(expense => expense.Id == id);
            _expenseDbContext.ExpenseData.Remove(expenseInDb);
            _expenseDbContext.SaveChanges();
            return RedirectToAction("Expense");
        }

        public IActionResult ExpenseForm(ExpenseData model)
        {
            if(model.Id == 0)
            {
                _expenseDbContext.ExpenseData.Add(model);
            }
            else
            {
                _expenseDbContext.ExpenseData.Update(model);
            }

            _expenseDbContext.SaveChanges();

            return RedirectToAction("Expense");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
