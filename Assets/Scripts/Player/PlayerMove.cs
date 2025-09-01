using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player
{

    void Start()
    {
        moveDirection = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // 计算移动方向向量并归一化（防止斜向移动更快）
        moveDirection = new Vector3(horizontalInput, verticalInput, 0f);
        // 相对于自身朝向移动（如果是第三人称角色）
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
        Dead();
        healthTextUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            health -= enemy.damage;
            Debug.Log("Player hit by enemy!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = null;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= enemy.damage * Time.deltaTime; // Continuous damage over time
            Debug.Log("Player continuously hit by enemy!");
        }
    }
}
