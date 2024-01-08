using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] heartImages; // Array für die Herzen 
    public Sprite fullHeart;   // Volles Herz sprite
    public Sprite emptyHeart;  // leeres Herz Sprite

    private int totalHearts = 3;  // gesamtanzahl der Herzen 
    private int currentHealth;   //Aktuelle Anzahl der Leben 

    public GameObject gameoverScreen; // gameoverScreen

    //setzt zu beginn die aktuellen Herzen auf die gesamten und Updatet die Herzen
    private void Start()
    {
        currentHealth = totalHearts;
        UpdateHearts();
        
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            //Wenn der Index kleiner als die aktuelle Lebensanzahl ist setze das Sprite für ein volles Herz
            if (i < currentHealth)
            {
                heartImages[i].sprite = fullHeart;
            }
            // andernfalls setzte das Sprite für ein leeres Herz
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }

    //wenn der Player mit dem tag Enemy collidiert bekommt er schaden bzw. wird Die Methode dafür aktiviert 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDmg();
        }
    }

    //wenn die aktuelle Lebenzanzahlt über null ist nimmt der player schaden und die nerzen werden aktualisiert
    // wenn die Leben kleiner gleich null sind wird die timescale auf 0 gesetzt also praktisch pausiert der gameoverScreen wir aktiviert und die current health wird zur sicherheit auf null gesetzt
    public void TakeDmg()
    {
        if (currentHealth >0)
        {
            currentHealth--;
            UpdateHearts ();
        }
        if (currentHealth <=0)
        {
            Time.timeScale = 0f;
            gameoverScreen.SetActive(true);
            currentHealth = 0;
        }
    }
}
