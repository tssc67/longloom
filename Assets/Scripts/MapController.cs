using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiredController : MonoBehaviour {
    public int getBlockPosition(Vector3 position)
    {
        int x = position.x / 128;
        int y = position.y / 128;
        return (y * 256 + x);
    }
}