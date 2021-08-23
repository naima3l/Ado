using System;

namespace Concessionario
{
    //un concessionario vende 3 tipi di veicoli
    //moto : marca, modello, anno di produzione
    //auto : marca, modello, alimentazione (diesel, benzina, elettrica), num porte (3 o 5)
    //pulmini : marca, modello, num posti(....)

    //il programma deve :
    //mostrare a video tutti i veicoli
    //mostrare a video tutte le moto
    //mostrare a video tutte le auto
    //mostrare a video tutti i pulmini
    //inserire un nuovo veicolo (auto, moto o pulmino)

    //se veicolo viene venduto eliminare quel veicolo


    class Program
    {
        static void Main(string[] args)
        {
            Menu.Start();
        }
    }
}
