using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour{

	public int hp;
    public int width;
    public int height;
    // I will assume that, the reference point of structure that has 2*2 size is at bottom left
    // and this is based on x=0 at leftmost, y=0 at bottommost
    // the reference will affect the code at wireController on checking whether is that structure connected to the wire or not
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

	public void Connect(Structure s){
		connectedStructure.Add(s);
	}

	public void ResetConnect(){
		connectedStructure.Clear ();
	}
}