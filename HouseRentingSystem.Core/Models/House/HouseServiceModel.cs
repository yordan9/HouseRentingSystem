using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Models.House
{
	public class HouseServiceModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Address {  get; set; } = string.Empty;

		[Display(Name = "Image URL")]
		public string ImageURL { get; set; } = string.Empty;

		[Display(Name = "Price per month")]
		public decimal PricePerMonth { get; set; }

		[Display(Name = "Is Rented")]
		public bool IsRented { get; set; }
	}
}
