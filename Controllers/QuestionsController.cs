using System;
using Microsoft.AspNetCore.Mvc;

namespace TableTalkWebApplication.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class QuestionsController : Controller
	{
		public QuestionsController(IQuestionsRepository questions)
		{
			Questions = questions;
		}
		public IQuestionsRepository Questions { get; set; }

		public string GetQuestionsCount()
		{
			return Questions.GetQuestionsCount();
		}

		[HttpGet("{index}")]
		public IActionResult GetQuestion(string index)
		{
			var item = Questions.GetQuestion(Convert.ToInt32(index));
			return new ObjectResult(item);
		}
	}
}