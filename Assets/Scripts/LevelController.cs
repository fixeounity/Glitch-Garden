using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    int attackerCount = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        attackerCount++;
    }

    public void AttackerKilled()
    {
        attackerCount--;
        if (levelTimerFinished && attackerCount <= 0)
        {
            Debug.Log("End level now");
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

}
