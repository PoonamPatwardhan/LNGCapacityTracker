using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
public class LngTracker
{
    private List<Ship>? ships {get; set;}
    private const double conversionFactor = 0.001;

    public void GetShipDataFrom(string filepath)
    {
        ships = ConvertJsonToShipData(filepath);
    }

    public int CalculateLitresToFillShipsBuiltInGivenYearToGivenPercent(int year, int percent)
    {
        var shipsBuiltInGivenYear = GetAllShipsBuiltIn(year);
        int totalLitresToBeFilledInAllShips = 0;
        foreach(var ship in shipsBuiltInGivenYear)
        {
            if (ship != null)
            {
               var litresToFill = ship.CalculateAvailableCapacity();
               totalLitresToBeFilledInAllShips += litresToFill;      
            }                  
        }
        var totalLitresToFillForGivenPercent = (percent/ 100) * totalLitresToBeFilledInAllShips;
        return totalLitresToFillForGivenPercent;
    }

    public int CalculateMinimumShipsToCarryGivenCapacity(int amountToBeFilled)
    {
        int minNumberOfShipsToBeFilled = 0;
        int availableCapacity = 0;
        foreach(var ship in ships)
        {
            if (ship != null)
            {
                availableCapacity += ship.CalculateAvailableCapacity();
                availableCapacity = Convert.ToInt32(availableCapacity * conversionFactor);
                if (availableCapacity <= amountToBeFilled)
                    minNumberOfShipsToBeFilled += 1;
                if (availableCapacity > amountToBeFilled)
                    break;
            }
        }
        return minNumberOfShipsToBeFilled;

    }

    public List<Ship> GetAllShipsOrderedByTotalAndAvailableCapacity()
    {
        return new List<Ship>(); // could not get time to implement this, since I crossed the 2 hours threshold
    }

    private List<Ship>? ConvertJsonToShipData(string filepath)
    {
        var jsonContentForAllShips = File.ReadAllText(filepath);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ship>>(jsonContentForAllShips);
    }

    private List<Ship>? GetAllShipsBuiltIn(int year)
    {
        var result = ships?.Where(ship => ship.YearBuilt == year).ToList();
        return result;
    }
}
public class LngApplication
{
    public static void Main()
    {
        LngTracker lngTrackingTool = new LngTracker();        
        lngTrackingTool.GetShipDataFrom("shipdata.json");
    }
}
