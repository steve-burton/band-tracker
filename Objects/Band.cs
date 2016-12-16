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
			_bandName = bandName,
		}

		public int GetId()
		{
			return _id;
		}
		public string GetBandName()
		{
			return _bandName;
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
