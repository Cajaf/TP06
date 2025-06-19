using Newtonsoft.Json;

namespace TP05.Controllers;
public class salaDeEscape
{
[JsonProperty]
public int salaActual;

[JsonProperty]
public string[] views{get;private set;}
[JsonProperty]
public string[] fondo{get;private set;}
[JsonProperty]
public string[] pista{get;private set;}
[JsonProperty]
public string[] contraseñas{get;private set;}
[JsonProperty]
public juegoSaco juego1{get;private set;}
[JsonProperty]
public Acertijo juego2{get;private set;}
[JsonProperty]
public wordle juego3{get;private set;}
[JsonProperty]
public Ultravioleta juego4{get;private set;}
public void empezarSalaDeEscape()
{  
salaActual = 0;
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

pista = new string[4];
pista[0] = "salaPista";
pista[1] = "salaPista2";
pista[2] = "salaPista3";
pista[3] = "salaPista4";

fondo = new string[4];
fondo[0] = "url(../Imagenes/captura.png)";
fondo[1] = "url(../Imagenes/mesa.jpg)";
fondo[2] = "url(../Imagenes/sala.jpg)";
fondo[3] = "url(../Imagenes/pared.jpg)";
contraseñas = new string[4];
contraseñas[0] = "GUHIgshjgJBHJ";
contraseñas[1] = "hgkjaghjsbhkj";
contraseñas[2] = "auigikjaghjsbhkj";
contraseñas[3] = "LKAhfjagyeuiahb";

}

public string pasarDeSala()
{ 
    if((salaActual == 0 && juego1.salaCompletada)|| (salaActual == 1 && juego2.salaCompletada) || (salaActual == 2 && juego3.salaCompletada) || (salaActual == 3 && juego4.salaCompletada))
    {
    salaActual++;
    }
return views[salaActual];
}
public string pasarDeSalaFondo()
{
return(fondo[salaActual]);
}

public string pasarDeSalaPista(string contraseñaEnviada)
{
string salas = views[salaActual];
if(juego1.salaCompletada == true)
{
    if(juego2.salaCompletada == true)
    {
        if(juego3.salaCompletada == true)
        {
           if(juego4.salaCompletada == true)
           {
                //mandar a una sala de ganar//
           }
           else if(contraseñas[3] == contraseñaEnviada)
           {
                salas = pista[salaActual];
                juego4.salaCompletada = true;
           }
        }
            else if(contraseñas[2] == contraseñaEnviada)
            {
                salas = pista[salaActual];
                juego3.salaCompletada = true;
            }
    }
        else if(contraseñas[1] == contraseñaEnviada)
        {
        salas = pista[salaActual];
        juego2.salaCompletada = true;
        }
}
else if(contraseñas[0] == contraseñaEnviada)
{
salas = pista[salaActual];
juego1.salaCompletada = true;
}
return(salas);
}


}


