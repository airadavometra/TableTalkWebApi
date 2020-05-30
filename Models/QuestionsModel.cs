using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;

namespace TableTalkWebApplication.Models
{
	public class QuestionsModel
	{
		private static CloudBlobClient _blobClient;
		private const string _blobContainerName = "tabletalkquestions";
		private static CloudBlobContainer _blobContainer;
		private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=tabletalkwebapistorage;AccountKey=4Q88++maDjyZYWKsyKkDznz5cB0kE8V9C6D2cXT/ptn6M9C6u+kFiSnf7pW7ZtMCc4EwaG0ik1WWI4m+dQMbHQ==;EndpointSuffix=core.windows.net";

		public string[] ListOfQuestions { get; set; }

		public QuestionsModel()
		{
			try
			{
				CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

				_blobClient = storageAccount.CreateCloudBlobClient();
				_blobContainer = _blobClient.GetContainerReference(_blobContainerName);

				CloudBlockBlob blob = _blobContainer.GetBlockBlobReference("rus.txt");

				string text = blob.DownloadTextAsync().Result;

				ListOfQuestions = text.Split("\r\n");

			}
			catch (Exception ex)
			{
			}
		}
		private void Shuffle(List<string> list)
		{
			Random rand = new Random();

			for (int i = list.Count - 1; i >= 1; i--)
			{
				int j = rand.Next(i + 1);

				string tmp = list[j];
				list[j] = list[i];
				list[i] = tmp;
			}
		}
	}
}
