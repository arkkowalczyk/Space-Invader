using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public Image img;
    public float cd = 40.0f,cdr=0;
    public bool boost=false, active=false;
    public player pl;
    public float t = 0;

    private void FixedUpdate()
    {
        img.fillAmount += 1.0f / cd * Time.fixedDeltaTime;
    }
    void Update()
    {
        
        if (img.fillAmount == 1)
        {
            boost = true;
        }
        t -= Time.deltaTime;
        if (active && t<=0)
        {
            pl.ShootSpeed *= 2;
            active = false;
        }

    }
    public void useBoost()
    {
        if (boost)
        {
            img.fillAmount = 0;
            boost = false;
            pl.ShootSpeed /= 2;
            active = true;
            t = 5;
        }
    }
}
