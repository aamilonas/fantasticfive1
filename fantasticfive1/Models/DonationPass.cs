public enum PassType { Food, Hygiene }
public class DonationPass
{
    public int Id { get; set; }
    public string? DonorName { get; set; }

    public string? DonorEmail { get; set; }

    public PassType PassType { get; set; }

    public string? PassCode { get; set; }

    public int Value { get; set; }
}