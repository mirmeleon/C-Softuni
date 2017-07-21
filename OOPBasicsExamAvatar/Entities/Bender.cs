public abstract class Bender : Nation //za tva ne sum sigurna dali da nasleidava
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    
    public abstract double GetPower(); //tva go niama po uslovie

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public override string ToString()
    {
        string benderType = this.GetType().Name; //AirBender
        int typeEnd = benderType.IndexOf("Bender");//3
        benderType = benderType.Insert(typeEnd, " ");//Air Bender stava
        return $"{benderType}: {this.name}, Power: {this.Power}";

    }

}

