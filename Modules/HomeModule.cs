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

			Get["/band-add-venue/{id}"] = parameters => {
				Band selectedBand = Band.Find(parameters.id);
				return View["/band-add-venue.cshtml", selectedBand];
			};
			Post["/venue-added"] = _ => {
				Band newBand = new Band(Request.Form["band-venue"]);
				newBand.Save();
				return View["/success.cshtml"];
			};
			Get["/venue-add-band/{id}"] = parameters => {
				Venue selectedVenue = Venue.Find(parameters.id);
				return View["/venue-add-band.cshtml", selectedVenue];
			};
			Post["/band-added"] = _ => {
				Venue newVenue = new Venue(Request.Form["venue-band"]);
				newVenue.Save();
				return View["/success.cshtml"];
			};


			Get["/venue/update/{id}"] = parameters => {
				Venue selectedVenue = Venue.Find(parameters.id);
				return View["/venue-update.cshtml", selectedVenue];
			};
			Patch["/venue/update/{id}"] = parameters => {
				Venue selectedVenue = Venue.Find(parameters.id);
				selectedVenue.UpdateVenue(Request.Form["venue-name"]);
				return View["/success.cshtml"];
			};

			Get["/venue/delete/{id}"] = parameters => {
				Venue selectedVenue = Venue.Find(parameters.id);
				return View["/success.cshtml", selectedVenue];
			};
			Patch["/venue/delete/{id}"] = parameters => {
				Venue selectedVenue = Venue.Find(parameters.id);
				selectedVenue.Delete();
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
			Get["/venue/{id}"] = parameters => {
				Venue selectedVenue = Venue.Find(parameters.id);
				Dictionary<string, object> model = new Dictionary<string, object>();
        List<Band> venueBands = selectedVenue.GetAllBands();
        model.Add("venue", selectedVenue);
        model.Add("venueBands", venueBands);
        return View["venue.cshtml", model];
			};
		}
	}
}
