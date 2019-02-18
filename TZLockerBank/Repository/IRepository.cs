using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZLockerBank.Models;

namespace TZLockerBank.Repository
{
    public interface IRepository 
    {

        Task<List<tbl_Location>> BindLocation(); // R
        Task<List<tbl_LockerBank>> BindLockerBank(int locationId); // R
        Task<List<tbl_Locker>> BindLocker(int lockerBankId);//R


       
    }
}
