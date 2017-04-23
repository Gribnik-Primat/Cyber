using UnityEngine;
using System.Collections;

public class Door_ : IKObject, IAction {

    private bool isOpen = false;
    private bool isWork = false;
    private Transform door;
    public Door_ twoSide;
    void Start()
    {
        door = transform.parent;
        if (twoSide == null)
            throw new System.Exception();
    }
        public void action()
    {
        if (!isWork)
        {
            if (!isOpen)
            {
                StartCoroutine("openDoor");
            }
            else
            {
                StartCoroutine("closeDoor");
            }
            twoSide.isWork = isWork = true;
        }
    }
	IEnumerator openDoor()
    {
        for(int i=0; i<90; i++)
        {
            door.Rotate(-Vector3.forward);
            yield return null;
        }
        twoSide.isWork = isWork = false;
        twoSide.isWork = isOpen = true;
    }
    IEnumerator closeDoor()
    {
        for (int i = 0; i < 90; i++)
        {
            door.Rotate(Vector3.forward);
            yield return null;
        }
        twoSide.isWork = isWork = false;
        twoSide.isWork = isOpen = false;
    } 
}
