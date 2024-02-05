﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
	public class _DefaultSliderComponentPartial:ViewComponent
	{

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
          
           _httpClientFactory = httpClientFactory;
        }

            public async Task< IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();//istemci oluşturduk
            var responseMessage = await client.GetAsync("https://localhost:7156/api/Slider");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();//jsondan gelen içeriği string formatında oku.
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return View(values);
          
        }
	}
}