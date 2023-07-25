using System.Collections.Generic;
public class Ship
{
    public string Name {get; set;} = string.Empty;
    public int YearBuilt {get;set;} = 0;
    public List<Tank> Tanks {get;set;}

    public int CalculateAvailableCapacity()
    {        
        int litresToFill = 0;
        foreach(var tank in Tanks)
        {
            if (tank.isAvailable())
                litresToFill += tank.CalculateAvailableCapacity();
        }        
        return litresToFill;            
    }
}

