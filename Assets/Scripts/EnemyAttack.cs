using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackTransform;
    [Range(0,2)]
    public float radius = 0;
    
    public void AttackPlayer()
    {
        Collider[]  hitCollider = Physics.OverlapSphere(attackTransform.position, radius);

        foreach(var player in hitCollider)
        {
            if (player.CompareTag("Player"))
            {
                player.gameObject.GetComponent<PlayerHealth>().TakeDamage(10.0f);
            }
        }

    }

    //Visulizes the attack sphere.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackTransform.position, radius);
    }
}
