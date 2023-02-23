using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KF_WebIntro.Controllers
{
	public class FeatureController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AreaManage()
		{
			return View();
		}
		public IActionResult FarmerDiary()
		{
			return View();
		}
		public IActionResult SurveySheet()
		{
			return View();
		}
		public IActionResult ConnectIot()
		{
			return View();
		}
	}
}
