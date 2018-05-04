using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagers : MonoBehaviour {
    public GameObject alienPrefab;
    public PlayerController character;
    public Tilemap block;
    public RectTransform HPBar;
    public GameObject UI;
	// Use this for initialization
	void Start () {
        //Instantiate(alienPrefab, new Vector2(0, 0), Quaternion.identity);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<AlienController>().manager = this;
        }
        Debug.Log(Physics2D.gravity);
        Physics2D.gravity = new Vector2(0.0f,-25.0f);
        
    }
	
	// Update is called once per frame
	void Update () {
        updateUI();
	}

    void updateUI()
    {
        UI.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, character.getHP());
        UI.transform.GetChild(3).GetComponent<UnityEngine.UI.Text>().text = character.inventory.items[1].ToString();
        UI.transform.GetChild(4).GetComponent<UnityEngine.UI.Text>().text = character.inventory.items[2].ToString();
        UI.transform.GetChild(6).GetComponent<UnityEngine.UI.Text>().text = character.inventory.items[4].ToString();
        UI.transform.GetChild(8).GetComponent<UnityEngine.UI.Text>().text = character.inventory.items[5].ToString();
        UI.transform.GetChild(10).GetComponent<UnityEngine.UI.Text>().text = character.inventory.items[6].ToString();

    }
}
