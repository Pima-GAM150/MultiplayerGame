using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
	//public Target targetToMove;
	//public Target targetToAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButton (0)){ 
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,100.0f)) {
                
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }
    }
}
