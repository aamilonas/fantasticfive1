using System.ComponentModel.DataAnnotations;
public enum PassType { Food, Hygiene }
public class DonationPass
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string? DonorName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid e-mail")]
    public string? DonorEmail { get; set; }

    [Required(ErrorMessage = "Pass Type is Required")]
    public PassType PassType { get; set; }

    [Required(ErrorMessage = "Code is required")]
    public string? PassCode { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Range must be greater than 0")]
    public int Value { get; set; }
}