using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBeacon : MonoBehaviour {
	
	public TeleportBeacon * anotherTeleportBeacon;
	public int cooldownTime; // delay between usage
	public Battery battery;
	public float energyConsumption;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void teleport(){
		if (anotherTeleportBeacon != null) {
			
		}
	}

	void changeBattery(Battery bat){
		battery = bat;
	}

	void onDeath(){
	}
}
