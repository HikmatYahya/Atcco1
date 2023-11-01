using Atcco.Models.Projects;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project
{
	[Key] // Define the primary key

	public int ProjectId { get; set; }

	[Required(ErrorMessage = "Title is required.")]
	[StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters.")]
	public string Title { get; set; }

	[Required(ErrorMessage = "Content is required.")]
	[StringLength(5000, MinimumLength = 10, ErrorMessage = "Content must be between 10 and 5000 characters.")]
	public string Content { get; set; }

	[DataType(DataType.Date)]
	[Display(Name = "Publish Date")]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	public DateTime PublishDate { get; set; }


	[Display(Name = "Images")]
	public List<ImagePath> Images { get; set; }




	[Display(Name = "Location")]
	public string Location { get; set; }

	[Display(Name = "Category")]
	public Category category { get; set; }

}

public class ImagePath
{
	[Key] // Define the primary key for ImagePath
	public int ImagePathId { get; set; }

	public string imagePath { get; set; } // Corrected property name

	public int ProjectId { get; set; }

	[ForeignKey("ProjectId")]
	public Project Project { get; set; }
}