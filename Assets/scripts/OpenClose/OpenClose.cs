using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour {

    public GameObject door;
    public bool open = false;

    public float OpenX;
    public float OpenY;
    public float OpenZ;
    public float CloseX;
    public float CloseY;
    public float CloseZ;
    void Start()
    {

    }
    public void Open()
    {
        open = true;
    }
	void Update ()
    {
        if (open)
        {
            Vector3 toPosition = new Vector3(OpenX, OpenY, OpenZ);

            door.transform.position = Vector3.Lerp(transform.position, toPosition, 4f * Time.deltaTime);
        }
        else
        {
            Vector3 toPosition1 = new Vector3(CloseX,CloseY,CloseZ);

            door.transform.position = Vector3.Lerp(transform.position, toPosition1, 4f * Time.deltaTime);
        }
	}
}
