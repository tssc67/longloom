using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class LLEditor : MonoBehaviour {

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("GameObject/Offset_enemies_y")]
    public static void offsetEnemiesY()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        foreach(GameObject enemy in enemies)
        {
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - 10, enemy.transform.position.z);
        }
    }
#endif
}

