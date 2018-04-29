using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienController : EnemyController {
    private Rigidbody2D rbody;
    private NavMeshAgent agent;
    public GameManagers manager;
    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
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
