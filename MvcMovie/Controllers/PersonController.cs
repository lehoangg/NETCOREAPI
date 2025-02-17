using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        // Hiển thị form nhập dữ liệu
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ form gửi lên
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu (ví dụ: lưu vào database)
                return RedirectToAction("Details", new { id = person.PersonId });
            }
            return View(person);
        }

        // Hiển thị dữ liệu của một Person
        public IActionResult Details(string id)
        {
            var person = new Person
            {
                PersonId = id,
                FullName = "Le Vu Huy Hoang",
                Address = "Hà Nội"
            };
            return View(person);
        }
    }
}