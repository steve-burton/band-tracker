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











    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
