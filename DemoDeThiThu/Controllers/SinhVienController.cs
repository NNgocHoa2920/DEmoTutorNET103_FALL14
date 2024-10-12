using DemoDeThiThu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoDeThiThu.Controllers
{
    public class SinhVienController : Controller
    {
        //gọi class đại diện cho sql và tiêm db vào controle
        ThiThu_TutorContext _db;
        public SinhVienController(ThiThu_TutorContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var svList = _db.Sinhviens.ToList();
            //return View(svList);
            var svList = from sv in _db.Sinhviens
                         join lh in _db.Lophocs on sv.MaLop equals lh.MaLop
                         select new Sinhvien
                         {
                             Id = sv.Id,
                             Ten = sv.Ten,
                             Tuoi = sv.Tuoi,
                             Nganh = sv.Nganh,
                             MaLop = lh.MaLop,
                             MaLopNavigation = lh

                         };
            return View(svList.ToList());  

        }
        public IActionResult Create()  // mơ ra form create
        {
            ///khi truyen vao selectList phai dam bao rang dung ten voi thuoc tinh da truyen

            ViewBag.TenLopList = new SelectList(_db.Lophocs,"MaLop","TenLop");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sinhvien sv)  // mơ ra form create
        {
            _db.Sinhviens.Add(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(string mssv)
        {
            var svDetails = _db.Sinhviens.Find(mssv);
            return View(svDetails);

        }

        ///edit <summary>
        /// editchỉ dùng để tajo ra vew edit những có dữ liệu đối tượng cần edit
        /// </summary>
        ///
        [HttpGet]
        public IActionResult Edit(string id)

        {
            ViewBag.TenLopList = new SelectList(_db.Lophocs, "MaLop", "TenLop");
            var svEdit = _db.Sinhviens.Find(id);

            return View(svEdit);
        }
        [HttpPost]
        public IActionResult Edit(Sinhvien sv)
        {
            _db.Sinhviens.Update(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(string id)
        {
            var svDelete = _db.Sinhviens.Find(id); //tìm đối tượng sv muốn xóaa
            _db.Sinhviens.Remove(svDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
