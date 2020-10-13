using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = -1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.MovePosition(transform.position + new Vector3(0, speed, 0) * Time.fixedDeltaTime);
        if (transform.position.y < 0) Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            enemy.score -= (enemy.maxEnemy / 6) * 2;
        }
    }
}
