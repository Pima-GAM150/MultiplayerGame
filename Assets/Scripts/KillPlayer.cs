using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KillPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
    	if( !PhotonNetwork.IsMasterClient ) return;

    	if (col.gameObject.tag == "Player" )
    	{
    		print(this.transform.parent.name + " was speared by me.");
    		
    		PhotonNetwork.Destroy( col.transform.parent.gameObject );
    	}
    }
}
