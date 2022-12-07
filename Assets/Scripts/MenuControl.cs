using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public int menu = 0;
    public int level = 1;
    public int ballMenu = 2;

    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }

    public void LoadBallMenu()
    {
        SceneManager.LoadScene(ballMenu);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menu);
    }
}

