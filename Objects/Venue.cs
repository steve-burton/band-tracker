using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BandTracker.Objects
{
	public class Venue
	{
		private int _id;
		private string _venueName;

		public Venue(string venueName, int id = 0)
		{
			_id = id;
			_venueName = venueName;
		}

		public int GetId()
		{
			return _id;
		}
		public string GetVenueName()
		{
			return _venueName;
		}

		public override bool Equals(Object otherVenue)
		{
			if(!(otherVenue is Venue))
			{
				return false;
			}
			else
			{
				Venue newVenue = (Venue) otherVenue;
				bool idEquality = (this._id == newVenue.GetId());
				bool nameEquality = (this._venueName == newVenue.GetVenueName());
				return (idEquality && nameEquality);
			}
		}

		public static List<Venue> GetAll()
    {
      List<Venue> allVenues= new List<Venue>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);

        Venue newVenue = new Venue(venueName, id);
        allVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues;
    }

		public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (venue_name) OUTPUT INSERTED.id VALUES (@VenueName);", conn);

      cmd.Parameters.AddWithValue("@VenueName", _venueName);
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

		public static Venue Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);
      cmd.Parameters.AddWithValue("@VenueId", id);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string venueName = "";

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        venueName = rdr.GetString(1);
      }
      Venue foundVenue = new Venue(venueName, foundId);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundVenue;
    }

		public void UpdateVenue(string newVenueName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand ("UPDATE venues SET venue_name = @NewVenueName OUTPUT INSERTED.venue_name WHERE id = @VenueId;", conn);

      cmd.Parameters.AddWithValue("@NewVenueName", newVenueName);
      cmd.Parameters.AddWithValue("@VenueId", _id);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._venueName = rdr.GetString(0);
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




		public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM venues", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
	}
}
