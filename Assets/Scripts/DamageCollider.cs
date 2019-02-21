using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {

    LivesDisplay livesDisplay;

    private void Start()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (!otherCollider.GetComponent<Attacker>()) return;
        if (!livesDisplay) return;
        livesDisplay.TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
