
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation()},
            {"Fire", new Nation() },
           {"Earth", new Nation() },
             {"Water", new Nation()}
        };

        this.warHistoryRecord = new List<string>();
    }
   public void AssignBender(List<string> benderArgs)
    {
        //type, name, power, secPar, 
        var benderType = benderArgs[0];
        Bender currentBender = this.GetBender(benderArgs);
        this.nations[benderType].AddBender(currentBender);

    }

    public Bender GetBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        var benderName = benderArgs[1];
        var benderPower = int.Parse(benderArgs[2]);
        var benderAuxParam = double.Parse(benderArgs[3]);

        switch (benderType)
        {
            case "Air":
                return new AirBender(benderName, benderPower, benderAuxParam);
                break;
            case "Water":
                return new WaterBender(benderName, benderPower, benderAuxParam);
                break;
            case "Fire":
                return new FireBender(benderName, benderPower, benderAuxParam);
                break;
            case "Earth":
                return new EarthBender(benderName, benderPower, benderAuxParam);
                break;
            default:
                throw new ArgumentException();
        }
       
    }
   public void AssignMonument(List<string> monumentArgs)
   {
       var monumentType = monumentArgs[0];
       Monument currMonument = this.GetMonument(monumentArgs);
        this.nations[monumentType].AddMonument(currMonument);
   }

    private Monument GetMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];
        var monumentName = monumentArgs[1];
        var monumentAffinity = int.Parse(monumentArgs[2]);
        //var monumentAuxParam = double.Parse(monumentArgs[3]);

        switch (monumentType)
        {
            case "Air":
                return new AirMonument(monumentName, monumentAffinity);
                break;
            case "Water":
                return new WaterMonument(monumentName, monumentAffinity);
                break;
            case "Fire":
                return new FireMonument(monumentName, monumentAffinity);
                break;
            case "Earth":
                return new EarthMonument(monumentName, monumentAffinity);
                break;
            default:
               throw new ArgumentException();
        }

    }

    public string GetStatus(string nationsType)
    {
       StringBuilder message = new StringBuilder();
        message.AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);
        return message.ToString();
    }
   public void IssueWar(string nationsType)
   {
       double victoriousPower = this.nations.Max(kvp => kvp.Value.GetTotalPower());
       foreach (var nation in this.nations.Values)
       {
           if (nation.GetTotalPower() != victoriousPower)
           {
               nation.DeclareDefeat();
           }
       }
       this.warHistoryRecord.Add($"War {this.warHistoryRecord.Count + 1} issued by {nationsType}");

    }


    public string GetWarsRecord() => string.Join(Environment.NewLine, this.warHistoryRecord);


}

