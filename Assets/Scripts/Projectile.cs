using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(0f, 10f)] [SerializeField] float speed = 2f;

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }

    // Update is called once per frame
    void Update () {
        Move();
    }
}
