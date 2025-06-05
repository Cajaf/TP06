using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05.Models;

namespace TP05.Controllers;

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
    public IActionResult empezarSala()
    {
        salaDeEscape juego = new salaDeEscape();
        juego.empezarSalaDeEscape();
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View("salaSaco");
    }
    
    public IActionResult siguienteSala()
    {
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        string salaactual = juego.pasarDeSala();
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View(salaactual);
    }
}
