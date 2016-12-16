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
