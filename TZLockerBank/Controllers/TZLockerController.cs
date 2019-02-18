using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TZLockerBank.Models;
using TZLockerBank.Repository;

namespace TZLockerBank.Controllers
{
    public class TZLockerController : Controller
    {

        private readonly IRepository _repository;

        //inject dependency 
        public TZLockerController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: TZLocker
        public ActionResult LockerInfo()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> BindLocation()
        {
            List<tbl_Location> lstLocation = new List<tbl_Location>();

            try
            {
                lstLocation = await _repository.BindLocation();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
           

            //return View(model);
            return Json(lstLocation, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> BindLockerBank(int locationId)
        {
            List<tbl_LockerBank> lstLockerBank = new List<tbl_LockerBank>();

            try
            {
                lstLockerBank = await _repository.BindLockerBank(locationId);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


            //return View(model);
            return Json(lstLockerBank, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public async Task<JsonResult> BindLocker(int lockerBankId)
        {
            List<tbl_Locker> lstLocker = new List<tbl_Locker>();

            try
            {
                lstLocker = await _repository.BindLocker(lockerBankId);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


            //return View(model);
            return Json(lstLocker, JsonRequestBehavior.AllowGet);
        }
    }
}