using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyKnife : Weapon
{
    // 旋转中心（玩家位置）
    private Transform playerTransform;

    // 当前角度
    private float currentAngle = 0f;

    void Start()
    {
        // 获取玩家transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // 初始化飞刀位置，放在玩家周围指定半径的圆上
        if (playerTransform != null)
        {
            UpdatePosition();
        }
        else
        {
            Debug.LogError("找不到Player对象，请确保Player已被正确标记Tag");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // 更新角度
            currentAngle += moveSpeed * Time.deltaTime;

            // 保持角度在0-360度之间
            if (currentAngle >= 360f)
            {
                currentAngle -= 360f;
            }

            // 更新飞刀位置
            weaponMove();
        }
    }

    private new void weaponMove()
    {
        // 飞刀特有的移动逻辑
        UpdatePosition();
    }

    // 更新飞刀位置方法
    private void UpdatePosition()
    {
        Debug.Log("111");
        // 计算在圆上的位置
        float radian = currentAngle * Mathf.Deg2Rad; // 将角度转换为弧度
        float x = Mathf.Cos(radian) * range;
        float y = Mathf.Sin(radian) * range;

        // 更新飞刀位置为玩家位置加上计算出的偏移
        Vector3 newPosition = playerTransform.position + new Vector3(x, y, 0);
        transform.position = newPosition;

        // 调整飞刀的旋转，使其始终朝向运动方向
        float rotationZ = currentAngle - 90f; // -90是因为默认飞刀可能需要调整朝向
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // 检测与敌人的碰撞
        if (collision.CompareTag("Enemy"))
        {
            // 处理击中敌人的逻辑
            Debug.Log("飞刀击中敌人: " + collision.name);
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    
}
