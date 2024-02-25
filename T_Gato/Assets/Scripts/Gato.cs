using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Integrantes del Equipo:
//   Santiago Moreno Lacalle Quintero, A01663197 
//   Rodrigo Rocha Rosales, A01784108

public class logic 
{
    public static List<bool> lines;

    public static void MakeLines()
    {
        lines = new List<bool>();

        // Inicializamos todas las posiciones a false
        //Se debe de crear vacio para poder elegir en que posiciones deseamos que aparezcan las lineas
        for (int i = 0; i <= 12; i++)
        {
            lines.Add(false);
        }
        // Establecemos las posiciones que deben ser true
        lines[0] = true;
        lines[3] = true;
        lines[6] = true;
        lines[9]= true;
    }
}
