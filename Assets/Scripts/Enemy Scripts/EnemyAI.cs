using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{

    //Enemey Variables
    public float enemyLookRadius = 10f;
    public int Health = 6;
   
    //Audio
    public AudioSource IdleSFX;
    public AudioSource WalkingSFX;
    public AudioSource AttackingSFX;
    public AudioSource EnemyHurtSFX;

    private Animator EnemyAnimator; // Reference to Unity Animator

    Transform Target;
    NavMeshAgent agent;

    private void Start()
    {
        EnemyAnimator = GetComponent<Animator>(); // EnemyAnimator is equal to Animator Component on gameObject
        Target = PlayerControllerVR.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(Target.position, transform.position);

        if (distance <= enemyLookRadius)
        {
            agent.SetDestination(Target.position);
            EnemyAnimator.SetBool("PlayerSpotted", true); // Sets Animator "PlayerSpotted" Parameter to Trues

            if (!WalkingSFX.isPlaying)
            {
                IdleSFX.Stop();
                WalkingSFX.Play();
            }

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        else
        {
            EnemyAnimator.SetBool("PlayerSpotted", false); //Activate the moving animation for the Enemy

            if (!IdleSFX.isPlaying)
            {
                IdleSFX.Play();
                WalkingSFX.Stop();
                EnemyHurtSFX.Stop();
            }
        }
        
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy has been killed!");
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void EnemyTakesDamage(int damage)
    {
        Health -= damage;

        IdleSFX.Stop();
        WalkingSFX.Stop();
        AttackingSFX.Stop();
        EnemyHurtSFX.Play();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player") //If Enemy collides with Player character
        {
            //Play SFX and Activate Enemies Attack Animation
            this.GetComponent<NavMeshAgent>().enabled = false;
            EnemyAnimator.SetBool("AttackingPlayer", true); //Activate the moving animation for the Enemy
            AttackingSFX.Play();

            Debug.Log("Player Has Collided!"); // Display Debug Log in Console
        }
        else
        {
            EnemyAnimator.SetBool("AttackingPlayer", false); //Activate the moving animation for the Enemy
            this.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyLookRadius);
    }

}
