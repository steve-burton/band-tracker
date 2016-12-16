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
			Get["/"] = _ => {
				return View["index.cshtml"];
			};
			Get["/add-new-band"] = _ => {
				return View["/add-new-band.cshtml"];
			};
			Get["/add-new-venue"] = _ => {
				return View["/add-new-venue.cshtml"];
			};
			Get["/all-bands"] = _ => {
				List<Band> allBands = Band.GetAll();
				return View["/all-bands.cshtml", allBands];
			};
			Get["/all-venues"] = _ => {
				List<Venue> allVenues = Venue.GetAll();
				return View["/all-venues.cshtml", allVenues];
			};
			Post["/added-band"] = _ => {
				Band newBand = new Band(Request.Form["band-name"]);
				newBand.Save();
				return View["/success.cshtml"];
			};
			Post["/added-venue"] = _ => {
				Venue newVenue = new Venue(Request.Form["venue-name"]);
				newVenue.Save();
				return View["/success.cshtml"];
			};
			Get["/band/{id}"] = parameters => {
				Band selectedBand = Band.Find(parameters.id);
				Dictionary<string, object> model = new Dictionary<string, object>();
        List<Venue> bandVenues = selectedBand.GetAllVenues();
        model.Add("band", selectedBand);
        model.Add("bandVenues", bandVenues);
        return View["band.cshtml", model];
			};
		}
	}
}
