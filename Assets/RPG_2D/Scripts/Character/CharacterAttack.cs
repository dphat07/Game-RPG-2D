using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private CharacterAnimation characterAnimation;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform normalAttackPos;
    [SerializeField] private float normalAttackRange;

    public void Attack()
    {
        characterAnimation.SetTrigger("attack");
    }

    public void AttackEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(normalAttackPos.position, normalAttackRange, enemyLayer);

        foreach (var collider in colliders)
        {
            Debug.Log("Attack to: " + collider.name);
          
        }

    }    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(normalAttackPos.position, normalAttackRange);
    }
}
