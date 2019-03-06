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

            sprite.position = Target.position;

            if( rbody.velocity.x < 0f ) {
            	sprite.eulerAngles = new Vector3( 0f, 180f, 0f );
            }
            if( rbody.velocity.x > 0f ) {
            	sprite.eulerAngles = new Vector3( 0f, 0f, 0f );
            }
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
            stream.SendNext(Target.position);
            stream.SendNext( rbody.velocity.x );
        }
        else
        {
            Target.position = (Vector3)stream.ReceiveNext();
            float xVel = (float)stream.ReceiveNext();

            if( xVel < 0f ) {
            	sprite.eulerAngles = new Vector3( 0f, 180f, 0f );
            }
            if( xVel > 0f ) {
            	sprite.eulerAngles = new Vector3( 0f, 0f, 0f );
            }
        }
    }
}
