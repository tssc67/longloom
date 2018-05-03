using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mainmenu : MonoBehaviour {

    // Use this for initialization
    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneLoader(1);
        }
    }
}
