using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    private bool showMessage = false;
    private string MessageToShow = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            PlayerPrefs.SetInt("Chestplate", 0);
            PlayerPrefs.SetInt("Helmet", 0);
            PlayerPrefs.SetInt("Gaz", 0);
            PlayerPrefs.SetInt("Pants", 0);
            PlayerPrefs.SetInt("Rupees", 0);
            PlayerPrefs.Save();
            StartCoroutine(ShowMessageForSeconds("Pour passer au niveau suivant dirige toi vers le bloc rouge,\r\n quand tu auras récupéré ton équipement !", 5f));
        }
    }

    private void OnGUI()
    {
        if (showMessage)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 40;
            style.normal.textColor = Color.white; // Couleur du texte en blanc

            // Mesurer la taille du texte
            GUIContent content = new GUIContent(MessageToShow);
            Vector2 textSize = style.CalcSize(content);

            // Ajouter de la marge autour du texte
            float padding = 10f;

            // Utiliser la largeur et la hauteur du texte pour définir la taille du rectangle noir
            float rectWidth = textSize.x + 2 * padding;
            float rectHeight = textSize.y + 2 * padding;

            // Calculer la position du rectangle au centre de l'écran
            float rectX = (Screen.width - rectWidth) / 2;
            float rectY = (Screen.height - rectHeight) / 2;

            // Afficher le rectangle noir
            GUIStyle blackRectStyle = new GUIStyle();
            blackRectStyle.normal.background = MakeTexture((int)rectWidth, (int)rectHeight, Color.black);
            GUI.Box(new Rect(rectX, rectY, rectWidth, rectHeight), "", blackRectStyle);

            // Afficher le message au milieu du rectangle
            GUI.Label(new Rect(rectX + padding, rectY + padding, textSize.x, textSize.y), MessageToShow, style);
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
