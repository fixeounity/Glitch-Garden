﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
	
    public void Fire()
    {
        Instantiate(
            projectilePrefab,
            gun.transform.position,
            projectilePrefab.transform.rotation
            );
    }
}
