using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11_Manager : MonoBehaviour
{
    [SerializeField] ParticleSystem confettieParticals;
    [SerializeField] GameObject DescriptionText;
    [SerializeField] PathFollower playerControler;

    private void OnEnable()
    {
        playerControler.speed = 0;
        Invoke(nameof(DisableDescription), 2f);
    }

    public void SetPlayerSpeed(float speed)
    {
        playerControler.speed = speed;
    }
    private void DisableDescription()
    {
        DescriptionText.SetActive(false);
    }
    public void LevelComplete()
    {
        confettieParticals.Play();

        GameManager.instance.LevelComplete();
    }

    public void LevelFailed()
    {
        GameManager.instance.LevelFailed();
    }
}
