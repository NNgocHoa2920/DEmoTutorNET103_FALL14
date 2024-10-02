using Entity_DbFirst_b1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_DbFirst_b1.Controllers
{
    public class SinhVienController : Controller
    {
        ADO_TUTORContext _db;
        ///Tiệm ADO_TUTORContext vào controller=> DI
        public SinhVienController(ADO_TUTORContext db)
        {
            _db = db; 
        }
             
        public IActionResult Index()
        {

            var lstSv = _db.SinhViens.ToList();
            return View(lstSv);
        }
    }
}
