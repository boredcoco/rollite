using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAttacks_singleplayer : MonoBehaviour
{
    [SerializeField] private float attack2Time = 20f;
    [SerializeField] private float attack3Time = 40f;
    [SerializeField] private float attack4Time = 60f;
    [SerializeField] private float attack5Time = 80f;

    private bool attack2Unlocked = false;
    private bool attack3Unlocked = false;
    private bool attack4Unlocked = false;
    private bool attack5Unlocked = false;

    private void Update()
    {
        if (HighScore.timer >= attack2Time) attack2Unlocked = true;
        if (HighScore.timer >= attack3Time) attack3Unlocked = true;
        if (HighScore.timer >= attack4Time) attack4Unlocked = true;
        if (HighScore.timer >= attack5Time) attack5Unlocked = true;
    }

    public bool attack2_locked()
    {
      return attack2Unlocked;
    }

    public bool attack3_locked()
    {
      return attack3Unlocked;
    }

    public bool attack4_locked()
    {
      return attack4Unlocked;
    }

    public bool attack5_locked()
    {
      return attack5Unlocked;
    }
}
