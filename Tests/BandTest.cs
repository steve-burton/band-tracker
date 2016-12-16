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


    
    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}
