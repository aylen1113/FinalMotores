using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    //public float stopDistance = 10f;
    private NavMeshAgent agent;

    private int hp;
    public PlayerHealth playerHealth;
    public int damageAmount = 10;

    private GameManager gameManager;
    private Animator Anim;

    //bool GhostRun = false;
    //bool GhostAttack = false;


    void Start()
    {
        hp = 100;
        agent = GetComponent<NavMeshAgent>();
        gameManager = FindObjectOfType<GameManager>();
        target = GameObject.Find("Player").transform;
        Anim = GetComponent<Animator>();

        if (Anim == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim != null)
        {
            //if (Vector3.Distance(transform.position, target.position) > stopDistance)
            //{
            Anim.SetBool("move", true);
            agent.SetDestination(target.position);
            //}
            //else
            //{
            //    agent.ResetPath();
            //}
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Damage();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);

                if (Anim != null)
                {
                    Anim.SetBool("attack", true);
                }
            }
        }
    }

    public void Damage()
    {
        hp = hp - 50;
        Debug.Log("enemy hit");
        if (hp <= 0)
        {
            Disappear();
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
        gameManager.EnemyKilled();
    }
}
