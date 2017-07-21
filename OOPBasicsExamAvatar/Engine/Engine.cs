using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPBasicsExamAvatar
{
   public class Engine
   {
        private bool isRunning;
       private NationsBuilder nationsBuilder;

       public Engine()
       {
           this.nationsBuilder = new NationsBuilder();
           this.isRunning = true;
       }

        public void Run()
       {

           while (this.isRunning)
           {
               string inputCommand = this.ReadInput();
               List<string> commandPars = this.ParseInput(inputCommand);
               this.DistributeCommand(commandPars);
           }

       }

       private string ReadInput()
       {
           return Console.ReadLine();
       }

       private List<string> ParseInput(string inputCommand)
       {
           
            return inputCommand.Split(' ').ToList();
       }
        //razpredeliam komandite ot tuk
       private void DistributeCommand(List<string> commandPars)
       {
           string command = commandPars[0];
           commandPars.Remove(command);

           switch (command)
           {
                case "Bender":
                    this.nationsBuilder.AssignBender(commandPars);
                   break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(commandPars);
                    break;
                case "Status":
                   string status = this.nationsBuilder.GetStatus(commandPars[0]);
                   this.OutputWriter(status);
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(commandPars[0]);
                    break;
                case "Quit":
                   string record = this.nationsBuilder.GetWarsRecord();
                   this.OutputWriter(record);
                   this.isRunning = false;
                    break;
            }
       }

       private void OutputWriter(string status) => Console.WriteLine(status);
   }
}
