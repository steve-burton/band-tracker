using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source =(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security =SSPI;";
    }

    [Fact]
    public void Equals_EqualsOverrideComparesObjects_true()
    {
      Venue venue1 = new Venue("Wonder Ballroom");
      Venue venue2 = new Venue("Wonder Ballroom");

      Assert.Equal(venue1, venue2);
    }

    [Fact]
    public void GetAll_StartsWithEmptyDB_true()
    {
      List<Venue> allVenues = Venue.GetAll();

      Assert.Equal(0, allVenues.Count);
    }

    [Fact]
    public void Save_SavesToDatabase_true()
    {
      Venue newVenue = new Venue("Wonder Ballroom");
      List<Venue> testList = new List<Venue>{newVenue};

      newVenue.Save();
      List<Venue> result = Venue.GetAll();

      Assert.Equal(result, testList);
    }

    [Fact]
    public void Find_RetrievesVenueFromDB_true()
    {
      Venue newVenue = new Venue("Wonder Ballroom");
      newVenue.Save();

      Venue result = Venue.Find(newVenue.GetId());

      Assert.Equal(newVenue, result);
    }

    [Fact]
    public void UpdateVenue_UpdateVenueInDB_true()
    {
      string venueName = "Wonder Ballroom";
      Venue testVenue = new Venue(venueName);
      testVenue.Save();

      string newVenueName = "Wonder Dancehall";

      testVenue.UpdateVenue(newVenueName);
      string result = testVenue.GetVenueName();

      Assert.Equal(newVenueName, result);
    }

    [Fact]
    public void Delete_DeletesVenueFromDB_true()
    {
      Venue venue1 = new Venue("Wonder Ballroom");
      venue1.Save();
      Venue venue2 = new Venue("Crystal Ballroom");
      venue2.Save();
      List<Venue> expectedResult = new List<Venue>{venue2};

      venue1.Delete();
      List<Venue> result = Venue.GetAll();

      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void AddBand_AddBandsForVenues_true()
    {
      Venue newVenue = new Venue("Wonder Ballroom");
      Band band1 = new Band("Mighty Mighty Bosstones");
      Band band2 = new Band("The Decemberists");
      newVenue.Save();
      band1.Save();
      band2.Save();
      List<Band> expectedList = new List<Band> {band1};

      newVenue.AddBand(band1.GetId());
      List<Band> result = newVenue.GetAllBands();

      Assert.Equal(result, expectedList);
    }

    [Fact]
    public void GetAllBands_ReturnsAllBandsForAVenue_true()
    {
      Venue newVenue = new Venue("Wonder Ballroom");
      Band band1 = new Band("Mighty Mighty Bosstones");
      Band band2 = new Band("The Decemberists");
      newVenue.Save();
      band1.Save();
      band2.Save();
      List<Band> expectedList = new List<Band> {band1, band2};

      newVenue.AddBand(band1.GetId());
      newVenue.AddBand(band2.GetId());
      List<Band> result = newVenue.GetAllBands();

      Assert.Equal(result, expectedList);
    }







    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
