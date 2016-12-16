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
