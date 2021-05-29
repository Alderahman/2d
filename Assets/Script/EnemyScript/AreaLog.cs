using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLog : Log
{
    public Collider2D boundary;
    public override void CheckDistance()
    {
        //check if the target in boundary
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) < attackRadius ||
            boundary.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                || currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("WakeUp", true);
            }
        }
        //check if the target not in range of chase radius or the boundary
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius ||
            !boundary.bounds.Contains(target.transform.position))
        {
            anim.SetBool("WakeUp", false);
        }
    }
}
