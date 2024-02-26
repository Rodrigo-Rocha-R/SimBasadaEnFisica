using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Integrantes del Equipo:
//   Santiago Moreno Lacalle Quintero, A01663197 
//   Rodrigo Rocha Rosales, A01784108


public class Tablero : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Material material_piso;
    public Material material_tablero;

    GameObject linea;
    GameObject Piso;
    GameObject Figura_juego;

    // Funcion para crear el piso del Gato.
    void CreatePiso()
    {
        //Crear el piso del gato con dimensiones especificas. 

        Piso = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Piso.name = "Base";
        Piso.transform.position = new Vector3(0, 0, 0);
        Piso.transform.localScale = new Vector3(20, 0.1f, 20);

        //Equipar al objeto con MeshRenderer

        MeshRenderer mr = Piso.GetComponent<MeshRenderer>();
        //mr.material.color = new Color32(29, 140, 255,255);

        Renderer ren = mr.gameObject.GetComponent<Renderer>();
        ren.material = material_tablero;

        Rigidbody rb = Piso.gameObject.AddComponent<Rigidbody>();
        rb.mass = 100;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    //Funcion para crear el ladrillo del gato.
    void CreateLinea(Vector3 pos, Vector3 scale, Color color)
    {
        linea = GameObject.CreatePrimitive(PrimitiveType.Cube);
        linea.name = "linea";
        linea.transform.position = pos;
        linea.transform.localScale = scale;

        MeshRenderer lin = linea.GetComponent<MeshRenderer>();
        //lin.material.color = color;

        Rigidbody rigidbody = lin.gameObject.AddComponent<Rigidbody>(); 
        rigidbody.mass = 10;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        //Agregar material
        Renderer ren = lin.gameObject.GetComponent<Renderer>();
        ren.material = material_piso;

    }


    void CrearObjeto(List<List<int>> posicion_gato, int fila, int columna)
    {
         
        if (posicion_gato[fila][columna] == -1 )
        {
            return;
        }
        
        if(posicion_gato[fila][columna] == 0)
        {
            //Cargar la textura del jugador 1.
            Figura_juego = Instantiate(player1);

        }

        if(posicion_gato[fila][columna] == 1)
        {
            //Cargar el prefab de jugador 2.
            Figura_juego = Instantiate(player2);
        }

        //Dar el RigidBody y todo eso aqui 
        Rigidbody rigidbody = Figura_juego.gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = 4;

        // La posicion de donde se va a tirar el objeto

        if (fila == 0)
        {
            if(columna == 0)
            {
                //poner posicion
                Figura_juego.transform.position = new Vector3(-2.4f,5,2.4f);
            }
            
            if(columna == 1)
            {
                Figura_juego.transform.position = new Vector3(0, 5, 2.4f);
            }

            if(columna == 2)
            {
                Figura_juego.transform.position = new Vector3(2.4f, 5, 2.4f);
            }
        }

        if(fila == 1)
        {
            if (columna == 0)
            {
                Figura_juego.transform.position = new Vector3(-2.3f, 5, 0);
            }

            if (columna == 1)
            {
                Figura_juego.transform.position = new Vector3(0, 5, 0);
            }

            if (columna == 2)
            {
                Figura_juego.transform.position = new Vector3(2.3f, 5, 0);
            }
        }

        if(fila == 2)
        {
            if (columna == 0)
            {
                Figura_juego.transform.position = new Vector3(-2.3f, 5, -2);
            }

            if (columna == 1)
            {
                Figura_juego.transform.position = new Vector3(0, 5, -2);
            }

            if (columna == 2)
            {
                Figura_juego.transform.position = new Vector3(2.3f,5,-2);
            }
        }

    }

    void Start()
    {
        
        Logic.MakeLines();

        List<bool> lugares = Logic.lines;
        CreatePiso();

        for (int xy = 0; xy < 13; xy++)
        {
            float dxy = xy - 5 + 0.5f;
            Vector3 scaleH = new Vector3(0.5f, 0.5f, 12);
            Vector3 scaleV = new Vector3(12, 0.5f, 0.5f);

            if (lugares[xy])
            {
                //  línea horizontal
                CreateLinea(new Vector3((dxy), 0.25f, 0), scaleH, Color.black);
            }
            if (lugares[xy])
            {
                //  línea vertical
                CreateLinea(new Vector3(0.25f, 1, (dxy)), scaleV, Color.black);
            }
        }

        Logic.MakeMatriz();
        Logic.MakeGame();

        List<List<int>> posicion = Logic.matriz;

        for (int fila = 0; fila <= 3; fila++)
        {
            for (int columna = 0; columna <= 3; columna++)

            {
                CrearObjeto(posicion, fila, columna);
            }
        }

    }

}

