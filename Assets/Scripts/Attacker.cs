using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f,5f)]float currentSpeed = 1f;

    GameObject currentTarget;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
	}

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;
        var health = currentTarget.GetComponent<Health>();
        if (!health) return;
        health.DealDamage(damage);
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (!levelController) return;
        levelController.AttackerKilled();
    }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

}
