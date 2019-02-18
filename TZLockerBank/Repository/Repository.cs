using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TZLockerBank.Models;

namespace TZLockerBank.Repository
{
    public class Repository : IRepository
    {

        private TZLockerBankEntities db = null;

        public Repository()
        {
            this.db = new TZLockerBankEntities();
        }

        public Repository(TZLockerBankEntities db)
        {
            this.db = db;
        }



        public async Task<List<tbl_Location>> BindLocation()

        {
            List<tbl_Location> lstLocation = new List<tbl_Location>();

            try
            {
                lstLocation= await db.tbl_Location.ToListAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstLocation;

        }


        public async Task<List<tbl_LockerBank>> BindLockerBank(int locationId)

        {
            List<tbl_LockerBank> lstLockerBank = new List<tbl_LockerBank>();

            try
            {
            
                lstLockerBank = await db.tbl_LockerBank.Where(a => a.Location_id == locationId).ToListAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstLockerBank;

        }


        public async Task<List<tbl_Locker>> BindLocker(int lockerBankId)

        {
            List<tbl_Locker> lstLocker = new List<tbl_Locker>();

            try
            {

                lstLocker = await db.tbl_Locker.Where(a => a.LockerBank_id == lockerBankId).ToListAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstLocker;

        }

    }
}