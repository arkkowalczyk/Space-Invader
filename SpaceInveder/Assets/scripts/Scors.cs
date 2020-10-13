using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scors
{
    public int score;
    public int[] hs=new int[10];

    public Scors(enemy enemy)
    {
        score = enemy.score;
        for (int i = 0; i < 10; i++)
        {
            if (enemy.hss[i]!=0) {
                hs[i] = enemy.hss[i];
            }
        }
    }
}
