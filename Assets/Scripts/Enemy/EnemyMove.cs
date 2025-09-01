using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemy
{
    void Start()
    {

    }

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}
