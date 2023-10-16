using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Interfaces.Services
{
    public interface ISecurityService
    {
        public string Hashing(string password);
        public bool PassworEqualityCheck(string currentPassword, string autorisePassword);

    }
}
