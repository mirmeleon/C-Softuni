﻿
   using System.Reflection.Emit;

public class WaterBender : Bender
   {
       private double waterClarity;

       public WaterBender(string name, int power, double waterClarity) : base(name, power)
       {
           this.waterClarity = waterClarity;
       }
    

       public override double GetPower() => this.waterClarity*this.Power;
     public override string ToString() => $"{base.ToString()}, Water Clarity: {this.waterClarity:f2}";

}

