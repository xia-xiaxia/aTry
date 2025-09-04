using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 武器基类
public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")] // 武器基本属性
    public string weaponName; // 武器名称
    public float damage;      // 伤害值
    public float range;       // 攻击范围

    public bool isGet;        // 是否被获取

    public float moveSpeed;   // 移动速度

    [Header("Weapon Settings")] // 武器设置
    public bool isAutomatic;    // 是否为自动武器（自动或半自动）
    public int magazineSize;    // 弹匣容量（每个弹匣可装多少发）
    public float reloadTime;    // 装弹时间（重新装弹需要多长时间）
    public float fireRate;      // 射速（武器能多快发射）

    void Start()
    {
        // 初始化函数，武器创建时调用
    }

    void Update()
    {
        // 每帧更新函数
    }

    protected void weaponMove()
    {
        // 武器移动逻辑处理函数
    }

    protected void weaponAttack()
    {
        // 武器攻击逻辑处理函数
    }

    protected void weaponPickup()
    {
        // 武器拾取逻辑处理函数

    }

 

    protected void pickupWeaponUI()
    {
        // 显示武器拾取UI

    }
}
