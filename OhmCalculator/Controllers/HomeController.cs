using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhmCalculator.Models;

namespace OhmCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index(string bandA = "None", string bandB = "None", string bandC = "None", string bandD = "None")
        {
            var calculator = new OhmValueCalculator();

            var viewModel = new HomeViewModel()
            {
                BandA = bandA,
                BandB = bandB,
                BandC = bandC,
                BandD = bandD,
                BandAList = calculator.Bands.Where(band => band.SignificantFigure.HasValue).Select(band => new SelectListItem() { Text = band.ColorName, Value = band.ColorName }),
                BandBList = calculator.Bands.Where(band => band.SignificantFigure.HasValue).Select(band => new SelectListItem() { Text = band.ColorName, Value = band.ColorName }),
                BandCList = calculator.Bands.Where(band => band.Multiplier.HasValue).Select(band => new SelectListItem() { Text = band.ColorName, Value = band.ColorName }),
                BandDList = calculator.Bands.Where(band => band.Tolerance.HasValue).Select(band => new SelectListItem() { Text = band.ColorName, Value = band.ColorName }),
                OhmValue = calculator.CalculateOhmValue(bandA, bandB, bandC, bandD),
                Tolerance = calculator.Bands.FirstOrDefault(band => band.ColorName == bandD).Tolerance
            };

            return View(viewModel);
        }
    }

    public class HomeViewModel
    {
        public string BandA { get; set; }
        public string BandB { get; set; }
        public string BandC { get; set; }
        public string BandD { get; set; }
        public IEnumerable<SelectListItem> BandAList { get; set; }
        public IEnumerable<SelectListItem> BandBList { get; set; }
        public IEnumerable<SelectListItem> BandCList { get; set; }
        public IEnumerable<SelectListItem> BandDList { get; set; }
        public int OhmValue { get; set; }
        public double? Tolerance { get; set; }
    }
}