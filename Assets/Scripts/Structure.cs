using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Structure : MonoBehaviour{
    public int inventoryId;
	public int hp;
    public int width;
    public int height;
    public GameManagers manager;
    // the upperleftmost block is (0,0)
    // block to the right is +
    // block down is -
    // the reference will affect the code at wireController on checking whether is that structure connected to the wire or not
	public List<Structure> connectedStructure;
	// Use this for initialization

	void Damaged(int atkPoint){
		hp -= atkPoint;
	}

	void Destruct(){
		// play animation here
		Destroy(gameObject);
	}

    public Structure Construct(Vector3Int cell)
    {
        if(manager.character.inventory.items[inventoryId] > 0)
        {
            Structure structure = Instantiate(this.gameObject).GetComponent<Structure>();
            manager.character.inventory.items[inventoryId]--;
            Tile a = manager.block.GetTile(cell) as Tile;
            BlockTile tile = a as BlockTile;
            if (tile)
            {
                Debug.Log("Unbuildable in tile");
                return null;
            }
            return structure;
        }
        return null;
    }

	public void Connect(Structure s){
		connectedStructure.Add(s);
	}

	public void ResetConnect(){
		connectedStructure.Clear ();
	}
}