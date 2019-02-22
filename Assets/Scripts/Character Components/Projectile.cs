using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(0f, 10f)] [SerializeField] float speed = 2f;
    [SerializeField] float damage = 100;

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }

    // Update is called once per frame
    void Update () {
        Move();
    }

    private void HandleDamage(ref Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (!health || !attacker) return;

        health.DealDamage(damage);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        HandleDamage(ref otherCollider);
    }


}
