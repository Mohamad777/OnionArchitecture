using OA.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Services
{
    public interface IUserValidatorService
    {
        void CheckPhoneExistance(string phone);
    }
}
