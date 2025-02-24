using Microsoft.AspNetCore.Mvc;
namespace MvcMovie.Controllers{
    public class BMIController : Controller
    { 
        // GET: /Person/
        public IActionResult Index()
        {
            return View();
        } 
        // GET: /HelloWorld/Welcome/
        [HttpPost]
        public IActionResult Index(float Chieucao,float Cannang,float DiemA ,float DiemB,float DiemC,float Soluong,float Dongia)
        {
        string strOutput = "Chiều cao :"+ Chieucao + " Cân nặng: "+ Cannang;
        float BMI = Cannang /(Chieucao*Chieucao);
        string strBMI="";
        if(BMI < 18.5){
            strBMI = "BMI là :"+ BMI + " Nhẹ cân ";
        }else if(BMI<=22.9 && BMI >=18.5){
            strBMI = "BMI là :"+ BMI + " Cân nặng bình thường ";
        }else if(BMI >= 23){
            strBMI = "BMI là :"+ BMI + " Thừa cân ";
        }else if(BMI<=29 && BMI >=25){
            strBMI = "BMI là :"+ BMI + " Béo phì độ I ";
        }else if(BMI >= 30){
            strBMI = "BMI là :"+ BMI + " Béo phì độ II ";
        }else if(BMI >= 40){
            strBMI = "BMI là :"+ BMI + " Béo phì độ III ";
        }
        float DiemTB = (float)(DiemC *0.1+DiemB*0.3+DiemA*0.6);
        float Hoadon = Soluong*Dongia;
        string inHoadon = "Hóa đơn là :"+ Hoadon;
        ViewBag.Message1 = strOutput;
        ViewBag.BMI = strBMI;
        ViewBag.DiemTB = DiemTB;
        ViewBag.Hoadon = inHoadon;
        return View();
        }
        public string Welcome()
        {
            return "hello";
        }
    }
}