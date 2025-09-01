using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : Skills
{
    public float teleportSpeed;
    private PlayerMove playerMove;
    private float playerMoveSpeed;

    private Color color;
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        skillDuration = 0.2f;
        playerMoveSpeed = playerMove.moveSpeed;
        color = playerMove.player.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseSkill();
        }
    }

    public new void UseSkill()
    {
        if (Time.time >= lastSkillTime + skillCooldown)
        {
            lastSkillTime = Time.time;
            StartCoroutine(TeleportCoroutine());
            // Add visual or sound effects here if needed
            Debug.Log("Teleportation skill used!");
        }
    }

    private IEnumerator TeleportCoroutine()
    {
        playerMove.moveSpeed = teleportSpeed;
        playerMove.player.GetComponent<Collider2D>().enabled = false;
        playerMove.player.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
        yield return new WaitForSeconds(skillDuration);
        playerMove.moveSpeed = playerMoveSpeed;
        playerMove.player.GetComponent<Collider2D>().enabled = true;
        playerMove.player.GetComponent<SpriteRenderer>().color = color;
    }
}
