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
        //hiển thị toàn bộ giá trị của bảng sv  
        //controle: sinh viên

        /// các method= hàm chính là action
        [HttpGet]          
        
        
        public IActionResult Index()
        {
            //var: khi k xác định kiểu dữ liệu/ đối tượng
            var lstSv = _db.SinhViens.ToList();
            return View(lstSv);
        }

        //Thêm
        //chior dùng để tạo và đi tới view create
        //có 2 action verb :
        // httget: kk làm thay đổi cơ sở dữ liệu:: index, delete
        //httpost:  làm thay đổi csdl: create, update
        //nếu k ns gì nó sẽ mặc định là httget
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        //hành động logic
        public IActionResult Create(SinhVien sv)
        {
            _db.SinhViens.Add(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //đi tới giao diện edit có chứa thông tin cần edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //tìm đối tượng caafn sửa
            var svSua = _db.SinhViens.Find(id);
            return View(svSua);


        }
        [HttpPost]
        public IActionResult Edit(SinhVien sv)
        {
            _db.SinhViens.Update(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var svDelete = _db.SinhViens.Find(id); 
            _db.SinhViens.Remove(svDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id) 
        { 
            var svDetails = _db.SinhViens.Find(id);
            return View(svDetails);
        }
    }
}
