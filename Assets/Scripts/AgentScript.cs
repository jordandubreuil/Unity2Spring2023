using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public Animator anim;
    public bool isAttacking = false;
    bool isJumping = false;
    public float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 2 && !isAttacking)
        {
            StartCoroutine(EndAttack());
            anim.SetTrigger("Attack");
        }
        if (!isAttacking) {
            anim.SetFloat("Direction", agent.velocity.magnitude);
            agent.destination = target.transform.position;

            if (agent.isOnOffMeshLink && !isJumping)
            {
                StartCoroutine(EndJump());
                anim.SetTrigger("Jump");
            }
        }



        
    }

    IEnumerator EndAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(3.0f);
        isAttacking = false;
    }

    IEnumerator EndJump()
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpTime);
        isJumping = false;

    }
}
