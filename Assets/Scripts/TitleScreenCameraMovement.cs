using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCameraMovement : MonoBehaviour
{
	public float speed;

	public Rigidbody2D cam;
	

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       cam.velocity = transform.right * speed;
       if (cam.transform.position.x >= 47.36f)
		{
			cam.transform.position = new Vector3(0.32f, 1f, -10f);
		}

   	}
}
