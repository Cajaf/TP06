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
        ViewBag.Fondo = "url(../Imagenes/casa.jpg)";
        return View();
    }
    public IActionResult empezarSala()
    {
        salaDeEscape juego = new salaDeEscape();
        juego.empezarSalaDeEscape();
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        ViewBag.Fondo = "url(../Imagenes/captura.png)";

        return View("salaSaco");
    }
    
    public IActionResult siguienteSala()
    {
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        string salaactual = juego.pasarDeSala();
        ViewBag.Fondo = juego.pasarDeSalaFondo();
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View(salaactual);
    }

    public IActionResult siguentePista(string Verif)
    {
        
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.Fondo = juego.pasarDeSalaFondo();
        string salaactual = juego.pasarDeSalaPista(Verif);
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View(salaactual);
    }

        public IActionResult salaCompus()
    {
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.Fondo = "url(../imagenes/pared.jpg)";
        juego.juego3.empezarjuego();
        ViewBag.verdes = juego.juego3.posEncontradas;
        ViewBag.amarillas = juego.juego3.posLetrasE;
        ViewBag.ultimaPalabra = juego.juego3.ultimaPalabra;
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View("salacompu");
    }

    public IActionResult acertijo(string Verif, string palabra)
    {
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.Fondo = juego.pasarDeSalaFondo();
        string salaactual = "salaAcertijo";
        if(palabra != null)
        {
        palabra = palabra.ToLower();
        if(palabra == "huella")
        {
        salaactual = juego.pasarDeSalaPista(Verif);
        }
        }
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View(salaactual);
    }

        public IActionResult ultravioleta(string Verif, string palabra)
    {
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.Fondo = juego.pasarDeSalaFondo();
        string salaactual = "salaUltravioleta";
        if(palabra != null)
        {
        palabra = palabra.ToLower();
        if(palabra == "7410")
        {
        salaactual = juego.pasarDeSalaPista(Verif);
        }
        }
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View(salaactual);
    }
    public IActionResult juegoWordlea(string Verif, string palabra)
    {
        string salasiguente = "salacompu";
        salaDeEscape juego = Objeto.convertirStringAObjeto<salaDeEscape>(HttpContext.Session.GetString("juego"));
        ViewBag.Fondo = "url(../imagenes/pared.jpg)";
        juego.juego3.juego(palabra);
        ViewBag.verdes = juego.juego3.posEncontradas;
        ViewBag.amarillas = juego.juego3.posLetrasE;
        ViewBag.ultimaPalabra = juego.juego3.ultimaPalabra;
       
        if(juego.juego3.salaCompletada)
        {
        salasiguente = "salaPista3";
        }
         HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View(salasiguente);
    }
    
}

