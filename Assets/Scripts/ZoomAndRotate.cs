using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAndRotate : MonoBehaviour
{
    public Transform myObject;

    private bool zoomMode;
    private float startDist, startRot, currentDist, currentRot, theScale, theAngle;
    private Vector2 fingerDir;
    void Start()
    {
        zoomMode = false;
    }

    void Update()
    {
        if (zoomMode)
        {
            //Comprobamos si ya no tenemos dos dedos
            if (Input.touchCount < 2)
            {
                zoomMode = false;
            }
            else
            {
                //Calculamos la nueva escala y rotacion
                currentDist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

                //fingerDir es un vector que va del touch 0 al touch 1
                fingerDir = Input.GetTouch(1).position - Input.GetTouch(0).position;
                currentRot = Vector2.Angle(Vector2.right, fingerDir);

                //Calculamos escala y angulo
                theScale = currentDist / startDist;
                theAngle = currentRot - startRot;

                //Aplicamos la nueva escala y rotacion
                myObject.transform.localScale = new Vector3(theScale, theScale, theScale);
                myObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, theAngle);

            }

        }
        else
        {
            //Comprobamos si entramos en ZoomMode
            if(Input.touchCount >= 2)
            {
                zoomMode = true;

                //Calculamos la escala y rotacion inicial
                startDist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

                //fingerDir es un vector que va del touch 0 al touch 1
                fingerDir = Input.GetTouch(1).position - Input.GetTouch(0).position;
                startRot = Vector2.Angle(Vector2.right, fingerDir);
            }
        }
    }
}
