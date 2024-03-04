using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement findedSupplement = supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
            return findedSupplement;
        }

        public IReadOnlyCollection<ISupplement> Models() => supplements;

        public bool RemoveByName(string typeName)
        {
            ISupplement supplementForRemove = supplements.FirstOrDefault(s => s.GetType().Name == typeName);
            if(supplementForRemove == null)
            {
                return false;
            }
            supplements.Remove(supplementForRemove);
            return true;
        }
    }
}
