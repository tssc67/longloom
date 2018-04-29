using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    double lifetime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkLifeTime();
	}

    public Battery(double charge){
        double batteryLife = charge;
    }

    private void checkLifeTime(){
        if (lifetime <= 0) Destroy(gameObject);
    }

    public bool isEmpty()
    {
        return lifetime <= 0;
    }

    public void SetLifeTime(double amount){
        this.lifetime = amount;
    }

    public void Consume(){
        SetLifeTime(lifetime -= 0.1);
    }
}
