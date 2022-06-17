#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Chef
{
  [Key]
  public int ChefId { get; set; }

  [Required]
  [Display(Name = "First Name")]
  public string FirstName { get; set; }

  [Required]
  [Display(Name = "Last Name")]
  public string LastName { get; set; }

  [Required]
  [Display(Name = "Date of Birth")]
  [OverEighteenValidation(ErrorMessage = "HEY MAN U TOO YOUNG!!!")]
  public DateTime BirthDay { get; set; }

  public DateTime createdAt { get; set; } = DateTime.Now;
  public DateTime updatedAt { get; set; } = DateTime.Now;

  public List<Dish> Dishes { get; set; } = new List<Dish>();
}