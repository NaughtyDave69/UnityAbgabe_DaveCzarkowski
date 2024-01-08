using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //L‰dt das game
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    //Schlieﬂt das programm 
    public void Exit()
    {
        Application.Quit();
    }

    //l‰dt das Hauptmenu
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //startet das spiel neu bzw. l‰dt es die Scene und setzt die Timescale wieder auf 1 also ist es nicht mehr pausiert  
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }
}
