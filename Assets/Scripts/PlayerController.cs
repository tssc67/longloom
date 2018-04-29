using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Animator anim;
    public Animation anima;
    public Rigidbody2D rbody;
    public float speed;
    public float jumpPower;
    private float inputH;
    private float inputV;
    private string gadget;
    private bool jump;
    private bool crouch;
    private float JetPackFuel;
    private float hp;
    private int direction;
    private float scale;
    
	// Use this for initialization
	void Start () {
        direction = 1;
        scale = transform.localScale.x;
        jump = false;
        crouch = false;
        JetPackFuel = 0;
        hp = 100;
        gadget = "bareHand";
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Code for move character
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        float moveX = inputH * speed;
        //float moveZ = inputV * jumpPower * Time.deltaTime;
        
        
        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (m.x - rbody.position.x <0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        transform.localScale = new Vector2(direction, transform.localScale.y);

        //chatacter crouch when press key
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("crouch", true);
        }
        else anim.SetBool("crouch", false);
        float moveY = rbody.velocity.y;
        if(Input.GetKey(KeyCode.Space))
        {
            if (!jump)
            {
                jump = true;
                moveY = jumpPower;
            }
        }

        if (jump)
        {
            anim.SetBool("jump", true);
        }
        else anim.SetBool("jump", false);
        rbody.velocity = new Vector3(moveX, moveY);
    }
    public void SelectHandGadget(string gadget)
    {
        this.gadget = gadget;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ground Hit");
        jump = false;
    }
}


