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

        // add structure to group of adjacent wire
		List<Structure>[] structure = new List<Structure>[setNumber];
		foreach (GameObject obj in GameLogic.Obj)
		{
            var structureObj = obj.GetComponent<Structure>();
			if (structureObj != null)
			{
                int x = MapController.GetBlockX(obj.transform.position);
                int y = MapController.GetBlockY(obj.transform.position);

                // check left and right side of structure
                for (int i=0; i<structureObj.height; i++)
                {
                    Wire w = GameLogic.wireBlock[y + i, x - 1];
                    if (w != null)
                    {
                        if (!structure[w.wireGroup].Contains(structureObj)) // if it wasn't already add to that group
                        {
                            structure[w.wireGroup].Add(structureObj);
                        }
                    }

                    w = GameLogic.wireBlock[y + i, x + structureObj.width - 1];
                    if (w != null)
                    {
                        if (!structure[w.wireGroup].Contains(structureObj)) // if it wasn't already add to that group
                        {
                            structure[w.wireGroup].Add(structureObj);
                        }
                    }
                }

                // check top and bottom side of structure
                for (int i = 0; i < structureObj.width; i++)
                {
                    Wire w = GameLogic.wireBlock[y - 1, x + i];
                    if (w != null)
                    {
                        if (!structure[w.wireGroup].Contains(structureObj)) // if it wasn't already add to that group
                        {
                            structure[w.wireGroup].Add(structureObj);
                        }
                    }

                    w = GameLogic.wireBlock[y + structureObj.height - 1, x + i];
                    if (w != null)
                    {
                        if (!structure[w.wireGroup].Contains(structureObj)) // if it wasn't already add to that group
                        {
                            structure[w.wireGroup].Add(structureObj);
                        }
                    }
                }
            }
		}

        // connect structure from each group of wire together
		for (int i = 0; i<setNumber; i++)
		{
			foreach (Structure str1 in structure[i])
			{
				foreach (Structure str2 in structure[i])
				{
					if (str1 != str2)
					{
                        str1.Connect(str2);
					}
				}
			}
		}
	}

	private void recursiveCheck(Wire obj, int setNumber)
    {
        int x = MapController.GetBlockX(obj.transform.position);
        int y = MapController.GetBlockY(obj.transform.position);

        Wire w = GameLogic.wireBlock[y - 1, x];
        if (w != null) // a wire object
        {
            if (w.wireGroup == -1) // does not have group
            {
                w.SetWireGroup(setNumber);
                recursiveCheck(w, setNumber);
            }
        }

        w = GameLogic.wireBlock[y + 1, x];
        if (w != null) // a wire object
        {
            if (w.wireGroup == -1) // does not have group
            {
                w.SetWireGroup(setNumber);
                recursiveCheck(w, setNumber);
            }
        }

        w = GameLogic.wireBlock[y, x + 1];
        if (w != null) // a wire object
        {
            if (w.wireGroup == -1) // does not have group
            {
                w.SetWireGroup(setNumber);
                recursiveCheck(w, setNumber);
            }
        }

        w = GameLogic.wireBlock[y, x - 1];
        if (w != null) // a wire object
        {
            if (w.wireGroup == -1) // does not have group
            {
                w.SetWireGroup(setNumber);
                recursiveCheck(w, setNumber);
            }
        }
    }
}