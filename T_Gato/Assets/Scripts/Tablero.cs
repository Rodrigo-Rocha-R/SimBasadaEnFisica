using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    GameObject linea;

    void CreateLinea(Vector3 pos, Vector3 scale, Color color)
    {
        linea = GameObject.CreatePrimitive(PrimitiveType.Cube);
        linea.name = "linea";
        linea.transform.position = pos;
        linea.transform.localScale = scale;
        MeshRenderer lin = linea.GetComponent<MeshRenderer>();
        lin.material.color = color;
        Rigidbody rigidbody = lin.gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = 10;
    }

    void Start()
    {
        logic.MakeLines();

        List<bool> lugares = logic.lines;

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
    }
}
