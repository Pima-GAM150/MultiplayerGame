using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoveCharacter : MonoBehaviourPun, IPunObservable
{
	public float speed;
    public Rigidbody2D rbody;
    private float xInput;
    private float yInput;
    public Transform Target;
    public Transform sprite;
    public Vector3 LastSyncedPos;
    void Start()
    {
        
    }

   
    void Update () {
        if(photonView.IsMine)
        {

        
            xInput = Input.GetAxis( "Horizontal" );
            yInput = Input.GetAxis("Vertical");
            if (xInput < -0.1)
            {
              transform.localScale = new Vector2(-1f, 1f);
            }
            else if (xInput > 0.1) transform.localScale = new Vector2(1f, 1f);;
        }
        else
        {
            sprite.position = Vector3.Lerp(sprite.position, Target.position, speed * Time.deltaTime);
            sprite.localScale = Vector3.Lerp(sprite.localScale, Target.localScale, speed * Time.deltaTime);
        }
    }

    void FixedUpdate() {
        rbody.velocity = new Vector2( xInput * speed, yInput * speed );

    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            LastSyncedPos = Target.position;

            stream.SendNext(Target.position);
        }
        else
        {
            Target.position = (Vector3)stream.ReceiveNext();
        }
    }
}
