using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartGame()
    {

        Application.LoadLevel(1);

    }
   
    public void ExitGame()
    {
        Application.Quit();

    }
}
