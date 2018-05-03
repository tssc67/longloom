using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireGroup;

    void Start()
    {
        //int x = MapController.GetBlockX(transform.position);
        //int y = MapController.GetBlockY(transform.position);
        //GameLogic.wireBlock[x, y] = this;
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        //int x = MapController.GetBlockX(transform.position);
        //int y = MapController.GetBlockY(transform.position);
        //GameLogic.wireBlock[x, y] = null;
    }

    public void SetWireGroup(int groupNumber)
    {
        wireGroup = groupNumber;
    }

    public void ResetWireGroup()
    {
        wireGroup = -1;
    }
}
