using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BandTracker.Objects
{
	public class Band
	{
		private int _id;
		private string _bandName;

		public Band(string bandName, int id = 0)
		{
			_id = id;
			_bandName = bandName;
		}

		public int GetId()
		{
			return _id;
		}
		public string GetBandName()
		{
			return _bandName;
		}

		public override bool Equals(Object otherBand)
		{
			if(!(otherBand is Band))
			{
				return false;
			}
			else
			{
				Band newBand = (Band) otherBand;
				bool idEquality = (this._id == newBand.GetId());
				bool nameEquality = (this._bandName == newBand.GetBandName());
				return (idEquality && nameEquality);
			}
		}

		public static List<Band> GetAll()
    {
      List<Band> allBands= new List<Band>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);

        Band newBand = new Band(bandName, id);
        allBands.Add(newBand);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allBands;
    }

		public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands (band_name) OUTPUT INSERTED.id VALUES (@BandName);", conn);

      cmd.Parameters.AddWithValue("@BandName", _bandName);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        _id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

		public static Band Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);
      cmd.Parameters.AddWithValue("@BandId", id);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string bandName = "";

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        bandName = rdr.GetString(1);
      }
      Band foundBand = new Band(bandName, foundId);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundBand;
    }

		public void AddVenue(int venueId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);
      cmd.Parameters.AddWithValue("@BandId", _id);
			cmd.Parameters.AddWithValue("@VenueId", venueId);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

		public List<Venue> GetAllVenues()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN bands_venues ON (bands.id = bands_venues.band_id) JOIN venues ON (bands_venues.venue_id = venues.id) WHERE bands.id = @BandId;", conn);
      cmd.Parameters.AddWithValue("@BandId", _id);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string venueName = "";
      List<Venue> bandVenues = new List<Venue> {};

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        venueName = rdr.GetString(1);
        Venue foundVenue = new Venue(venueName, foundId);
        bandVenues.Add(foundVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return bandVenues;
    }




		public static void DeleteAll()
		{
			SqlConnection conn = DB.Connection();
			conn.Open();
			SqlCommand cmd = new SqlCommand("DELETE FROM bands", conn);
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
}
