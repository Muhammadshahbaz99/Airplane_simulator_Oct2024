using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl9_Manager : MonoBehaviour
{
    [SerializeField] ParticleSystem confettieParticals;
    public void LevelComplete()
    {
        confettieParticals.Play();

        GameManager.instance.LevelComplete();
    }
}
