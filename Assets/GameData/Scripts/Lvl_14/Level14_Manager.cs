using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14_Manager : MonoBehaviour
{
    [SerializeField] ParticleSystem confettieParticals;
    [SerializeField] GameObject DescriptionText;
    [SerializeField] PathFollower playerControler;
    [SerializeField] Animator charAnimator;

    private void OnEnable()
    {
        playerControler.speed = 0.0001f;
        Invoke(nameof(DisableDescription), 2f);
    }

    public void SetPlayerSpeed(float speed)
    {
        playerControler.speed = speed;

        charAnimator.SetBool("walk", speed != 0f);
    }
    private void DisableDescription()
    {
        DescriptionText.SetActive(false);
    }
    public void LevelComplete()
    {
        confettieParticals.Play();
        SetPlayerSpeed(0);
        GameManager.instance.LevelComplete();
    }

    public void LevelFailed()
    {
        GameManager.instance.LevelFailed();
    }
}
