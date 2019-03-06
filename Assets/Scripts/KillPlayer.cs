using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
    	if (col.transform.tag == "Player" )
    	{
    		print("I speared the player.");
    		Destroy();
    	}
    }
    public void Destroy()
    {
    	Destroy(this);
    }
}
