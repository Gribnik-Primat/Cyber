using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public float timing;
    public bool isPaused;
    public GameObject menu;
    public GameObject task;
	public GameObject map;
	public bool flag_map;
    bool onOff;
	void Start ()
    {
        onOff = false;
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
            task.SetActive(true);
			if (flag_map == true) {
				map.SetActive (true);
				flag_map = false;
			}
        }
        else if (isPaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            timing = 1;
            menu.SetActive(false);   
            task.SetActive(false);
           
                map.SetActive(false);
                flag_map = false;
            
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
	public void OpenMap()
	{			
		flag_map = true;
	}
    public void QuitButton()
    {
        Application.Quit();
    }
}
