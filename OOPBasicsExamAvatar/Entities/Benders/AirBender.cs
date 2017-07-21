
   public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get { return this.aerialIntegrity; }
        set { this.aerialIntegrity = value; }
    }

    public override double GetPower() => this.AerialIntegrity * this.Power;
    public override string ToString() => $"{base.ToString()}, Aerial Integrity: {this.AerialIntegrity:f2}";
}

