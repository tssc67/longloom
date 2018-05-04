using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {
    public GameManagers manager;
    public Animator anim;
    public Animation anima;
    public Rigidbody2D rbody;
    public GameObject powerPlantPlacement;
    public GameObject smelterPlacement;
    public GameObject currentPlacement;
    public GameObject bullet;
    public GameObject InventoryPrefab;
    public float speed;
    public float jumpPower;
    public Inventory inventory;
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
    private Vector3Int playerCell;
    private List<Gadget> gadgets = new List<Gadget>(new Gadget[] {
        new Drill(),
    });
    private enum Test
    {
        a,b
    }
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
        inventory = (
            (GameObject)Instantiate(InventoryPrefab)
        ).GetComponent<Inventory>();
        powerPlantPlacement = Instantiate(powerPlantPlacement);
        powerPlantPlacement.SetActive(false);
        smelterPlacement = Instantiate(smelterPlacement);
        smelterPlacement.SetActive(false);
    }
	
	// Update is called once per frame
	protected void Update () {
        //powerPlantPlacement.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 0, 0.5f);
        //smelterPlacement.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 0, 0.5f);
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
            currentPlacement = powerPlantPlacement;
            
            //Destroy(powerPlantPlacement.GetComponent<Rigidbody2D>());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gadget = new SmelterHand();
            currentPlacement = smelterPlacement;
            //Destroy(powerPlantPlacement.GetComponent<Rigidbody2D>();
        }

        rbody.velocity = new Vector3(moveX, moveY);
        if (gadget is PowerPlantHand)
        {
            powerPlantPlacement.SetActive(true);
        }
        else powerPlantPlacement.SetActive(false);
        if (gadget is SmelterHand)
        {
            smelterPlacement.SetActive(true);
        }
        else smelterPlacement.SetActive(false);
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
            Debug.Log("Alien Hit");
            hp -= 10;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 bottom = GetComponent<SpriteRenderer>().bounds.min;
        Vector3 p = manager.block.WorldToCell(collision.contacts[0].point);

        if(Mathf.Abs(p.y - bottom.y) <  0.02)
        {
            jump = false;
        }
    }
    
    private void shoot(Vector3 m)
    {
        Debug.Log("Shoot!");
        Bullet b = Instantiate(bullet).GetComponent<Bullet>();
        Vector3 bPos = transform.position;
        Vector3 v = new Vector3();
        float dx, dy;
        float sin, cos,hyp;
        dx = m.x - transform.position.x;
        dy = m.y - transform.position.y;
        hyp = Mathf.Sqrt(dx * dx + dy * dy);
        sin = dy / hyp;
        cos = dx / hyp;
        v.x = cos * b.bulletSpeed;
        v.y = sin * b.bulletSpeed;
        if(direction == -1)
        {
            bPos.x = GetComponent<SpriteRenderer>().bounds.min.x;
        } else
        {
            bPos.x = GetComponent<SpriteRenderer>().bounds.max.x;

        }
        b.transform.position = bPos;
        b.GetComponent<Rigidbody2D>().velocity = v;
    }
    private void blankClick(Vector3Int over,Vector3 m)
    {
        if(gadget is StructurePlacementHand)
        {
            Structure structure = currentPlacement.GetComponent<Structure>();
            structure.manager = manager;
            structure.Construct(over);
        } else if (gadget is Drill)
        {
            shoot(m);
        }
    }
    private void placementMove(Vector3Int over)
    {
        Tile tile = manager.block.GetTile(over) as Tile;
        Vector3 worldPos = manager.block.CellToWorld(over);
        if(currentPlacement)
        {
            currentPlacement.transform.position = new Vector3(worldPos.x + 0.5f, worldPos.y, worldPos.z);
        }
    }
    private void updateMouse(Vector3 m)
    {
        Vector3Int cellOver= manager.block.WorldToCell(m);
        if (Input.GetMouseButtonDown(0))
        {
            Tilemap map = manager.block;
            Tile a = manager.block.GetTile(cellOver) as Tile;
            if(a == null)
            {
                //No block
                blankClick(cellOver,m);
                
            } else if(a is BlockTile)
            {
                //Scripted Block
                BlockTile tile = a as BlockTile;
                if (tile.blockType == BlockTile.BlockType.Dirt 
                 || tile.blockType == BlockTile.BlockType.IronOre
                 || tile.blockType == BlockTile.BlockType.Oil)
                {
                    if(gadget is Drill)
                    {
                        tile.dig(this);
                        map.SetTile(cellOver, null);
                    }
                }
                Debug.Log(tile.blockType);
            }
        } else
        {
            placementMove(cellOver);
        }
    }
}


