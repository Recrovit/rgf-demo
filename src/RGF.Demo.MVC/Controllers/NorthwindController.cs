using Microsoft.AspNetCore.Mvc;
using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Data;
using RGF.Demo.Northwind.Entities;

namespace RGF.Demo.MVC.Controllers
{
    public class NorthwindController : Controller
    {
        public NorthwindController(ILogger<NorthwindController> logger, IRGDataContextFactoryService rgDataContextFactory)
        {
            _logger = logger;
            this.RGDbContext = rgDataContextFactory.CreateRGDataContext().RGDbContext;
        }

        protected readonly ILogger _logger;
        protected IRGDataContext RGDbContext { get; }
        protected string RGFViewPath => Recrovit.RecroGridFramework.Areas.RGF.Controllers.DefaultController.RGFViewPath;

        public async Task<ActionResult> Employee()
        {
            var rgfLogger = new RGFLogger(_logger, "Northwind", "NorthwindController", "Employee", logLevel: LogLevel.Information);
            var rg = await RecroGrid.CreateRGAsync<RG_Employee>(new RecroGridContext(rgfLogger, this.HttpContext, this.RGDbContext));
            return View(RGFViewPath, rg);
        }
        public async Task<ActionResult> Product()
        {
            var rgfLogger = new RGFLogger(_logger, "Northwind", "NorthwindController", "Product", logLevel: LogLevel.Information);
            var rg = await RecroGrid.CreateRGAsync<RG_Product>(new RecroGridContext(rgfLogger, this.HttpContext, this.RGDbContext, version: "1"));
            return View(RGFViewPath, rg);
        }
        public async Task<ActionResult> Order()
        {
            var rgfLogger = new RGFLogger(_logger, "Northwind", "NorthwindController", "Order", logLevel: LogLevel.Information);
            var rg = await RecroGrid.CreateRGAsync<RG_Orders>(new RecroGridContext(rgfLogger, this.HttpContext, this.RGDbContext));
            return View(RGFViewPath, rg);
        }
        public async Task<ActionResult> ProductFEP()
        {
            var rgfLogger = new RGFLogger(_logger, "Northwind", "NorthwindController", "ProductFEP", logLevel: LogLevel.Information);
            var rg = await RecroGrid.CreateRGAsync<RG_Product>(new RecroGridContext(rgfLogger, this.HttpContext, this.RGDbContext, version: "2"));
            return View(RGFViewPath, rg);
        }
        public async Task<ActionResult> ProductFEPB()
        {
            var rgfLogger = new RGFLogger(_logger, "Northwind", "NorthwindController", "ProductFEPB", logLevel: LogLevel.Information);
            var rg = await RecroGrid.CreateRGAsync<RG_Product>(new RecroGridContext(rgfLogger, this.HttpContext, this.RGDbContext, version: "3"));
            return View(RGFViewPath, rg);
        }
    }
}
