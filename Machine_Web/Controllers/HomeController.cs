using AutoMapper;
using Machine_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Machine_Web.Controllers
{
    public class HomeController : Controller
    {


        private async static Task<MyViewModel> GetMyViewModel()
        {
            var client = new HttpClient();
            List<Machines>? datas = null;
            List<PLCQualityCriterionDatas>? datas2 = null;
            HttpResponseMessage response = await client.GetAsync("http://localhost:8088/api/MachineManager");
            HttpResponseMessage response2 = await client.GetAsync("http://localhost:8088/api/DatasManager");
            if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
            {
                var r1 = await response.Content.ReadAsStringAsync();
                var r2 = await response2.Content.ReadAsStringAsync();
                datas = JsonConvert.DeserializeObject<List<Machines>>(r1);
                datas2 = JsonConvert.DeserializeObject<List<PLCQualityCriterionDatas>>(r2);
            }
            var PLCQualityCriterionDatas = datas2;
            var machines = datas;

            var viewModel = new MyViewModel()
            {
                PLCQualityCriterionDatasList = datas2,
                MachinesList = datas
            };

            return viewModel;
        }



        public async Task<IActionResult> Index()
        {
            MyViewModel myViewModel = await GetMyViewModel();
            ViewBag.MyViewModel = myViewModel;
            return View(myViewModel);
        }

       
        
        public async Task<IActionResult> Details(int id)
        {
            MyViewModel myViewModel= await GetMyViewModel();
            ViewBag.MyViewModel = myViewModel.MachinesList.Where(i=>i.ConnectionID==id).ToList();
            return View(myViewModel);

        }
       
    

          
        
        public async Task<IActionResult> MachineCard()
        {
            MyViewModel myViewModel = await GetMyViewModel();

            return View(myViewModel);

        }


      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}