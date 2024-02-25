using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Integrantes del Equipo:
//   Santiago Moreno Lacalle Quintero, A01663197 
//   Rodrigo Rocha Rosales, A01784108

public class logic 
{
    public static List<bool> lines;
    public static List<List<int>> matriz;
    public static int turno_jugador, random_fila, random_columa;
    public static List<int> fila, columna;


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
        //Genera la matriz para las posiciones del juego.
    public static void MakeMatriz()
    {
        matriz = new List<List<int>>();
        //Generamos los valores de la matriz a un número neutro. 
        
        for (int fila = 0; fila <=3; fila++)
        {
            //Se agrega a la matriz una nueva lista. 
            //Ejemplo: [{Genera este espacio},{Genera este espacio},{Genera este espacio}]
            matriz.Add(new List<int>());
            
            for(int columna = 0; columna <= 3; columna++)
            {
                // Se guarda el valor en la posicion de la fila, permite que esten en columna [{-1,-1,-1}]
                matriz[fila].Add(-1);
            }
        }
        //Generamos valores de fila y columna
        fila = new List<int>();
        columna = new List<int>();
        //Agrega cuantos veces se pueden usar las respectivas filas y columnas
        for(int i = 0; i <= 3; i++)
        {
            fila.Add(3);
            columna.Add(3);
        }
    }

    //Funcion que hace que el juego se juega
    public static void MakeGame()
    {
        //Decide que jugador va a ir primero
        turno_jugador = Random.Range(0, 2);

        //La cantidad de turnos possibles para todo el juego 9 maximos turnos
        for(int turno = 0; turno<= 8; turno++)
        {
            //Comprueba que todos las posiciones de la matriz tengan un valor diferente.
            do
            {
                //Genera numero aleatorio de fila y comprueba que sea valido
                do
                {
                    random_fila = Random.Range(0, 3);
                } while (fila[random_fila] == 0);

                //Genera num aleatorio de columna y comprueba que sea valido
                do
                {
                    random_columa = Random.Range(0, 3);
                } while (columna[random_columa] == 0);
            } while (matriz[random_fila][random_columa] != -1);
            

            
            //Actualiza el valor de la matriz por el jugador (1 o 0)
            matriz[random_fila][random_columa] = turno_jugador;
            //Elimina 1 valor possible de la variable fila y columna
            fila[random_fila]--;
            columna[random_columa]--;
            if (turno >=5)
            {
                //Hacer funcion que verifique quien gana
                //Si gana salir del for
            }
            //Cambia al jugador, 1 y 1
            if(turno_jugador == 1)
            {
                turno_jugador--;
            }
            else
            {
                turno_jugador++;
            }
            
        }
        
        Debug.Log(matriz[0][0]);
        Debug.Log(matriz[0][1]);
        Debug.Log(matriz[0][2]);
        Debug.Log(matriz[1][0]);
        Debug.Log(matriz[1][1]);
        Debug.Log(matriz[1][2]);
        Debug.Log(matriz[2][0]);
        Debug.Log(matriz[2][1]);
        Debug.Log(matriz[2][2]);
        
    }
       
}
