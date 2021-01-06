using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation SkeletonAnimation;
    [SerializeField] private AnimationReferenceAsset idle;
    [SerializeField] private AnimationReferenceAsset left;
    [SerializeField] private AnimationReferenceAsset left_idle;
    [SerializeField] private AnimationReferenceAsset right;
    [SerializeField] private AnimationReferenceAsset right_idle;
    private float _finalSpeed;
    private string _playerHorizontalButton;
    private float _rightTimer = 0;
    private float _leftTimer = 0;
    private void Start()
    {
        GetDataFromPlayer();
    }
    private void Update()
    {
        AnimationSpeedAdjust();
    }
    private void FixedUpdate()
    {
        SwapAnimations();
    }

    private void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        SkeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }
    private void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        SkeletonAnimation.state.SetAnimation(0, animation, loop);
    }

    private float SpeedAnimation()
    {
        float animationSpeed = CurrentSpeed() / _finalSpeed;
        if (animationSpeed > 1f)
        {
            animationSpeed = 1f;
        }
        return animationSpeed;
    }

    private float CurrentSpeed()
    {
        float currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        if (currentSpeed < 0.1f) currentSpeed = 0.1f;
        return currentSpeed;
    }

    private void GetDataFromPlayer()
    {
        _finalSpeed = GetComponent<Player_Controller>().FinalSpeedLimit;
        _playerHorizontalButton = GetComponent<Player_Controller>().PlayerHorizontalButton.ToString();
    }
    private void AnimationSpeedAdjust()
    {
        if (SkeletonAnimation.AnimationName != null &&
            SkeletonAnimation.AnimationName.Equals("idle") ||
            SkeletonAnimation.AnimationName.Equals("right_idle") ||
            SkeletonAnimation.AnimationName.Equals("left_idle"))
        {
            SkeletonAnimation.GetComponent<SkeletonAnimation>().timeScale = SpeedAnimation();
        }
    }
    private void SwapAnimations()
    {
        switch (Input.GetAxis(_playerHorizontalButton.ToString()))
        {
            case 1:
                if (SkeletonAnimation.AnimationName != null &&
                    SkeletonAnimation.AnimationName.Equals("left") ||
                    SkeletonAnimation.AnimationName.Equals("left_idle"))
                {
                    _leftTimer += Time.deltaTime;
                    if (_leftTimer >= 0.2667f)
                    {
                        if (SkeletonAnimation.AnimationName != null && SkeletonAnimation.AnimationName.Equals("left_idle"))
                        {
                            break;
                        }
                        SetAnimation(left_idle, true);
                    }
                    SkeletonAnimation.GetComponent<SkeletonAnimation>().timeScale = 1;
                    return;
                }
                SetAnimation(left, false, 1);
                break;
            case -1:
                if (SkeletonAnimation.AnimationName != null &&
                    SkeletonAnimation.AnimationName.Equals("right") ||
                    SkeletonAnimation.AnimationName.Equals("right_idle"))
                {
                    _rightTimer += Time.deltaTime;
                    if (_rightTimer >= 0.2667f)
                    {
                        if (SkeletonAnimation.AnimationName != null && SkeletonAnimation.AnimationName.Equals("right_idle"))
                        {
                            break;
                        }
                        SetAnimation(right_idle, true);
                    }
                    SkeletonAnimation.GetComponent<SkeletonAnimation>().timeScale = 1;
                    return;
                }
                SetAnimation(right, false, 1);
                break;
            default:
                _rightTimer = 0;
                _leftTimer = 0;
                if (SkeletonAnimation.AnimationName != null && SkeletonAnimation.AnimationName.Equals("idle"))
                {
                    return;
                }
                SetAnimation(idle, true);
                break;
        }
    }
}
