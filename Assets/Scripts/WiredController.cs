using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiredController : MonoBehaviour
{
    
    public List<Pair> markedWire;

    // call this everytime new structure or wire is placed
    public void OnPlace()
    {
        // remove old connected status
        foreach (GameObject obj in GameLogic.Obj)
        {
            if (obj.GetComponent<Structure>() != null)
            {
                obj.GetComponent<Structure>().ResetConnect();
            }
            else if (obj.GetComponent<Wire>() != null)
            {
                obj.GetComponent<Wire>().ResetWireGroup();
            }
        }
        // markedWire.Clear();

        // group every wire together
        int setNumber = 0;
		foreach (GameObject obj in GameLogic.Obj)
		{
            var wireObj = obj.GetComponent<Wire>();
            // if it's a wire
			if (wireObj != null)
			{
                if (wireObj.wireGroup != -1)
                {
                    wireObj.SetWireGroup(setNumber);
                    recursiveCheck(wireObj, setNumber);
                    setNumber++;
                }
				// markedWire.Add(new Pair(obj, setNumber));
			}
		}

		List<GameObject>[] structure = new List<GameObject>[setNumber];
		foreach (GameObject obj in objs)
		{
            var structureObj = obj.GetComponent<Structure>();
			if (structureObj != null)
			{
				GameObject x = GameLogic.Wire.getObjectAt(obj.x - 1, obj.y);
				if (x != null)
				{
					structure[markedWire.Where(p => p.Key == x)].Add(obj);

				}
			}
		}
		for (int i = 0; i<setNumber; i++)
		{
			foreach (GameObject obj in Structure[i])
			{
				foreach (GameObject obj2 in Structure[i])
				{
					if (obj != obj2)
					{
						obj.connected(obj2)
					}
				}
			}
		}
	}

	private void recursiveCheck(Wire obj, int setNumber)
    {
        int x = MapController.GetBlockX(obj.transform.position);
        int y = MapController.GetBlockY(obj.transform.position);
        Wire w = GameLogic.wireBlock.[y - 1, x];

        if (w != null) // a wire object
        {
            if (w.wireGroup == -1) // does not have group
            {
                w.SetWireGroup(setNumber);
                recursiveCheck()
            }
            markedWire.Add(new Pair(x, setNumber));
            recursiveCheck(x, setNumber);
        }
        x = GameLogic.Wire.getObjectAt(obj.x + 1, obj.y);
        if (x != null)
        {
            markedWire.Add(new Pair(x, setNumber));
            recursiveCheck(x, setNumber);
        }
    }
}