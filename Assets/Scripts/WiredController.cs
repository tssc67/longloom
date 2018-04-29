using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiredController : MonoBehaviour {

	public List<GameObject> Object;
	public List<Pair> markedWire;

	public void onPlace()
	{
		foreach (GameObject obj in Object)
		{
			if (obj is Structure)
			{
				obj.ResetConnect ();
			}
		}
		int setNumber = 0;
		foreach (GameObject obj in Object)
		{
			if (obj is Wire && markedWire.Any(p => p.first != obj))
			{
				markedWire.Add(Pair(obj, setNumber));
				recursiveCheck(obj, setNumber);
				setNumber++;
			}
		}

		List<List<GameObject>> structure;
		foreach (GameObject obj in Object)
		{
			if (obj is Structure)
			{
				GameObject x = GameLogic.Wire.getObjectAt(obj.x-1, obj.y);
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

	private void recursiveCheck(GameObject obj, int setNumber)
	{
		GameObject x = GameLogic.Wire.getObjectAt(obj.x-1, obj.y);
		if (x != null)
		{
			markedWire.Add(new Pair(x, setNumber));
			recursiveCheck(x, setNumber);
		}
		x = GameLogic.Wire.getObjectAt(obj.x+1, obj.y);
		if (x != null)
		{
			markedWire.Add(new Pair(x, setNumber));
			recursiveCheck(x, setNumber);
		}
	}
}