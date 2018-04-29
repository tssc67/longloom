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
        float moveX = inputH * speed * Time.deltaTime;
        float moveZ = inputV * jumpPower * Time.deltaTime;
        rbody.MovePosition(rbody.position + new Vector2(moveX, 0));
        if (inputH<0)
        {
            direction = -1;
            transform.localScale = new Vector2(direction, transform.localScale.y);
        }
        else if (inputH>0)
        {
            direction = 1;
            transform.localScale = new Vector2(direction, transform.localScale.y);
        }

        //chatacter crouch when press key
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("crouch", true);
        }
        else anim.SetBool("crouch", false);


        //character hum when press space bar
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);

        }
        else anim.SetBool("jump", false);

        
	}
    public void SelectHandGadget(string gadget)
    {
        this.gadget = gadget;
    }
}
