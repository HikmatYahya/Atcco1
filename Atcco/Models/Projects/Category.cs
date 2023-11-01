using System.ComponentModel.DataAnnotations;

namespace Atcco.Models.Projects
{
	public enum Category
	{
		[Display(Name = "Water and Sewage")]
		WaterAndSewage,

		[Display(Name = "Heavy Civil Consturction")]
		HeavyCivilConsturction,

		[Display(Name = "Residential Building")]
		ResidentialBuilding,

		[Display(Name = "Renewable Energy")]
		RenewableEnergy,

		[Display(Name = "Industrial")]
		Industrial,

		[Display(Name = "Gas Stations")]
		GasStations,

		[Display(Name = "Enviromental")]
		Enviromental,

		[Display(Name = "Commercial Building")]
		CommercialBuilding,

		[Display(Name = "Atcco Shoring")]
		AtccoShoring,

		[Display(Name = "Atcco Steel")]
		AtccoSteel,
	}
}
