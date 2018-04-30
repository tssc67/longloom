using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : EnemyController {
    public GameManagers manager;

    // Use this for initialization
    void Start () {
        _Start();
    }

    // Update is called once per frame
    void Update () {
        _Update();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemies") 
            && collision.otherCollider.CompareTag("Enemies"))
        {
            Physics2D.IgnoreCollision(collision.otherCollider, collision.collider);
        }
    }
}
