using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpusRotateter : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private AnimationCurve _normalizeRotateCorpus;
    public void BringTheCorpus(float coef)
    {
        transform.localEulerAngles = new Vector3(
                0, 
                Utills.Map(_normalizeRotateCorpus.Evaluate(Mathf.Abs(coef)) * Utills.GetSign(coef), -1, 1, _maxAngle * -1, _maxAngle), 
                0
            );
    }
}
