using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vessels;

        private ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.Any(c => c.FullName == fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            else
            {
                captains.Add(captain);

                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var vessel = vessels.FindByName(name);
            if (vessel != null) 
            {
                Type vesselsType = vessel.GetType();

                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselsType.Name, name);
            }

            if (vesselType == "Battleship")
            {
                IVessel battleship = new Battleship(name, mainWeaponCaliber, speed); 
                vessels.Add(battleship);
                return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                IVessel submarine = new Submarine(name, mainWeaponCaliber, speed);
                vessels.Add(submarine);
                return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);

            }
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captainToAssign = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (captainToAssign == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            var curVessel = vessels.FindByName(selectedVesselName);

            if (curVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);

            }
                             
            if (curVessel.Captain != null) 
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            curVessel.Captain = captainToAssign;
            captainToAssign.AddVessel(curVessel);

            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain curCaptain = captains.First(c => c.FullName == captainFullName);

            return curCaptain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }


            if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();

                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

            }

        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);

        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.FindByName(attackingVesselName);
            var deffendingVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (deffendingVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            }
            if (deffendingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            }

            attackingVessel.Attack(deffendingVessel);

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName
                , attackingVesselName, deffendingVessel.ArmorThickness);

        }

        

           
    }
}
