using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveDirection;
    public GameObject player;
    public float health;

    public Enemy enemy;

    public TextMeshProUGUI healthText;

    public TextMeshProUGUI deadText;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            player = this.gameObject;
        }
    }

    void Update()
    {

    }

    protected void Dead()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
            // 这里可以添加玩家死亡时的处理逻辑，比如播放动画、重生等
            deadText.gameObject.SetActive(true);
            player.SetActive(false);
        }
    }

    protected void healthTextUpdate()
    {
        healthText.text = "Health: " + Mathf.FloorToInt(health).ToString();
        Debug.Log("Health updated: " + health);
    }
}
