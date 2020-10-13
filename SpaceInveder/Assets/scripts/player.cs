using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float maxL;
    public float maxR;
    public Rigidbody2D rb;
    public float speed;
    public bool mL = false;
    public bool mR = false;
    public float ShootSpeed;
    private float SS = 0;
    public bullet bullet;
    public void moveLeft()
    {
        mL = true;
        
    }
    public void moveLeftExit()
    {
        mL = false;
    }
    public void moveRight()
    {
        mR = true;
    }
    public void moveRightExit()
    {
        mR = false;
    }
    private void Update()
    {
        if (mL && transform.position.x>0.25f)
        {
            rb.MovePosition(transform.position + new Vector3(-speed, 0, 0) * Time.fixedDeltaTime);
        }
        if (mR && transform.position.x<4.75f)
        {
            rb.MovePosition(transform.position + new Vector3(speed, 0, 0) * Time.fixedDeltaTime);
        }

        SS += Time.deltaTime;
        if (SS >= ShootSpeed)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            SS = 0;
        }
    }
}
