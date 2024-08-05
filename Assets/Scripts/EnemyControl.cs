using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float stopDistance = 20f;
    private NavMeshAgent agent;

    private int hp;
    public PlayerHealth playerHealth;
    public int damageAmount = 10;

    private GameManager gameManager;
    private Animator Anim;

  


    void Start()
    {
        hp = 100;
        agent = GetComponent<NavMeshAgent>();
        gameManager = FindObjectOfType<GameManager>();
        target = GameObject.Find("Player").transform;
        Anim = GetComponent<Animator>();

        Anim.SetBool("attack", false);
        Anim.SetBool("dissolve", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) < stopDistance)
        {
            Anim.SetBool("move", true);
            agent.SetDestination(target.position);
        }
        else
        {
            agent.ResetPath();
            Anim.SetBool("move", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Damage();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");


            Anim.SetBool("attack", true);
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);

       
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
        Anim.SetBool("dissolve", true);
        StartCoroutine(WaitForDissolve());
    }

    private IEnumerator WaitForDissolve()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        gameManager.EnemyKilled();
    }
}