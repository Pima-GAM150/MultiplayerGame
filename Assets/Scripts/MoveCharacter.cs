using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
	public float speed;
    public Rigidbody2D rbody;
    private float xInput;
    private float yInput;
    void Start()
    {
        
    }

   
    void Update () {
        
        xInput = Input.GetAxis( "Horizontal" );
        yInput = Input.GetAxis("Vertical");
        if (xInput < -0.1)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (xInput > 0.1) transform.localScale = new Vector2(1f, 1f);;
    }

    void FixedUpdate() {
        rbody.velocity = new Vector2( xInput * speed, yInput * speed );

    }
}
