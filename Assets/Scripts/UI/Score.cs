using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float DriftScore { get; private set; }

    [SerializeField] private Drift _drift;
    [SerializeField] private float ScoreSpeed;

    private void FixedUpdate()
    {
        DriftScore += Mathf.Abs(_drift.DriftCoef * 10) * ScoreSpeed;
    }

    public void ClearScore()
    {
        DriftScore = 0;
    }
}
