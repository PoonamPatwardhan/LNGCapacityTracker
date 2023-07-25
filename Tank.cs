public class Tank
{
    public string Product {get; set;} = string.Empty;
    public int Capacity {get; set;} = -1;
    public int FillPercentage {get; set;} = -1;

    public bool isAvailable()
    {
        return FillPercentage != -1;
    }

    public int CalculateAvailableCapacity()
    {
        int totalCapacityOfTank = Capacity;
        int percentFilled = FillPercentage;
        int litresAlreadyFilled = (percentFilled/100) * totalCapacityOfTank;
        return totalCapacityOfTank - litresAlreadyFilled;
    }
}