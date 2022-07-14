using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class UnlockAttacks_singleplayer : MonoBehaviour
{
    [SerializeField] private float attack2Time = 10f;
    [SerializeField] private float attack3Time = 20f;
    [SerializeField] private float attack4Time = 40f;
    [SerializeField] private float attack5Time = 80f;

    [SerializeField] private float ai_speed_increment = 1f;

    [SerializeField] private GameObject levelUp;

    private AIPath aipath;
    private SinglePlayerAttack singlepAttack;

    private void Start()
    {
      aipath = GetComponent<AIPath>();
      singlepAttack = GetComponent<SinglePlayerAttack>();
    }

    private void Update()
    {
        if (HighScore.timer >= attack2Time && singlepAttack.maxAttack_Unlocked() < 2)
        {
          singlepAttack.unlockAttack();
          aipath.speed = aipath.speed + ai_speed_increment;
          levelUp.SetActive(true);
        }
        if (HighScore.timer >= attack3Time && singlepAttack.maxAttack_Unlocked() < 3)
        {
          singlepAttack.unlockAttack();
          aipath.speed = aipath.speed + ai_speed_increment;
          levelUp.SetActive(true);
        }
        if (HighScore.timer >= attack4Time && singlepAttack.maxAttack_Unlocked() < 4)
        {
          singlepAttack.unlockAttack();
          aipath.speed = aipath.speed + ai_speed_increment;
          levelUp.SetActive(true);
        }
        if (HighScore.timer >= attack5Time && singlepAttack.maxAttack_Unlocked() < 5)
        {
          singlepAttack.unlockAttack();
          aipath.speed = aipath.speed + ai_speed_increment;
          levelUp.SetActive(true);
        }
    }
}
