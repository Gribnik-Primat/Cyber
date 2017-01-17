using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    public Transform[] toPoints;
    bool d = false;
   

    public Transform getNext()
    {
        return toPoints[Random.Range(0, toPoints.Length)];
    }

}
