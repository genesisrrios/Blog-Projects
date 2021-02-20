using AspNetCoreVueJs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AspNetCoreVueJs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private const string TempDataFriendsList = "FriendsList";

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		public IActionResult Index()
		{
			var friendsList = new List<User>
				{
					new User
					{
						LastName = "Ford",
						Name = "Henry",
						Username = "henryford121"
					},
					new User
					{
						LastName = "Montgo",
						Name = "Suzzie",
						Username = "mongosus"
					},
					new User
					{
						LastName = "Rivera",
						Name = "Luis",
						Username = "starraiden"
					} 
			};
			TempData[TempDataFriendsList] = JsonConvert.SerializeObject(friendsList);
			var model = new IndexViewModel
			{
				User = new User
				{
					LastName = "Rivera",
					Name = "Genesis",
					Username = "genesisrrios"
				},
				FriendList = friendsList
			};
			return View(model);
		}
		[HttpPost]
        public bool InsertNewFriendInMemory([FromBody]User friend)
        {
        if (friend == default || !TempData.ContainsKey(TempDataFriendsList)) return false;
			var tempData = TempData[TempDataFriendsList];
			var deserializedData = JsonConvert.DeserializeObject<List<User>>((string)tempData);
			deserializedData.Add(friend);
			TempData[TempDataFriendsList] = JsonConvert.SerializeObject(deserializedData);
            return true;
        }
        public List<User> GetFriendsList()
        {
            var tempData = TempData[TempDataFriendsList];
			TempData.Keep();
			var deserializedData = JsonConvert.DeserializeObject<List<User>>((string)tempData);
			return deserializedData;
		}
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
