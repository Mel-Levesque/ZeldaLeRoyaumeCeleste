using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverLevel : MonoBehaviour
{
    private bool showMessage = false;
    private string MessageToShow = "";

    void Start()
    {
        showMessage = false;
    }

    void Update()
    {
        // Ajoutez ici votre logique de mise à jour si nécessaire.
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "LevelExit")
        {
            int asChestplate = PlayerPrefs.GetInt("Chestplate", 0);
            if (SceneManager.GetActiveScene().buildIndex == 0 && asChestplate == 1)
            {
                Debug.Log("Level 1 terminé");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                StartCoroutine(ShowMessageForSeconds("Pour passer au niveau 2, il faut d'abord récupérer le plastron !", 5f));
            }
        }
    }

    private void OnGUI()
    {
        if (showMessage)
        {
            // Mesurer la taille du texte
            string message = MessageToShow;
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 40;
            GUIContent content = new GUIContent(message);
            Vector2 textSize = style.CalcSize(content);

            // Calculer les dimensions du rectangle rouge en fonction de la taille du texte
            float padding = 10f; // Marge autour du texte
            float rectWidth = textSize.x + 2 * padding;
            float rectHeight = textSize.y + 2 * padding;
            float rectX = (Screen.width - rectWidth) / 2;
            float rectY = (Screen.height - rectHeight) / 2;

            // Afficher le rectangle rouge
            GUIStyle redRectStyle = new GUIStyle();
            redRectStyle.normal.background = MakeTexture((int)rectWidth, (int)rectHeight, Color.red);
            GUI.Box(new Rect(rectX, rectY, rectWidth, rectHeight), "", redRectStyle);

            // Afficher le message au milieu du rectangle
            GUI.Label(new Rect(rectX + padding, rectY + padding, textSize.x, textSize.y), message, style);
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

    private IEnumerator ShowMessageForSeconds(string message, float seconds)
    {
        MessageToShow = message;
        showMessage = true;
        yield return new WaitForSeconds(seconds);
        showMessage = false;
    }
}
