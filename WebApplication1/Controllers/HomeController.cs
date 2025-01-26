using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Views.Home;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) => _logger = logger;

		public IActionResult Index() => View();

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

			if(text == null)
				text = "";
			if(btn == null)
				btn = "0";
			if(title == null)
				title = "";
			if(icon == null)
				icon = "0";

			var btnI = int.Parse(btn);
			var btnR = (MessageBoxButtons)Enum.ToObject(typeof(MessageBoxButtons), btnI);

			var iconI = int.Parse(icon);
			var iconR = (MessageBoxIcon)Enum.ToObject(typeof(MessageBoxIcon), iconI);

			_ = MessageBox.Show(text: title, caption: text, buttons: btnR, icon: iconR, defaultButton: MessageBoxDefaultButton.Button1, options: (MessageBoxOptions)0x40000);

			return RedirectToAction("Successful");
		}
		[HttpPost]
		public IActionResult SendCommand()
		{
			var pariChecked     =  GetInputProperty("pari");
			var parlChecked     =  GetInputProperty("parl");
			var parsChecked     =  GetInputProperty("pars");
			var parsgChecked    =  GetInputProperty("parsg");
			var parrChecked     =  GetInputProperty("parr");
			var pargChecked     =  GetInputProperty("parg");
			var paraChecked     =  GetInputProperty("para");
			var parpChecked     =  GetInputProperty("parp");
			var parhChecked     =  GetInputProperty("parh");
			var hybridChecked   =  GetInputProperty("hybrid");
			var parfwChecked    =  GetInputProperty("parfw");
			var pareChecked     =  GetInputProperty("pare");
			var paroChecked     =  GetInputProperty("paro");
			var parfChecked     =  GetInputProperty("parf");
			var parmChecked     =  GetInputProperty("parm", "parminm");
			var partChecked     =  GetInputProperty("part", "parmint");
			var pardChecked     =  GetInputProperty("pard");
			var parcChecked     =  GetInputProperty("parc", "parminc");
			var parinterrog     =  GetInputProperty("par?");

			StartCommand(pariChecked, parlChecked, parsChecked, parsgChecked, parrChecked,
				pargChecked, paraChecked, parpChecked, parhChecked, hybridChecked, parfwChecked,
				pareChecked, paroChecked, parfChecked, parmChecked, partChecked, pardChecked,
				parcChecked, parinterrog);

			return RedirectToAction("Successful");
		}

		public IActionResult Taskmgr()
		{
			_ = Process.GetProcesses();
			return View();
		}

		public IActionResult KillPrcss(string id)
		{

			var NID = int.Parse(id);
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
		public static Random randomJump = new Random(); // Instância estática
		public IActionResult ShowJumpscare()
		{
			try
			{
				var Inttime = int.Parse(Request.Form["time"]);
				var jumppaths = new string[]
				{
					"wwwroot/res/bkacman.jpeg",
					"wwwroot/res/jeff-the-killer-vancethot.gif",
					"wwwroot/res/henry.jpeg"
				};
				var choose = jumppaths[randomJump.Next(0, jumppaths.Length)];
				test t = new();
				t.BackgroundImage = Image.FromFile(choose);
				t.Show();
				Thread.Sleep(Inttime);
				t.Close();
				return RedirectToAction("Successful");
			}
			catch
			{
				return RedirectToAction("Failure");
			}
		}


		private List<(bool active, string result, string inputname)> GetInputProperty(string param, string inputname = "")
		{
			param = Request.Form[param];
			inputname = Request.Form[inputname];
			bool active;
			if(param == null)
			{
				active = false;
				param = "";
				inputname = "";
			}
			else
			{
				active = true;
				if(inputname == null)
					inputname = "";
			}
			var list = new List<(bool active, string result, string inputname)>();
			list.Add((active, param, inputname));
			return list;
		}

		private void StartCommand(params List<(bool active, string result, string input)>[] values)
		{
			var command = "shutdown";
			for(var i = 0; i < values.Length; i++)
			{
				if(values[i][0].active == true)
				{
					var result = values[i][0].result;
					var input = values[i][0].input;
					if(input.Length > 0)
						input = $"\"{input}\"";
					command = command + $" {result} {input}";
				}
			}
			_ = Process.Start("cmd.exe", "/C" + command);
		}

		public IActionResult jumpscare() => View();
		public IActionResult Privacy() => View();
		public IActionResult Successful() => View();
		public IActionResult Failure() => View();
		public IActionResult VBScriptCreator() => View();
		public IActionResult Parsec()
		{
			try
			{
				var processes = Process.GetProcessesByName("Parsec");

				if(processes.Length > 0)
				{
					foreach(var process in processes)
					{
						process.Kill();
						process.WaitForExit();
					}
					return RedirectToAction("Successful");
				}
				else
				{
					processes = Process.GetProcessesByName("parsecd");
					if(processes.Length > 0)
					{
						foreach(var process in processes)
						{
							process.Kill();
							process.WaitForExit();
						}
						return RedirectToAction("Successful");
					}
					else
					{
						_ = Response.WriteAsync("<script>alert('Nenhum processo com o nome Parsec Encontrado.'); window.history.go(-1);</script>");
						return RedirectToAction("Home");
					}
				}
			}
			catch(Exception ex)
			{
				_ = Response.WriteAsync($"<script>alert('{ex.Message}'); window.history.go(-1);</script>");
				return RedirectToAction("Failure");
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}






