using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public enemy[] e;
    void Start()
    {
        Instantiate(e[Random.Range(0,2)], transform.position, Quaternion.identity);
        enemy.enemycount++;
        enemy.maxEnemy++;
    }
}
