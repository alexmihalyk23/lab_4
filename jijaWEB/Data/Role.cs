using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jijaWEB.Data
{
    public class Role
    {
		private int _id;

		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _description;

		public string description
		{
			get { return _description; }
			set { _description = value; }
		}



	}
}
