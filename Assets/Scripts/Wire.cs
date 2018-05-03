using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireGroup;

    void Start()
    {
        int x = (int) (transform.position.x);
        int y = (int) (- transform.position.y); // because y=0 is uppermost, y=-maxsize is downmost, but I want y as a plus value for array
        if (x >= 0 && y >= 0) GameLogic.wireBlock[y, x] = this;
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        int x = (int)(transform.position.x);
        int y = (int)(-transform.position.y); // because y=0 is uppermost, y=-maxsize is downmost, but I want y as a plus value for array
        if (x >= 0 && y >= 0) GameLogic.wireBlock[y, x] = null;
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
