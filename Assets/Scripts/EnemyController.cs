using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	// Use this for initialization
    protected Rigidbody2D rbody;
	protected void _Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	protected void _Update () {
		
	}
}
