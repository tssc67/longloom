using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour{

	public int hp;
	public List<Structure> connectedStructure;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			Destruct ();
		}
	}

	void Damaged(int atkPoint){
		hp -= atkPoint;
	}

	void Destruct(){
		// play animation here
		Destroy(gameObject);
	}

	void Connect(Structure s){
		connectedStructure.Add(s);
	}

	public void ResetConnect(){
		connectedStructure.Clear ();
	}
}