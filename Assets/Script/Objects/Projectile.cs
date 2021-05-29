using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Bullet Movement")]
    public float speed;
    public Vector2 directionToMove;

    [Header("Bullet Lifetime")]
    public float lifeTime;
    private float lifeTimeAmount;
    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        lifeTimeAmount = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        //reduce the lifetime of the bullet
        lifeTimeAmount -= Time.deltaTime;
        //check if the bullet alive or not

        if (lifeTimeAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //the bullet speed
    public void Fire(Vector2 initialVelocity)
    {
        myRigidBody.velocity = initialVelocity * speed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
