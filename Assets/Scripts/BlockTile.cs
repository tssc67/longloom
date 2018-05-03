using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockTile : Tile {
    public enum BlockType
    {
        Dirt = 1,
        IronOre = 2,
        Lava = 3,
        Undiggable = 4
    };

    public Sprite[] m_Sprites;
    public BlockType blockType = BlockType.Dirt;
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
            tileData.sprite = m_Sprites[0];
            var m = tileData.transform;
            tileData.transform = m;
            tileData.flags = TileFlags.LockTransform;
            tileData.colliderType = ColliderType.Grid;
    }
#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/BlockTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Road Tile", "New Block Tile", "Asset", "Save Block Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BlockTile>(), path);
    }
#endif

#if UNITY_EDITOR

    [CustomEditor(typeof(BlockTile))]

    public class TerrainTileEditor : Editor

    {

        private BlockTile tile { get { return (target as BlockTile); } }



        public void OnEnable()

        {

            if (tile.m_Sprites == null || tile.m_Sprites.Length != 15)

            {

                tile.m_Sprites = new Sprite[15];

                EditorUtility.SetDirty(tile);

            }

        }





        public override void OnInspectorGUI()

        {

            EditorGUILayout.LabelField("Place sprites shown based on the contents of the sprite.");

            EditorGUILayout.Space();



            float oldLabelWidth = EditorGUIUtility.labelWidth;

            EditorGUIUtility.labelWidth = 210;



            EditorGUI.BeginChangeCheck();

            tile.blockType = (BlockType)EditorGUILayout.IntField("Block type", (int)tile.blockType, new GUILayoutOption[0]);
            tile.m_Sprites[0] = (Sprite)EditorGUILayout.ObjectField("Sprite", tile.m_Sprites[0], typeof(Sprite), false, null);
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(tile);



            EditorGUIUtility.labelWidth = oldLabelWidth;

        }

    }

#endif
}
