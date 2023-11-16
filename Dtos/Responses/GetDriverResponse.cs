namespace FormulaOne.Dtos.Responses;

public class GetDriverResponse
{
    public Guid DriverId { get; set; }
    public string FullName { get; set; }
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}