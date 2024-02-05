using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturduk
			var responseMessage = await client.GetAsync("https://localhost:7156/api/SocialMedia");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//jsondan gelen içeriği string formatında oku.
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}
			return View();

		}
	}
}
