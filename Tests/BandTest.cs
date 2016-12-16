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

    [Fact]
    public void GetAll_StartsWithEmptyDB_true()
    {
      List<Band> allBands = Band.GetAll();

      Assert.Equal(0, allBands.Count);
    }

    [Fact]
    public void Save_SavesToDatabase_true()
    {
      Band newBand = new Band("Mighty Mighty Bosstones");
      List<Band> testList = new List<Band>{newBand};

      newBand.Save();
      List<Band> result = Band.GetAll();

      Assert.Equal(result, testList);
    }

    [Fact]
    public void Find_RetrievesBandFromDB_true()
    {
      Band newBand = new Band("Mighty Mighty Bosstones");
      newBand.Save();

      Band result = Band.Find(newBand.GetId());

      Assert.Equal(newBand, result);
    }

    [Fact]
    public void AddVenue_AddVenuesForBands_true()
    {
      Band newBand = new Band("Mighty Mighty Bosstones");
      Venue venue1 = new Venue("Wonder Ballroom");
      Venue venue2 = new Venue("Crystal Ballroom");
      newBand.Save();
      venue1.Save();
      venue2.Save();
      List<Venue> expectedList = new List<Venue> {venue1};

      newBand.AddVenue(venue1.GetId());
      List<Venue> result = newBand.GetAllVenues();

      Assert.Equal(result, expectedList);
    }

    [Fact]
    public void GetAllVenues_ReturnsAllVenuesForABand_true()
    {
      Band newBand = new Band("Mighty Mighty Bosstones");
      Venue venue1 = new Venue("Wonder Ballroom");
      Venue venue2 = new Venue("Crystal Ballroom");
      newBand.Save();
      venue1.Save();
      venue2.Save();
      List<Venue> expectedList = new List<Venue> {venue1, venue2};

      newBand.AddVenue(venue1.GetId());
      newBand.AddVenue(venue2.GetId());
      List<Venue> result = newBand.GetAllVenues();

      Assert.Equal(result, expectedList);
    }




    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}
