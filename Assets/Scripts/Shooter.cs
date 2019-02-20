using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("Shoot");
        }
        else
        {
            Debug.Log("Sit and wait");
        }
    }

    public void Fire()
    {
        Instantiate(
            projectilePrefab,
            gun.transform.position,
            projectilePrefab.transform.rotation
            );
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach(var spawner in attackerSpawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        var attackerCount = myLaneSpawner.transform.childCount;
        return attackerCount > 0;
    }

}
