using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAI : MonoBehaviour {
    public GameObject alienPrefab;
    public GameManagers manager;
    public PathFinder pf;
    void spawnSwarm(Vector2 spawnArea,int spawnRange)
    {
        GameObject alien = Instantiate(alienPrefab, new Vector2(0, 0), Quaternion.identity);
        alien.GetComponent<AlienController>().manager = manager;
        pf.findPathToPlayer(alien.GetComponent<AlienController>(), manager.character);
    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
