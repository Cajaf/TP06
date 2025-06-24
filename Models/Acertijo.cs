using Newtonsoft.Json;

namespace TP05.Controllers;

public class Acertijo
{
[JsonProperty]
public bool salaCompletada;

public string palabra;

public Acertijo ()
{
    salaCompletada = false;
    palabra = "huella";
}
}
