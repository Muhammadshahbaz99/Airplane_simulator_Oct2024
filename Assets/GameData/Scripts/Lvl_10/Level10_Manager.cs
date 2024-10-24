using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10_Manager : MonoBehaviour
{
    [SerializeField] ParticleSystem ConfettieParticals;
    [SerializeField] GameObject DescriptionText;
    public Animator animator;

    private void OnEnable()
    {
        animator.speed = 0;
        Invoke(nameof(DisableDescription), 2f);
    }

    private void DisableDescription()
    {
        DescriptionText.SetActive(false);
    }
    public void LevelComplete()
    {
        ConfettieParticals.Play();
        GameManager.instance.LevelComplete();
    }

    public void SetAnimatorSpeed(float s)
    {
        animator.speed = s;
    }
}
