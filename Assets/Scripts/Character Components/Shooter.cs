using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;

    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetupProjectileParent();
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetupProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Defend()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void Update()
    {
        Defend();
    }

    private void AttachToParent(ref GameObject newProjectile)
    {
        newProjectile.transform.parent = projectileParent.transform;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(
            projectilePrefab,
            gun.transform.position,
            projectilePrefab.transform.rotation
            );
        AttachToParent(ref newProjectile);

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
