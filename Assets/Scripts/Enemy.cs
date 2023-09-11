using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected float minDistChase;
    protected bool chasing;
    [SerializeField] protected float minDistAttack;
    [SerializeField] protected Transform spriteHolder;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected Animator anim;
    [SerializeField] protected int HPmax;
    protected int HP;
    [SerializeField] protected int attackPower;
    [SerializeField] protected float cooldown;
    protected float lastAttack;


    private Player player;

    void Awake()
    {
        HP = HPmax;
        chasing = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EnemyManager.Instance.AddNewEnemy(this);
    }

    void Update()
    {
        if (!player.isAlive()) return;

        //Correction de la rotation du sprite.
        spriteHolder.eulerAngles = new Vector3(90, 0, 0);

        //Correction du FlipX du sprite.
        if (player.transform.position.x > transform.position.x) sprite.flipX = true;
        else sprite.flipX = false;

        //Correction de l'ordre d'affichage du sprite
        sprite.sortingOrder = (int)(-transform.position.z * 100);

        

        if (chasing)
        {
            //Attack ou Move en fonction de la distance avec le Player
            if (CheckIfPlayerInRadius(minDistAttack)) Attack();
            else Move();
        }
        else
        {
            //Check si Player est à proximité
            if (CheckIfPlayerInRadius(minDistChase)) chasing = true;
        }
        
        
        
    }

    private void Attack()
    {
        anim.SetBool("isWalking", false);
        agent.isStopped = true;

        if (lastAttack + cooldown <= Time.time)
        {
            lastAttack = Time.time;
            player.Hurt(attackPower);
        }
    }

    private void Move()
    {
        anim.SetBool("isWalking", true);
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
    }

    public void Hurt(int damages)
    {
        HP -= damages;

        if (HP <= 0) Die();
        else anim.SetTrigger("Hit");
    }

    private void Die()
    {
        EnemyManager.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistChase);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistAttack);
    }

    private bool CheckIfPlayerInRadius(float radius)
    {
        return Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(player.transform.position.x, player.transform.position.z)) <= radius;
    }
}
