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

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(
            attacker,
            transform.position,
            attacker.transform.rotation
        ) as Attacker;

        newAttacker.transform.parent = transform;
    }

    private void SpawnAttacker()
    {
        if (attackerPrefabs.Count <= 0) return;
        int attackerIndex = Random.Range(0, attackerPrefabs.Count);
        Spawn(attackerPrefabs[attackerIndex]);
    }

}
