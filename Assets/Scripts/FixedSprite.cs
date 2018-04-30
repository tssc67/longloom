using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSprite : MonoBehaviour {
    public GameManagers manager;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 _p = transform.position;
        Vector3 cp = manager.character.transform.position;
        transform.position = new Vector3(cp.x, cp.y, _p.z);
    }
}
