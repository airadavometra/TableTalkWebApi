using System.Linq;
using TableTalkWebApplication.Models;

namespace TableTalkWebApplication
{
	public class QuestionsRepository : IQuestionsRepository
	{
		private static QuestionsModel questions = new QuestionsModel();
		public string GetQuestion(int index)
		{
			if (index >= questions.ListOfQuestions.Count())
				return null;
			return questions.ListOfQuestions[index];
		}

		public string GetQuestionsCount()
		{
			return questions.ListOfQuestions.Count().ToString();
			//string result = "";
			//foreach (var item in questions.ListOfQuestions)
			//	result = result + item;
			//return result;
		}
	}
}
