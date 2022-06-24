using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost("[action]")]
        //[Route("/Home")]

        public IActionResult turnOff(string button)
        {
            Console.WriteLine("MERDA??");
            Console.WriteLine(button);
            return View();
        }

        public IActionResult CreateVBScript()
        {
            string text = Request.Form["titleInput"];
            string btn = Request.Form["btnInput"];
            string icon = Request.Form["iconInput"];
            string title = Request.Form["descrInput"];

            if (text == null)
                text = "";
            if (btn == null)
                btn = "0";
            if (title == null)
                title = "";
            if (icon == null)
                icon = "0";

            int btnI = int.Parse(btn);
            MessageBoxButtons btnR = (MessageBoxButtons)Enum.ToObject(typeof(MessageBoxButtons), btnI);

            int iconI = int.Parse(icon);
            MessageBoxIcon iconR = (MessageBoxIcon)Enum.ToObject(typeof(MessageBoxIcon), iconI);

            MessageBox.Show(text: title, caption: text, buttons: btnR, icon: iconR,defaultButton: MessageBoxDefaultButton.Button1, options:(MessageBoxOptions)0x40000);

            return RedirectToAction("Successful");
        }
        [HttpPost]
        public IActionResult SendCommand()
        {
            List<(bool active, string result, string inputname)> pariChecked     =  GetInputProperty("pari");
            List<(bool active, string result, string inputname)> parlChecked     =  GetInputProperty("parl");
            List<(bool active, string result, string inputname)> parsChecked     =  GetInputProperty("pars");
            List<(bool active, string result, string inputname)> parsgChecked    =  GetInputProperty("parsg");
            List<(bool active, string result, string inputname)> parrChecked     =  GetInputProperty("parr");
            List<(bool active, string result, string inputname)> pargChecked     =  GetInputProperty("parg");
            List<(bool active, string result, string inputname)> paraChecked     =  GetInputProperty("para");
            List<(bool active, string result, string inputname)> parpChecked     =  GetInputProperty("parp");
            List<(bool active, string result, string inputname)> parhChecked     =  GetInputProperty("parh");
            List<(bool active, string result, string inputname)> hybridChecked   =  GetInputProperty("hybrid");
            List<(bool active, string result, string inputname)> parfwChecked    =  GetInputProperty("parfw");
            List<(bool active, string result, string inputname)> pareChecked     =  GetInputProperty("pare");
            List<(bool active, string result, string inputname)> paroChecked     =  GetInputProperty("paro");
            List<(bool active, string result, string inputname)> parfChecked     =  GetInputProperty("parf");
            List<(bool active, string result, string inputname)> parmChecked     =  GetInputProperty("parm", "parminm");
            List<(bool active, string result, string inputname)> partChecked     =  GetInputProperty("part", "parmint");
            List<(bool active, string result, string inputname)> pardChecked     =  GetInputProperty("pard");
            List<(bool active, string result, string inputname)> parcChecked     =  GetInputProperty("parc", "parminc");
            List<(bool active, string result, string inputname)> parinterrog     =  GetInputProperty("par?");

            StartCommand(pariChecked, parlChecked, parsChecked, parsgChecked, parrChecked,
                pargChecked, paraChecked, parpChecked, parhChecked, hybridChecked, parfwChecked,
                pareChecked, paroChecked, parfChecked, parmChecked, partChecked, pardChecked,
                parcChecked, parinterrog);

            return RedirectToAction("Successful");
        }

        public IActionResult Taskmgr()
        {
            Process[] process = Process.GetProcesses();
            return View();
        }

        public IActionResult KillPrcss(string id)
        {

            int NID = int.Parse(id);
            try
            {
                Process.GetProcessById(NID).Kill();
                return RedirectToAction("Successful");
            }
            catch
            {
                return RedirectToAction("Failure");
            }
        }

        private List<(bool active, string result, string inputname)> GetInputProperty(string param, string inputname = "")
        {
            bool active = false;
            param = Request.Form[param];
            inputname = Request.Form[inputname];
            if (param == null)
            {
                active = false;
                param = "";
                inputname = "";
            }
            else
            {
                active = true;
                if (inputname == null)
                    inputname = "";
            }
            List<(bool active, string result, string inputname)> list = new List<(bool active, string result, string inputname)>();
            list.Add((active,param,inputname));
            return list;
        }

        private void StartCommand(params List<(bool active, string result, string input)>[] values)
        {
            string command = "shutdown";
            for(int i = 0; i < values.Length; i++)
            {
                if (values[i][0].active == true)
                {
                    string result = values[i][0].result;
                    string input = values[i][0].input;
                    if (input.Length > 0)
                        input = $"\"{input}\"";
                    command = command + $" {result} {input}";
                }
            }
            Process.Start("cmd.exe", "/C" + command);
        }


        public IActionResult Privacy() => View();
        public IActionResult Successful() => View();
        public IActionResult Failure() => View();
        public IActionResult VBScriptCreator(IJSRuntime JS)
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}






