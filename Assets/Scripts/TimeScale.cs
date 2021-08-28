using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public void SetTimeScale(float newTimeScale)
    {
        Time.timeScale = Mathf.Clamp01(newTimeScale);
    }
}
