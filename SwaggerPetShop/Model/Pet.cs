using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SwaggerPetShop.Model
{
	[JsonObject(Title = "Root")]
	public class Pet
	{
		public int Id { get; set; }

		public Category Category { get; set; }

		public string Name { get; set; }

		public PhotoUrls PhotoUrls { get; set; }

		public Tags Tags { get; set; }

		public string Status { get; set; }
	}
}









	

