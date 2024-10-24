using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl7_PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject lvlDescriptionText,vCam1, vCam2;
    [SerializeField] RCC_CarControllerV3 planeContrller;
    [SerializeField] GameObject playerControler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("switchCamTrigger"))
        {
            vCam1.SetActive(false);
            vCam2.SetActive(true);

            planeContrller.enabled = true;
            other.enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = false;

        }
        else if (other.name.Contains("ControleTrigger"))
        {
            this.GetComponent<AudioSource>().enabled = false;
            GameManager.instance.GameStart();
            playerControler.SetActive(true);
            transform.DOKill();
            //vCam1.SetActive(false);
            //vCam2.SetActive(true);

        }
        else if (other.name.Contains("CompleteTrigger"))
        {
            //followCam.SetActive(false);
            playerControler.SetActive(false);
            planeContrller.GetComponent<RCC_CarControllerV3>().canControl = false;
            GameManager.instance.LevelComplete();
            Debug.Log("Level2 Complete");
        }

    }
    DOTweenPath dtp;
    private void OnEnable()
    {
        Invoke(nameof(DisableDescText), 2f);
    }

    void DisableDescText()
    {
        lvlDescriptionText.SetActive(false);
    }
    private void Start()
    {
        dtp = GetComponent<DOTweenPath>();
    }

    public void ReadyToFlight()
    {
        this.transform.localPosition = Vector3.zero;
        this.transform.eulerAngles = Vector3.up * 180;
    }
   
}
