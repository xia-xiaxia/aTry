using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public float skillCooldown;
    protected float lastSkillTime;
    protected float skillDuration;

    public void UseSkill()
    {
        if (Time.time >= lastSkillTime + skillCooldown)
        {
            lastSkillTime = Time.time;
            // Implement skill logic here
        }
    }

}