using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;

        if (other.GetComponent<Pot>() != null && this.CompareTag("Player"))
        {
            other.GetComponent<Pot>().OnSmash();
        }
        if (other.GetComponent<Enemy>() != null || other.GetComponent<Player>() != null)
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.GetComponent<Enemy>() != null)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if (other.GetComponent<Player>() !=null)
                {
                    if (other.GetComponent<Player>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<Player>().currentState = PlayerState.stagger;
                        other.GetComponent<Player>().Knock(knockTime, damage);
                    }
                }
            }
        }
    }
}
