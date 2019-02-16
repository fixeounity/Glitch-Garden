using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    [Range(0f, 10f)][SerializeField] float projectileSpeed = 2f;
	
    public void Fire()
    {
        var projectile = Instantiate(
            projectilePrefab,
            gun.transform.position,
            projectilePrefab.transform.rotation
            );
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0f);
        return;
    }
}
