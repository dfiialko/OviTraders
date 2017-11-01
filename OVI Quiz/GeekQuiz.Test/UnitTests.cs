using NUnit.Framework;
using GeekQuiz.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using GeekQuiz.Services;
using System.Linq;
using System.Collections.Generic;

namespace GeekQuiz.Test
{
    [TestFixture]
    public class UnitTests
    {
        private TriviaContext db;
        // Add your 2 test methods here
        [Test]
        public void WrongAnswer()
        {
            // Manually Added Trivia Answer not to initialize database;
            TriviaAnswer answer = new TriviaAnswer
            {
                UserId = "name",
                OptionId = 13,
                QuestionId = 4,
                Id = 48
            };
            TriviaOption a = new TriviaOption();
            List<TriviaOption> options = new List<TriviaOption>();
            // Manually Added Trivia Option not to initialize database;
            a.Title = "What fictional company did Nancy Davolio work for?";
            a.QuestionId = 4;
            a.Id = 13;
            a.IsCorrect = false;
            options.Add(a);
            
            var selectedOption = options.FirstOrDefault(o => o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            Assert.IsFalse(selectedOption.IsCorrect);
        }

        [Test]
        public void RightAnswer()
        {
            // Manually Added Trivia Answer not to initialize database;
            TriviaAnswer answer = new TriviaAnswer
            {
                UserId = "name",
                OptionId = 48,
                QuestionId = 12
            };
            TriviaOption a = new TriviaOption();
            List<TriviaOption> options = new List<TriviaOption>();
            // Manually Added Trivia Option not to initialize database;
            a.Title = "How many function calls did Windows 1.0 approximately have?";
            a.QuestionId = 12;
            a.Id = 48;
            a.IsCorrect = true;
            options.Add(a);
            var selectedOption = options.FirstOrDefault(o => o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            Assert.IsTrue(selectedOption.IsCorrect);
        }

    }
}
