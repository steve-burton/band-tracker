using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BandTracker.Objects
{
	public class Venue
	{
		public Venue()
		{
			private int _id;
			private string _venueName;

			public Band(string venueName, int id = 0)
			{
				_id = id;
				_venueName = venueName,
			}

			public int GetId()
			{
				return _id;
			}
			public string GetVenueName()
			{
				return _venueName;
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
}
