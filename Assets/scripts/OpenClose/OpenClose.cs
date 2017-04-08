using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour {

    public GameObject door;
    private bool open = false;
    private bool close = false;
    private bool opening = false;


	AudioSource audio;

    private float timeO = 0;
    private float timeC = 0;
    private float time = 0;

    public float OpenX;
    public float OpenY;
    public float OpenZ;
    public float CloseX;
    public float CloseY;
    public float CloseZ;
    void Start()
    {
		audio = GetComponent<AudioSource>();
		audio.playOnAwake = false;
		audio.loop = false;
    }
    void OnTriggerStay(Collider other)
    {
		if (other.GetComponent<CharacterStatsPlayer>() || other.GetComponent<CharacterStatsEnemy>())
        {       
            open = true;

        }
    }
    //public void Open()
    //{
    //    open = true;
    //}
	void Update ()
    {
       
        if (open)
        {
            Vector3 toPosition = new Vector3(OpenX, OpenY, OpenZ);

            door.transform.localPosition = Vector3.Lerp(transform.localPosition, toPosition, 4f * Time.deltaTime);

			if (!audio.isPlaying) 
			{
				audio.Play();
			}
            timeO = timeO += Time.deltaTime;
            if (timeO >= 1.5f)
			{
				open = false;
                timeO = 0;

            }
            opening = true;
        }
       
		if (close)
        {
            Vector3 toPosition1 = new Vector3(CloseX,CloseY,CloseZ);

            door.transform.localPosition = Vector3.Lerp(transform.localPosition, toPosition1, 4f * Time.deltaTime);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            timeC = timeC += Time.deltaTime;
            if (timeC >= 1.5f)
            {
                close = false;
                timeC = 0;
            }
            opening = false;
        }
        if(opening)
        {
            time = time +=Time.deltaTime;   
        }
        if (time >= 3f)
        {
            close = true;
            time = 0;
        }
	}
}
