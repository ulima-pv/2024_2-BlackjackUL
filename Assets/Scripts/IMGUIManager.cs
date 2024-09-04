using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUIManager : MonoBehaviour
{
    private void OnGUI() {
        GUI.Box(new Rect(10, 10, 200, 200), "Menu de Configuracion");

        if (GUI.Button(new Rect(20, 40, 180, 20), "Hola"))
        {
            // Cargar solo 2 cartas
            Debug.Log("Hola");
        }
    }
}
