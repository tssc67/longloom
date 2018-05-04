using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletSpeed = 50;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemies"))
        {
            Debug.Log("Alien shot");
            collision.collider.gameObject.GetComponent<AlienController>().bulletHit();
        }
        Destroy(this.gameObject);

    }
}
