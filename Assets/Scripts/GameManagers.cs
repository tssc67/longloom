using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagers : MonoBehaviour {
    public GameObject alienPrefab;
    public PlayerController character;
    public Tilemap block;
    public RectTransform HPBar;
	// Use this for initialization
	void Start () {
        //Instantiate(alienPrefab, new Vector2(0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        updateUI();
	}

    void updateUI()
    {
        HPBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, character.getHP());
    }
}
