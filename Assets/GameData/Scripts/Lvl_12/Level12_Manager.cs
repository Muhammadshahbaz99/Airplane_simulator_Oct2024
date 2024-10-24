using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12_Manager : MonoBehaviour
{
    [SerializeField] GameObject lvlDescriptionText;

    [SerializeField] GameObject[] passengers;

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
            yield return new WaitForSeconds(0.5f);
        }
        LevelComplete();
        //Debug.LogError("Passengers Done all");

    }

    public void LevelComplete()
    {
        GameManager.instance.LevelComplete();
    }

}
