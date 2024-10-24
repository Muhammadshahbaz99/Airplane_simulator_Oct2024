using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl8_Manager : MonoBehaviour
{
    [SerializeField] ParticleSystem fireParticlas, waterParticals,confettieParticals;
    [SerializeField] Transform wateronfloor;
    [SerializeField] GameObject lvlUI;
    // Start is called before the first frame update
    [SerializeField] float firereducutionSpeed;

    bool canScale = false;
    bool levelComplet = false;
    public void PlayWaterParticals()
    {
        waterParticals.Play();
        canScale = true;
    }
    private void LateUpdate()
    {
        if (fireParticlas.transform.localScale.z > firereducutionSpeed && canScale)
        {
            fireParticlas.transform.localScale -= Vector3.one * firereducutionSpeed;
            wateronfloor.localScale += Vector3.one * firereducutionSpeed;
        }

        if(fireParticlas.transform.localScale.z <= firereducutionSpeed&&!levelComplet)
        {
            levelComplet = true;
            GameManager.instance.LevelComplete();
            confettieParticals.Play();
        }

    }
    public void StopWaterParticals()
    {
        waterParticals.Stop();
        canScale = false;
    }
}
