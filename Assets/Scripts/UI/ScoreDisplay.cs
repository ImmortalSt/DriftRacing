using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Animator))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Text _text;
    private Animator _animator;
    private float _lastScore;
    private bool _isScoreAdding = false;

    private void Start()
    {
        _text = GetComponent<Text>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(_lastScore - _score.DriftScore) > 0.1)
        {
            if (_isScoreAdding == false)
            {
                _isScoreAdding = true;
                _animator.SetBool("IsScoreAdding", true);
            }
            _text.text = _score.DriftScore.ToString("0");
        } else if(_isScoreAdding == true)
        {
            _isScoreAdding = false;
            _animator.SetBool("IsScoreAdding", false);
        }

        _lastScore = _score.DriftScore;
    }
}
