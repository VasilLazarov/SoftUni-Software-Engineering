using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        //Dictionary<int, ISoldier> soldiers;
        private readonly List<ISoldier> soldiers;
        private readonly List<IPrivate> privates;
        ISoldier soldier = null;
        public Engine()
        {
            //soldiers = new Dictionary<int, ISoldier>();
            soldiers = new List<ISoldier>();
            privates = new List<IPrivate>();
        }
        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] strings = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Queue<string> inputElements = new Queue<string>(strings);
                ProcessInput(inputElements, soldier);
            }
            PrintSoldiers(soldiers);
        }

        private void ProcessInput(Queue<string> inputElements, ISoldier soldier)
        {
            string command = inputElements.Dequeue();
            int id = int.Parse(inputElements.Dequeue());
            string firstName = inputElements.Dequeue();
            string lastName = inputElements.Dequeue();
            switch (command)
            {
                case "Private":
                    soldier = GetPrivate(id, firstName, lastName, inputElements);
                    privates.Add((IPrivate)soldier);
                    break;
                case "LieutenantGeneral":
                    soldier = GetLieutenantGeneral(id, firstName, lastName, inputElements);
                    break;
                case "Engineer":
                    soldier = GetEngineer(id, firstName, lastName, inputElements);
                    break;
                case "Commando":
                    soldier = GetCommando(id, firstName, lastName, inputElements);
                    break;
                case "Spy":
                    soldier = GetSpy(id, firstName, lastName, inputElements);
                    break;
            }
            if (soldier != null)
            {
                soldiers.Add(soldier);
            }
        }

        private Private GetPrivate(int id, string firstName, string lastName, Queue<string> inputElements)
        {
            decimal salary = decimal.Parse(inputElements.Dequeue());

            return new Private(id, firstName, lastName, salary);
        }
        private LieutenantGeneral GetLieutenantGeneral(int id, string firstName, string lastName, Queue<string> inputElements)
        {
            decimal salary = decimal.Parse(inputElements.Dequeue());
            List<IPrivate> privatesForAdd = new List<IPrivate>();
            while (inputElements.Count > 0)
            {
                int currentId = int.Parse(inputElements.Dequeue());
                soldier = privates.Find(v => v.Id == currentId);
                privatesForAdd.Add((IPrivate)soldier);
            }

            return new LieutenantGeneral(id, firstName, lastName, salary, privatesForAdd);
        }
        private Engineer GetEngineer(int id, string firstName, string lastName, Queue<string> inputElements)
        {
            decimal salary = decimal.Parse(inputElements.Dequeue());
            string corpString = inputElements.Dequeue();
            Corps corp;
            if(!Enum.TryParse<Corps>(corpString, false, out corp))
            {
                return null;
            }
            List<IRepair> repairs = new List<IRepair>();
            IRepair repair;
            while (inputElements.Count > 0)
            {
                string partName = inputElements.Dequeue();
                int hoursForRepairing = int.Parse(inputElements.Dequeue());
                repair = new Repair(partName, hoursForRepairing);
                repairs.Add(repair);
            }
            return new Engineer(id, firstName, lastName, salary, corp, repairs);
        }
        private Commando GetCommando(int id, string firstName, string lastName, Queue<string> inputElements)
        {
            decimal salary = decimal.Parse(inputElements.Dequeue());
            string corpString = inputElements.Dequeue();
            Corps corp;
            if (!Enum.TryParse<Corps>(corpString, false, out corp))
            {
                return null;
            }
            List<IMission> missions = new List<IMission>();
            MissionState missionState;
            IMission mission;
            while (inputElements.Count > 0)
            {
                string partName = inputElements.Dequeue();
                string missionStateString = inputElements.Dequeue();
                if (!Enum.TryParse<MissionState>(missionStateString, false, out missionState))
                { 
                    continue;
                }
                mission = new Mission(partName, missionState);
                missions.Add(mission);
            }
            return new Commando(id, firstName, lastName, salary, corp, missions);
        }
        private Spy GetSpy(int id, string firstName, string lastName, Queue<string> inputElements)
        {
            int spyCodeNumber = int.Parse(inputElements.Dequeue());
            return new Spy(id, firstName, lastName, spyCodeNumber);
        }


        private void PrintSoldiers(List<ISoldier> soldiers)
        {
            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

    }
}
