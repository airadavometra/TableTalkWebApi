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
		/*public async Task<ActionResult> Index()
		{
			try
			{
				CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetValue<string>("tabletalkwebapistorage"));

				blobClient = storageAccount.CreateCloudBlobClient();
				blobContainer = blobClient.GetContainerReference(blobContainerName);
				await blobContainer.CreateIfNotExistsAsync();

				await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

				List<Uri> allBlobs = new List<Uri>();

				BlobContinuationToken blobContinuationToken = null;
				do
				{
					var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
					foreach (var blob in response.Results)
					{
						if (blob.GetType() == typeof(CloudBlockBlob))
							allBlobs.Add(blob.Uri);
					}
					blobContinuationToken = response.ContinuationToken;
				} while (blobContinuationToken != null);

				
				return View(allBlobs);
			}
			catch (Exception ex)
			{
				return View("error");
			}
		}

		public async Task<ActionResult> UploadAsync()
		{
			try
			{
				var request = await HttpContext.Request.ReadFormAsync();
				if (request.Files == null || request.Files.Count == 0)
					return BadRequest();
				var files = request.Files;
				for(int i = 0; i < files.Count; i++)
				{
					CloudBlockBlob blob = blobContainer.GetBlockBlobReference(i.ToString());
					using(var stream = files[i].OpenReadStream())
					{
						await blob.UploadFromStreamAsync(stream);
					}
				}
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View("error");
			}
		}
		public async Task<ActionResult> DeleteImage(string name)
		{
			try
			{
				var uri = new Uri(name);
				var filename = Path.GetFileName(uri.LocalPath);

				CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
				await blob.DeleteIfExistsAsync();

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View("error");
			}
		}
		public async Task<ActionResult> DeleteAll()
		{
			try
			{
				BlobContinuationToken blobContinuationToken = null;
				do
				{
					var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
					foreach (var blob in response.Results)
					{
						if (blob.GetType() == typeof(CloudBlockBlob))
							await ((CloudBlockBlob)blob).DeleteIfExistsAsync();
					}
					blobContinuationToken = response.ContinuationToken;
				} while (blobContinuationToken != null);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View("error");
			}
		}*/
	}
}