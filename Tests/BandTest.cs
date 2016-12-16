using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source =(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security =SSPI;";
    }

    [Fact]
    public void Equals_EqualsOverrideComparesObjects_true()
    {
      Band band1 = new Band("Mighty Mighty Bosstones");
      Band band2 = new Band("Mighty Mighty Bosstones");

      Assert.Equal(band1, band2);
    }

    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}
