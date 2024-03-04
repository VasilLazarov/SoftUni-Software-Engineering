using RobotService.Repositories.Contracts;
using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models() 
            => supplements;
        
        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement model = supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
            if (model == null)
            {
                return null;
            }
            return model;
        }


        public bool RemoveByName(string typeName)
        {
            ISupplement model = supplements.FirstOrDefault(s => s.GetType().Name == typeName);
            if(model == null)
            {
                return false;
            }
            supplements.Remove(model);
            return true;
        }
    }
}
