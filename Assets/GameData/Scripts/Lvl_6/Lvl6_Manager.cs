using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl6_Manager : MonoBehaviour
{
    [SerializeField] GameObject lvlDescriptionText,vCam1, vCam2;
    [SerializeField] GameObject dummyBuss,rccBuss,rccCanvas,rccCam;

    [SerializeField] GameObject[] passengers,leavingPassegers;

    int curIndex = 0;

    float remainingTime = 10;

    private void OnEnable()
    {
        Invoke(nameof(DisableDescText), 2f);
    }

    void DisableDescText()
    {
        lvlDescriptionText.SetActive(false);
    }
    public void StartNext()
    {
        if (!loadingStart)
            StartCoroutine(SetPassengers());

        cansetPassnegers = true;
    }
    public void StopNext()
    {
        cansetPassnegers = false;
    }

    bool cansetPassnegers, loadingStart = false;

    IEnumerator SetPassengers()
    {
        loadingStart = true;
        yield return new WaitForSeconds(1f);

        while (curIndex < passengers.Length)
        {
            if (cansetPassnegers)
            {
                passengers[curIndex].GetComponent<Animator>().Play("Walking");
                passengers[curIndex].GetComponent<DOTweenPath>().DOPlay();

                passengers[curIndex + 1].GetComponent<Animator>().Play("Walking");
                passengers[curIndex + 1].GetComponent<DOTweenPath>().DOPlay();

                curIndex += 2;
                //Debug.LogError("Passengers Done"+ curIndex);
            }
            yield return new WaitForSeconds(2.5f);
        }
        StartBussToTravall();
        //Debug.LogError("Passengers Done all");

    }

    IEnumerator _DropPassengers()
    {
        yield return new WaitForSeconds(1f);
        curIndex = 0;
        while (curIndex < passengers.Length)
        {

            leavingPassegers[curIndex].GetComponent<Animator>().Play("Walking");
            leavingPassegers[curIndex].GetComponent<DOTweenPath>().DOPlay();

            leavingPassegers[curIndex + 1].GetComponent<Animator>().Play("Walking");
            leavingPassegers[curIndex + 1].GetComponent<DOTweenPath>().DOPlay();

                curIndex += 2;
                //Debug.LogError("Passengers Done"+ curIndex);
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.LogError("Passengers Done all");
        GameManager.instance.LevelComplete();

    }

    public void DropPassengers()
    {
        StartCoroutine(_DropPassengers());
    }
    public void StartBussToTravall()
    {
        rccBuss.SetActive(true);
        rccCam.SetActive(true);
        rccCanvas.SetActive(true);

        vCam1.SetActive(false);
        dummyBuss.SetActive(false);
    }
}
