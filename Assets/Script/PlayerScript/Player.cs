using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class Player : MonoBehaviour
{
    [Header("Player State")]
    public PlayerState currentState;
    
    [Header("Player")]
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector2 change;
    private Animator anim;
    public FloatValue currentHealth;
    public SignalSender playerHealthSignal;
    public FloatValue currentMagic;
    public FloatSignal magicSignal;
    public VectorPositionValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receiveItemSprite;
    [Header("Magic Meter Consumption")]
    public SignalSender consumeMagic;
    [Header("Projectile Stuff")]
    public GameObject projectile;
    public Item bow;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if the player in interact state
        if(currentState == PlayerState.interact)
        {
            return; 
        }
        
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (Input.GetButtonDown("range attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if (playerInventory.CheckForItem(bow))
            {
                StartCoroutine(RangeAttackCo());
            }
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator RangeAttackCo()
    {
        //anim.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        //anim.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void MakeArrow()
    {
        if (currentMagic.RunTimeValue > 0)
        {
            //create arrow and fire it on the player direction
            Vector2 temp = new Vector2(anim.GetFloat("MoveX"), anim.GetFloat("MoveY"));
            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Setup(temp, ArrowRotateDirection());
            //MagicManagement magicManagement ReduceMagic(arrow.magicCost);
            magicSignal.Raise(arrow.magicCost);
            consumeMagic.Raise();
        }
    }

    Vector3 ArrowRotateDirection()
    {
        float temp = Mathf.Atan2(anim.GetFloat("MoveY"), anim.GetFloat("MoveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    public void RaiseItem()
    {
        if (playerInventory.currentItems != null)
        {
            if (currentState != PlayerState.interact)
            {
                anim.SetBool("GetItem", true);
                currentState = PlayerState.interact;
                receiveItemSprite.sprite = playerInventory.currentItems.itemSprite;
            }
            else
            {
                anim.SetBool("GetItem", false);
                currentState = PlayerState.idle;
                receiveItemSprite.sprite = null;
                playerInventory.currentItems = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector2.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            anim.SetFloat("MoveX", change.x);
            anim.SetFloat("MoveY", change.y);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition
            (
            (Vector2)transform.position + change * speed * Time.deltaTime
            );
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RunTimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RunTimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
