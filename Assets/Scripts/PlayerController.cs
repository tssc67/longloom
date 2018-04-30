using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {
    public GameManagers manager;
    public Animator anim;
    public Animation anima;
    public Rigidbody2D rbody;
    public float speed;
    public float jumpPower;
    private float inputH;
    private float inputV;
    private Gadget gadget;
    private int gadgetIndex;
    private bool jump;
    private bool crouch;
    private float JetPackFuel;
    private float hp;
    private int direction;
    private float scale;
    private List<Gadget> gadgets = new List<Gadget>(new Gadget[] {
        new Hand(),
        new Drill(),
    });
	// Use this for initialization
	protected void Start () {
        gadgetIndex = 0;
        direction = 1;
        scale = transform.localScale.x;
        jump = false;
        crouch = false;
        JetPackFuel = 0;
        hp = 100;
        gadget = gadgets[gadgetIndex];
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	protected void Update () {
        //Code for move character
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("walk", Mathf.Abs(inputH) > 0.01);
        float moveX = inputH * speed;
        //float moveZ = inputV * jumpPower * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switchGadget();
        }

        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        updateMouse(m);
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
            moveX = inputH * speed * 0.2f;
        }
        else anim.SetBool("crouch", false);
        float moveY = rbody.velocity.y;
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
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
            anim.SetBool("walk", false);
        }
        else anim.SetBool("jump", false);
        anim.SetBool("drill", gadget is Drill);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gadget = new PowerPlantHand();
        }

        rbody.velocity = new Vector3(moveX, moveY);
    }
    public float getHP()
    {
        return hp;
    }
    public void switchGadget()
    {
        gadgetIndex++;
        gadgetIndex %= gadgets.Count;
        gadget = gadgets[gadgetIndex];
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemies")
        {
            Debug.Log("Alien Hit");
            hp -= 10;
        }
    }
    private void blankClick()
    {
    }
    private void updateMouse(Vector3 m)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tilemap map = manager.block;
            Vector3Int cellClicked = manager.block.WorldToCell(m);
            Tile a = manager.block.GetTile(cellClicked) as Tile;
            if(a == null)
            {
                //No block
                blankClick();
                Debug.Log("Air clicked");
            } else if(a is BlockTile)
            {
                //Scripted Block
                BlockTile tile = a as BlockTile;
                map.SetTile(cellClicked, null);
                Debug.Log(tile.blockType);
            }
        }
    }
}


