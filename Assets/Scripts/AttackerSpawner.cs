using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] List<Attacker> attackerPrefabs;


    // Use this for initialization
    IEnumerator Start () {
        if (attackerPrefabs.Count <= 0) yield return null;
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(
        attackerPrefabs[0],
        transform.position,
        attackerPrefabs[0].transform.rotation
        );
    }


    // Update is called once per frame
    void Update () {
		
	}
}
