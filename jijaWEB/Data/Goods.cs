using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jijaWEB.Data
{
    public class Goods
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

		private decimal _price;

		public decimal price
		{
			get { return _price; }
			set { _price = value; }
		}
		private int _id_category;

		public int id_category
		{
			get { return _id_category; }
			set { _id_category = value; }
		}

		private string _image;

		public string image
		{
			get { return _image; }
			set { _image = value; }
		}




	}
}
