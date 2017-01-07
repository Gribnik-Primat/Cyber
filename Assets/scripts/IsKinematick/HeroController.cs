using UnityEngine;
using System.Collections;

public delegate void ActionDelegate();
public class HeroController : MonoBehaviour {

    public const int OPEN_DOOR = 1;
    public LayerMask mask;
    private IKController ik;
	
	void Start () {
        ik = GetComponent<IKController>();
	}
	void Update () {

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, .45f, mask))
        {
            IKObject ikObject = hit.collider.gameObject.GetComponent<IKObject>();
            if(ikObject != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ik.activate(IKCompleted, ikObject);
                }
            }
        }
	}
    void IKCompleted()
    {
        IKObject obj = ik.ikObject;
        ik.unactivate();

        IAction actionObj = obj as IAction;
        if(actionObj != null)
        {
            actionObj.action();
        }
    }
}
