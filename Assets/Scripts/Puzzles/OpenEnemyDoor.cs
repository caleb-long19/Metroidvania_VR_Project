using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEnemyDoor : MonoBehaviour
{
    public GameObject First_Enemy;
    public GameObject Second_Enemy;
    public Animator EnemyDoorOpening;

    void Update()
    {
        if (First_Enemy == null && Second_Enemy == null)
        {
            EnemyDoorOpening.SetBool("AllEnemiesKilled", true);
        }
    }
}
