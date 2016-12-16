using Nancy;
using System.Collections.Generic;
using System;
using BandTracker.Objects;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
	public class HomeModule : NancyModule
	{
		public HomeModule()
		{
			Get["/"] = _ =>
			{
				return View["index.cshtml"];
			};
		}
	}
}
