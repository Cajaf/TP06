using Newtonsoft.Json;
public class salaDeEscape
{
[JsonProperty]
public int salaActual;

[JsonProperty]
public string[] views{get;private set;}

juegoSaco juego1;
Acertijo juego2;
wordle juego3;
Ultravioleta juego4;
public void empezarSalaDeEscape()
{  
juego1 = new juegoSaco();
juego2 = new Acertijo();
juego3 = new wordle();
juego4 = new Ultravioleta();

juego1.salaCompletada = false;
juego2.salaCompletada = false;
juego3.salaCompletada = false;
juego4.salaCompletada = false;

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