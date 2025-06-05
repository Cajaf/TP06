using Newtonsoft.Json;
public class salaDeEscape
{
[JsonProperty]
public int salaActual {get;private set;}
[JsonProperty]
public bool salaCompletada{get;private set;}

public string[]views{get;private set;}
public void empezarSalaDeEscape()
{
salaActual = 0;
salaCompletada = false;
views = new string[4];
views[0] = "salaSaco";
views[1] = "salaAcertijo";
views[2] = "salaWordle";
views[3] = "salaUltravioleta";

}

public string pasarDeSala()
{
if(salaCompletada)
{
salaActual++;
salaCompletada = false;
}

return views[salaActual];
}

}