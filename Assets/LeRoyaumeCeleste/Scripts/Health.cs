using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    Sprite fullHeart;
    Sprite emptyHeart;
    async void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) //numOfHearts
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            //Go to scène game over
            SceneManager.LoadScene("GameOver");
        }

        int heartpiece = PlayerPrefs.GetInt("Heartpiece", 0);
        if (heartpiece == 1)
        {
            Debug.Log("UpdateHeart");
            PlayerPrefs.SetInt("Heartpiece", 0);
            PlayerPrefs.Save();
            IncreaseHealth();
        }
    }

    public void DecreaseHealth()
    {
        numOfHearts--;
        health--;
        Debug.LogError("health -1");
    }

    public void IncreaseHealth()
    {
        numOfHearts++;
        health++;
        Debug.LogError("health +1");
    }
}
