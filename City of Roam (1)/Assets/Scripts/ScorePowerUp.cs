using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerUp : PowerUpBase
{
    [SerializeField]
    private float time;

    private float startTime;

    private ScoreManager theScoreManager;
    private float normalScorePerSecond;

    public override void Apply(PlayerController player)
    {
        normalScorePerSecond = theScoreManager.scoreIncreasePerSecond;
        theScoreManager.scoreIncreasePerSecond = normalScorePerSecond * 2;
    }

    void Update()
    {
        if (Time.time - startTime > time)
        {
            theScoreManager.scoreIncreasePerSecond = normalScorePerSecond;
            Destroy(gameObject);
        }
    }
}
