
   public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.groundSaturation = groundSaturation;
    }

    //public double GroundSaturation
    //{
    //    get { return this.groundSaturation; }
    //    set { this.GroundSaturation = value; }
    //}

    public override double GetPower() => this.groundSaturation*this.Power;

    public override string ToString() => $"{base.ToString()}, Ground Saturation: {this.groundSaturation:f2}";
}