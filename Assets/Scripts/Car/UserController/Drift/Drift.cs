using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
	[SerializeField] private float _reactionSpeed;
	[SerializeField] private float _timeToFullDrift;
	[SerializeField] private float _angleCoef;
	[SerializeField] private float _driftRuddleAngleReaction;

	[HideInInspector] public float RotateOffset { get; private set; } = 0;
	[HideInInspector] public float DriftCoef { get; private set; } = 0;

	public void RecalculateValues(float speed, float ruddelAngle, float maxRuddleAngle)
	{
		if (speed > _reactionSpeed)
		{
			if (Mathf.Abs(ruddelAngle) > maxRuddleAngle - _driftRuddleAngleReaction)
			{
				DriftCoef += Time.deltaTime / _timeToFullDrift * Utills.GetSign(ruddelAngle);
			} 
			else
			{
				if (Mathf.Abs(DriftCoef) > 0.05f)
					DriftCoef -= Time.deltaTime / _timeToFullDrift * Utills.GetSign(DriftCoef);
				else
					DriftCoef = 0;
			}

			DriftCoef = Mathf.Clamp(DriftCoef, -1, 1);

			RotateOffset = DriftCoef * _angleCoef * -1;
		}
		else
		{
			DriftCoef = 0;
			RotateOffset = 0;
		}
	}
}
