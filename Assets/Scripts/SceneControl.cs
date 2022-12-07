using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameObject[] theSpheres;
    public float sphereDist = 10.0f;
    public Camera theCam;
 

    // Start is called before the first frame update
    void Start()
    {
        //Desactivar todas las esferas
        for (int i = 0; i < theSpheres.Length; i++)
        {
            theSpheres[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Activar tantas esferas como dedos tenemos en pantalla
        for (int i = 0; i < theSpheres.Length; i++)
        {

            if(i < Input.touchCount)
            {
                theSpheres[i].SetActive(true);

                Ray theRay = theCam.ScreenPointToRay(Input.GetTouch(i).position);

                theSpheres[i].transform.position = theRay.origin + theRay.direction * sphereDist;

            }
            else
            {
                theSpheres[i].SetActive(false);

            }
        }
    }
}
