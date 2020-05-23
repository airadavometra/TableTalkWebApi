namespace TableTalkWebApplication
{
	public interface IQuestionsRepository
	{
		string GetQuestionsCount();
		string GetQuestion(int index);
	}
}
