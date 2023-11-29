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

    private bool showGameOver = false;
    private float gameOverDuration = 5.0f;
    private string gameOverMessage = "Game Over";

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
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
            // Afficher le message "Game Over" en plein écran
            showGameOver = true;
            StartCoroutine(HideGameOverAfterSeconds(gameOverDuration));


            // Get the name of the currently active scene
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Reload the current scene by loading it again
            SceneManager.LoadScene(currentSceneName);

            // Fermer le jeu
            #if UNITY_EDITOR
            //UnityEditor.EditorApplication.isPlaying = false;
            #else
            //Application.Quit();
            #endif
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

    private IEnumerator HideGameOverAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        showGameOver = false;
    }

    private void OnGUI()
    {
        if (showGameOver)
        {
            // Mesurer la taille du texte
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 40;
            GUIContent content = new GUIContent(gameOverMessage);
            Vector2 textSize = style.CalcSize(content);

            // Calculer les dimensions du rectangle en fonction de la taille du texte
            float padding = 10f; // Marge autour du texte
            float rectWidth = textSize.x + 2 * padding;
            float rectHeight = textSize.y + 2 * padding;
            float rectX = (Screen.width - rectWidth) / 2;
            float rectY = (Screen.height - rectHeight) / 2;

            // Afficher un rectangle de couleur foncée en arrière-plan
            GUIStyle darkRectStyle = new GUIStyle();
            darkRectStyle.normal.background = MakeTexture((int)Screen.width, (int)Screen.height, Color.black);
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", darkRectStyle);

            // Afficher le rectangle avec le message "Game Over"
            GUIStyle redRectStyle = new GUIStyle();
            redRectStyle.normal.background = MakeTexture((int)rectWidth, (int)rectHeight, Color.red);
            GUI.Box(new Rect(rectX, rectY, rectWidth, rectHeight), "", redRectStyle);

            // Afficher le message au milieu du rectangle
            GUI.Label(new Rect(rectX + padding, rectY + padding, textSize.x, textSize.y), gameOverMessage, style);
        }
    }

    private Texture2D MakeTexture(int width, int height, Color color)
    {
        Color[] pixels = new Color[width * height];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }
        Texture2D texture = new Texture2D(width, height);
        texture.SetPixels(pixels);
        texture.Apply();
        return texture;
    }
}
