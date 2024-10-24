using DG.Tweening;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15_Manager : MonoBehaviour
{
    [SerializeField] ParticleSystem confettieParticals;
    [SerializeField] GameObject approvalPanel;
    [SerializeField] Transform endTarget;
    [SerializeField] GameObject DescriptionText;
    [SerializeField] GameObject[] playerControler;
    [SerializeField] GameObject[] luggage;

    [SerializeField] GameObject scaner;

    int currPassenger = 0;
    private void OnEnable()
    {
        Invoke(nameof(DisableDescription), 2f);
    }

    public void SetPlayerSpeed(float speed)
    {
        //playerControler.speed = speed;

        //charAnimator.SetBool("walk", speed != 0f);
    }
    private void DisableDescription()
    {
        DescriptionText.SetActive(false);
        NextPassenger();
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

    void NextPassenger()
    {
        if (currPassenger >= playerControler.Length)
            return;
        else
            LevelComplete();

        playerControler[currPassenger].GetComponent<Animator>().SetBool("walk", true);
        //playerControler[currPassenger].transform.parent.GetComponent<DOTweenAnimation>().DOPlay();
        playerControler[currPassenger].transform.parent.DOLocalMove(Vector3.right * -1.55f, 1f + currPassenger * 0.25f).OnComplete(() => { playerControler[currPassenger].GetComponent<Animator>().SetBool("walk", false); ScaneLuggage(); });
    }

    void ScaneLuggage()
    {
        
        scaner.transform.DOScaleZ(0.95f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        luggage[currPassenger].transform.GetChild(1).gameObject.SetActive(true);
        approvalPanel.SetActive(true);
    }
    public void ApproveLuggage(bool accepted)
    {
        luggage[currPassenger].transform.GetChild(1).gameObject.SetActive(false);
        approvalPanel.SetActive(false);
        Reaction(accepted);
        scaner.transform.DOKill();
        scaner.transform.localScale = new Vector3(1, 1, 0);
    }

    void Reaction(bool approved)
    {
        if (approved)
            playerControler[currPassenger].GetComponent<Animator>().SetTrigger("approved");
        else
            playerControler[currPassenger].GetComponent<Animator>().SetTrigger("rejected");

        
        playerControler[currPassenger].transform.DOMove(endTarget.position, 1f).SetDelay(1f).OnStart(() => { playerControler[currPassenger-1].transform.LookAt(endTarget); playerControler[currPassenger-1].GetComponent<Animator>().SetBool("walk", true); luggage[currPassenger - 1].transform.DOMove(endTarget.position, 1f); }).OnComplete(()=> { NextPassenger(); });

        currPassenger++;

    }
}
