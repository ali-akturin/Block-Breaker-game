using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    GameSession gameStatus;
    public void LoadNextScene()
	{
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenuloader()
    {
        int MenuLoaderIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().Gamereset();
    }
    public void InstructionsLoader()
    {
        int InsLoaderIndedx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(3);
        FindObjectOfType<GameSession>().Gamereset();
    }
}
