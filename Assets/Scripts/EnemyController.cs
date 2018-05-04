using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    // Use this for initialization
    public GameManagers manager;
    private float lastLogic;
    protected Rigidbody2D rbody;
    protected Animator anim;
    internal float logicTime = 2;
    public float speed = 3;
    private bool jump = false;
    protected bool followingPlayer = false;
	protected void _Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        lastLogic = Time.time;

	}
	
	// Update is called once per frame
	protected void _Update () {
        Vector3 playerPos = manager.character.transform.position;
        Vector3 myPos = transform.position;
        float distX = myPos.x - playerPos.x;
        float distY = myPos.y - playerPos.y;
        float dist = Vector3.Distance(playerPos, myPos);
        float moveX = rbody.velocity.x, moveY = rbody.velocity.y;
        if (Time.time - lastLogic > logicTime)
        {
            lastLogic = Time.time;
            rethink();
        }
        if (followingPlayer)
        {
            if(distX < 0)
            {
                moveX = speed;
                transform.localScale = new Vector2(1, transform.localScale.y);
            } else
            {
                moveX = -speed;
                transform.localScale = new Vector2(-1, transform.localScale.y);
            }
            if(distY < -0.5)
            {
                if (!jump)
                {
                    jump = true;
                    moveY = 10;
                }
            }
            anim.SetBool("walk", true);
        } else
        {
            anim.SetBool("walk", false);
        }
        rbody.velocity = new Vector3(moveX, moveY);

    }

    protected virtual void rethink()
    {
        Vector3 playerPos = manager.character.transform.position;
        Vector3 myPos = transform.position;
        float distX = myPos.x - playerPos.x;
        float distY = myPos.y - playerPos.y;
        float dist = Vector3.Distance(playerPos, myPos);
        if (dist < 3)
        {
            followingPlayer = true;
        }
        else
        {
            followingPlayer = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector3Int myCell = manager.block.WorldToCell(transform.position);
        Vector3Int theirCell = manager.block.WorldToCell(collision.collider.transform.position);
        if(myCell.y > theirCell.y)
        {
           jump = false;
        }
    }
}
