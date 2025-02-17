using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class BMIController : Controller
    { 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        } 
        // GET: /HelloWorld/Welcome/ 
       [HttpPost]
        public IActionResult Index(float Chieucao , float Cannang)

        {
                    string strOutput="Chieucao" +Chieucao + "Cannang" + Cannang;
                    float BMI = Cannang /(Chieucao*Chieucao);
                    string strBMI="";
                    if(BMI<18.5){
                        strBMI="BMI la :"+BMI +"Nhẹ cân";
                    }else if(BMI<=22.9 && BMI >=18.5){
                        strBMI="BMI là :"+BMI +"Thừa cân";
                    }else if(BMI<=29 && BMI>=25){
                        strBMI="BMI là :"+BMI +"Béo phì độ I";
                    }
        ViewBag.Message=strOutput;
        ViewBag.BMI=strBMI;
     
            return View();
        } 
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}