using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour {

    public GameObject door;
    public bool open = false;
	public bool close = false;

	AudioSource audio;

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
		if (other.GetComponent<CharacterStats>())
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

            door.transform.position = Vector3.Lerp(transform.position, toPosition, 4f * Time.deltaTime);

			if (!audio.isPlaying) 
			{
				audio.Play();
			}
			time = time += Time.deltaTime;
			if (time >= 1.5f)
			{
				open = false;
				time = 0;
			}
		}
		if (close)
        {
            Vector3 toPosition1 = new Vector3(CloseX,CloseY,CloseZ);

            door.transform.position = Vector3.Lerp(transform.position, toPosition1, 4f * Time.deltaTime);
        }
	}
}
