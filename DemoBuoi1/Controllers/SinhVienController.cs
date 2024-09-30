using DemoBuoi1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBuoi1.Controllers
{
    public class SinhVienController : Controller
    {
        SinhVienDAL _svDAL;
        //đây là hình thức tiêm DI => hỏi pv
        public SinhVienController(SinhVienDAL svDAL)
        {
            _svDAL = svDAL; 
        }
        //hiển thị ra list
        [HttpGet]
        public IActionResult Index()
        {
            var listSV = _svDAL.GetAllSinhVien();
            return View(listSV);
        }
        //nếu k nói gì thì nó mặc định là httpget: khi k đụng chẠM đến db : index, delete 
        //httpost: dùng khi mà thay đổi csdl : thêm, sửa
        //thêm sinh viên
        [HttpGet]
        public IActionResult Create() // đùng để tạo ra trang view
        {
            return View();
        }

        //dùng để xử lí logic
        [HttpPost]
        public IActionResult Create(SinhVien sv)
        {
            _svDAL.AddSinhVien(sv);
            return RedirectToAction("Index");//chuyển về trang index sau khi add xong
        }

    }
}
