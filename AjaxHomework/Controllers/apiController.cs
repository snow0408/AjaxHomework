using AjaxHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AjaxHomework.Controllers
{
    public class apiController : Controller
    {
        private readonly MyDbContext _dbContext;
		public apiController(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
		public IActionResult CheckAccountAction(string name)
        {
            if (string.IsNullOrEmpty(name)) { return Content("請輸入帳號"); }

            Member? member = _dbContext.Members.FirstOrDefault(p => p.Name == name);
            if (member!=null) { return Content("帳號已存在"); }

            return Content("帳號可使用");
        }
    }
}
