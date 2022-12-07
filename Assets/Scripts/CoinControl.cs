using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public string playerName, controlName = "GameControl";
    public float pickDistance = 0.45f;
    public int myPoints = 5;
    public bool finalCoin;

    private GameObject thePlayer, theControl;

    // Start is called before the first frame update
    void Start()
    {
        //Encontramos la bola del jugador por nombre y la asignamos a thePlayer
        thePlayer = GameObject.Find(playerName);
        theControl = GameObject.Find(controlName);
    }

    // Update is called once per frame
    void Update()
    {
        //Cuando estemos a menos distancia que pickDistance del jugador, eliminamos la moneda
        if (Vector3.Distance(transform.position, thePlayer.transform.position) < pickDistance)
        {
            //Hemos tocado la moneda
            //Decirle a GameControl que aumente la puntuación en myPoints
            if (finalCoin) theControl.GetComponent<GameControl>().GameFinish();
            else theControl.GetComponent<GameControl>().IncreaseScore(myPoints);

            Destroy(gameObject);
        }
    }
}
