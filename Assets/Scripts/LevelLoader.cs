using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] float startScreenDelay = 4f;
    [SerializeField] float gameOverDelay = 2f;

    int currentSceneIndex = 0;

	// Use this for initialization
	void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreenWithDelay());
        }
	}

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    private IEnumerator LoadGameOverWithDelayImpl()
    {
        yield return new WaitForSeconds(gameOverDelay);
        LoadGameOver();
    }

    public void LoadGameOverWithDelay()
    {
        StartCoroutine(LoadGameOverWithDelayImpl());
    }

    private IEnumerator LoadStartScreenWithDelay()
    {
        yield return new WaitForSeconds(startScreenDelay);
        LoadStartScreen();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}
