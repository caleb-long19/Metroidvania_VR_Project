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
        //Retrieve components on the AI game object
        EnemyAnimator = GetComponent<Animator>();
        Target = PlayerControllerVR.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Store the distance from the player to the enemy
        float distance = Vector3.Distance(Target.position, transform.position);

        //Check to see if the player is within the chosen look radius
        if (distance <= enemyLookRadius)
        {
            //Activate the nav mesh agent on the model to update the transform values to match the target/player, update animation to walking
            agent.SetDestination(Target.position);
            EnemyAnimator.SetBool("PlayerSpotted", true);

            //Check if the walking sound is playing, if not, play it
            if (!WalkingSFX.isPlaying)
            {
                IdleSFX.Stop();
                WalkingSFX.Play();
            }


            if (distance <= agent.stoppingDistance)
            {
                //Face towards the target
                FaceTarget();
            }
        }
        else
        {
            //Disbale enemy movement animation
            EnemyAnimator.SetBool("PlayerSpotted", false);

            //play the idle sound effect, if the enemy hasn't detected the player
            if (!IdleSFX.isPlaying)
            {
                IdleSFX.Play();
                WalkingSFX.Stop();
                EnemyHurtSFX.Stop();
            }
        }
        
        //If the enemy reaches 0 health, destroy them
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy has been killed!");
        }
    }

    void FaceTarget()
    {
        //Store the normalised data of the player position - the enemy position
        Vector3 direction = (Target.position - transform.position).normalized;

        //Rotate the look direction of the enemy model, based on the normalised direction
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        //update the rotation values of the enemy model to face towards the player model
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void EnemyTakesDamage(int damage)
    {
        //If the crossbow bolt collides with enemy, reduce enemy health and play correct audio file
        Health -= damage;

        IdleSFX.Stop();
        WalkingSFX.Stop();
        AttackingSFX.Stop();
        EnemyHurtSFX.Play();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //If enemy collides with player, play attack SFX and Activate Enemies Attack Animation, disable the nav mesh agent to stop the enemy from moving while attacking
            this.GetComponent<NavMeshAgent>().enabled = false;
            EnemyAnimator.SetBool("AttackingPlayer", true);
            AttackingSFX.Play();

            Debug.Log("Player Has Collided!");
        }
        else
        {
            //Activate the moving animation for the Enemy and activate the navmesh
            EnemyAnimator.SetBool("AttackingPlayer", false);
            this.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Draw a sphere to view the look radius of the enemy
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyLookRadius);
    }

}
