using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public float timing;
    public bool isPaused;
    public GameObject menu;

	void Start ()
    {
	
	}
	
	
	void Update ()
    {
        Time.timeScale = timing;
        if (Input.GetButtonDown("Cancel") && isPaused == false)
        {
            isPaused = true;
        }
        else if (Input.GetButtonDown("Cancel") && isPaused == true )
        {
            isPaused = false;
        }
        if (isPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            timing = 0;
            menu.SetActive(true);
        }
        else if (isPaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            timing = 1;
            menu.SetActive(false);
        }
	}
    public void ResumeButton(bool state)
    {
        isPaused = state;
       
    }
    public void MainMenuButton()
    {
        Application.LoadLevel(0);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

}
