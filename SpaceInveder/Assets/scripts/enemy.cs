using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 speed, speed2;
    public float reverse =0, shoot=0;
    public int down = 0;
    public bool isshooting;
    public float mindelay = 4f, maxdelay = 7f, delay;
    public enemybullet eb;
    public static int score=0;
    public static int enemycount=0, maxEnemy=0;
    public static int[] hss= new int[10];


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        delay=Random.Range(mindelay, maxdelay);
        Scors scors = HIghScors.load();
        for (int i = 0; i < 10; i++)
        {
            hss[i]= scors.hs[i];
        }
        speed2 = speed;
    }


    void FixedUpdate() 
    { 
        if(speed.x>0) speed.x = speed2.x + (float)(maxEnemy - enemycount) / 10;

        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime);

        reverse += (speed.x * Time.fixedDeltaTime);

        if (reverse>0.5f || reverse < -0.5f)
        {
            reverse = 0;
            speed = -speed;
            down++;
        }
        if (down == 2)
        {
            down = 0;
            rb.MovePosition(transform.position + new Vector3(0,-0.75f,0));
        }
        shoot += Time.deltaTime;
        if (shoot>=delay && isshooting)
        {
            shoot = 0;
            delay = Random.Range(mindelay, maxdelay);
            Instantiate(eb, transform.position, Quaternion.identity);
        }

        if (transform.position.y < 1)
        {
            endGame();
        }
    }
    public void endGame()
    {
        int ph;
        HIghScors.SaveScore(this);
        FindObjectOfType<Show>().points();
        FindObjectOfType<Show>().change();
        for(int i = 0; i < 10; i++)
        {
            if (hss[i] < score)
            {
                ph = hss[i];
                hss[i] = score;
                score = ph;
            }
        }
        score = 0;
        maxEnemy = 0;
        enemycount = 0;
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            enemycount--;
            score++;
            if(enemycount == 0)
            {
                endGame();
            }
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            enemycount--;
            score-=(maxEnemy/6)*2;
            if (enemycount == 0)
            {
                endGame();
            }
        }
    }
}
