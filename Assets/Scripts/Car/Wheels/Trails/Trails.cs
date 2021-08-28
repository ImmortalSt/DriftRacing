using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour
{
    private const float maxLineSize = 0.1f;

    public float LineSize
    {
        get => _lineSize;
        set => _lineSize = Utills.Map(value, 0, 1, 0, maxLineSize);
    }

    private float _lineSize = 0;
}
