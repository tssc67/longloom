using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : EnemyController {
    public int hp = 3;
    // Use this for initialization
    void Start () {
        _Start();
    }

    // Update is called once per frame
    void Update () {
        _Update();
	}
    public void bulletHit()
    {
        hp--;
        if(hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D c = collision.collider;
        if (c.CompareTag("Enemies") 
            || c.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.otherCollider, collision.collider);
        }
    }
}
