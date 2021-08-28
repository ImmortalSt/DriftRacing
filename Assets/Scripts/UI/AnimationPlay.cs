using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        _animation.Play();
    }
}
