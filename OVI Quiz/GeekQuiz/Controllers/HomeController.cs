using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeekQuiz.Controllers;
using GeekQuiz.Models;
using GeekQuiz.Services;
using System.Threading.Tasks;
namespace GeekQuiz.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var questions = new List<string>();
            using (var context = new TriviaContext())
            {
                foreach (var question in context.TriviaQuestions)
                {
                    questions.Add(question.Title);
                }
            }
            //  Pass Data to the View
            ViewData["active"] = ActiveQuestion();
            ViewData["questions"] = questions;
            return View();
        }

        /// <summary>
        /// Returns Current active Question from TriviaController
        /// </summary>
        /// <returns>TriviaController.nextquestion</returns>
        public string ActiveQuestion()
        {
            TriviaController triviaController = new TriviaController();
            // Asyncrhonous methos requires time to run
            Task<TriviaQuestion> task = Task.Run(async () => await triviaController.Get());
            task.Wait();
            var activeQuestion = task.Result.Title;
            return activeQuestion;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}