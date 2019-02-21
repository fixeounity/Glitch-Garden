using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] float levelFinishedDelay = 5f;

    int attackerCount = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        attackerCount++;
    }

    public void AttackerKilled()
    {
        attackerCount--;
        if (levelTimerFinished && attackerCount <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    private IEnumerator HandleWinCondition()
    {
        GetComponent<AudioSource>().Play();
        winLabel.SetActive(true);
        yield return new WaitForSeconds(levelFinishedDelay);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

}
