namespace Hermes.Server.Api.Anagrams
{
	using Hermes.Server.Api.Core.Anagrams;

	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;

	[Route(AnagramsRoutePaths.BasePath)]
	[Produces("application/json")]
	public class AnagramsController : ControllerBase
	{
		private readonly IAnagramsProvider anagramsProvider;

		public AnagramsController(IAnagramsProvider anagramsProvider)
		{
			this.anagramsProvider = anagramsProvider;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAnagramsResults))]
		public ActionResult<GetAnagramsResults> GetAnagrams(string q)
		{
			var anagrams = this.anagramsProvider.GetAnagrams(q, 3);
			return this.Ok(new GetAnagramsResults(anagrams));
		}
	}
}