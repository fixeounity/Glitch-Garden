using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void TriggerAnimation(ref GameObject otherObject)
    {
        if (otherObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("jumpTrigger");
        }
        else
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (!otherObject.GetComponent<Defender>()) return;
        TriggerAnimation(ref otherObject);

    }
}
