using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float timeToWait = 4f;

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

    private IEnumerator LoadStartScreenWithDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadStartScreen();
    }
	
}
