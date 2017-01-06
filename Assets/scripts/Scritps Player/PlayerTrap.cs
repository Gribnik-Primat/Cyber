using UnityEngine;
using System.Collections;

public class PlayerTrap : MonoBehaviour
{
    public GameObject TrapPrefab;
    public float timeInSignalState = 0.5f;

    PlayerInput plInput;
    PlayerMovement plMovement;
    Animator anim;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        plMovement = GetComponent<PlayerMovement>();
        plInput = GetComponent<PlayerInput>();
    }
    
    void Update()
    {
        if (plInput.trapping)
        {
            anim.SetBool("Uses", true);
            plMovement.canMove = false;
            StartCoroutine("CloseTrapping");
        }
    }

    IEnumerator CloseTrapping()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("Uses", false);

        Vector3 pos = plMovement.transform.position;
        pos += plMovement.transform.TransformDirection(new Vector3(0, 0, 0.5f));
        GameObject trapObj = Instantiate(TrapPrefab, pos, Quaternion.identity);
        Trap trap = trapObj.GetComponent<Trap>();
        trap.triggeredByEnemy = true;
        trap.damageEnemy = true;
        trap.damage = 100.0f;
        trap.timeInSignalState = timeInSignalState;
    }
}




