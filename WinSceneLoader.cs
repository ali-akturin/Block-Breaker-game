using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneLoader : MonoBehaviour {
    public void WinScreenLoader()
    {
        int WinLoader = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}
