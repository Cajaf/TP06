using Newtonsoft.Json;
namespace TP05.Controllers;
public class wordle
{
[JsonProperty]
public bool salaCompletada;
[JsonProperty]
public string palabra{get;private set;}
[JsonProperty]
public bool[]posEncontradas{get;private set;}
[JsonProperty]
public bool[]posLetrasE{get;private set;}
[JsonProperty]
public string ultimaPalabra{get;private set;}

    public void empezarjuego()
    {
        palabra = "sangre";
        posEncontradas = new bool[palabra.Length];
        posLetrasE = new bool[palabra.Length];
        for(int i = 0;i < posEncontradas.Length;i ++)
        {
            posEncontradas[i] = false;
        }
        for(int i = 0;i < posLetrasE.Length;i ++)
        {
            posLetrasE[i] = false;
        }
    }


    public string juego(string palabraEnviada)
    {
        
        for(int i = 0;i < posEncontradas.Length;i ++)
        {
            posEncontradas[i] = false;
        }
        for(int i = 0;i < posLetrasE.Length;i ++)
        {
            posLetrasE[i] = false;
        }
        if(palabraEnviada != null)
        {
        if(palabraEnviada.Length == palabra.Length)
        {
            palabraEnviada = palabraEnviada.ToLower();
            ultimaPalabra = palabraEnviada;
            for(int i = 0; i < palabra.Length;i++)
            {
                if(palabra[i] == palabraEnviada[i])
                {
                    posEncontradas[i] = true;
                }
                else
                {
                for(int y = 0; y < palabra.Length;y++)
                {
                    if(palabra[i] == palabraEnviada[y])
                    {
                        posLetrasE[y] = true;
                    }
                }
                }
            }
            salaCompletada = true;
             for(int i = 0; i < posEncontradas.Length;i++)
             {
                if(posEncontradas[i] == false)
                {
                    salaCompletada = false;
                }
             }
        }
        else
        {
            palabraEnviada = "error";
            for(int i = 0;i < posEncontradas.Length;i ++)
            {
                posEncontradas[i] = false;
            }
        }
        }
        return palabraEnviada;
    }
    
}

