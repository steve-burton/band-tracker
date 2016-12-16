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


    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
