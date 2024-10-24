using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl5_manager : MonoBehaviour
{
    [SerializeField] GameObject lvlDescriptionText;
    [SerializeField] Transform fuleNozel;
    [SerializeField] Image fuleBaarMain, fuleFillbaar;
    [SerializeField] float nozelMoveSpeed;

    [SerializeField] Transform nozelSocketPoint;
    [SerializeField] SpriteRenderer nozelTargetimg;
    [SerializeField] float fixableDistance;

    [SerializeField] GameObject nozelVcam, fuling_VCam;

    Vector3 movement;

    bool isAttached = false;
    private void OnEnable()
    {
        Invoke(nameof(DisableDescText), 2f);
    }

    void DisableDescText()
    {
        lvlDescriptionText.SetActive(false);
    }
    public void DrageNozel()
    {
        if (isAttached)
            return;

        movement = fuleNozel.position;
        movement.z += Input.GetAxis("Mouse X") * nozelMoveSpeed;
        movement.y += Input.GetAxis("Mouse Y") * nozelMoveSpeed;

        //movement.x = Mathf.Clamp(movement.x,);

        fuleNozel.position = movement;


        if (Vector3.Distance(nozelTargetimg.transform.position, nozelSocketPoint.position) > fixableDistance)
            nozelTargetimg.color = Color.red;
        else
        {
            nozelTargetimg.color = Color.green;
            NozelAttach();
        }
    }

    bool canFill = false;
    public void StartFillingFule()
    {
        canFill = true;
        fuleBaarMain.GetComponent<Animator>().SetBool("isfilling",true);

    }
    public void StopFillingFule()
    {
        canFill = false;
        fuleBaarMain.GetComponent<Animator>().SetBool("isfilling", false);


    }

    public void NozelAttach()
    {
        isAttached = true;
        fuleNozel.DOLocalMove(new Vector3(-1.171f, 0.285f, 2.09f), 2f);
        fuling_VCam.SetActive(true);
        nozelVcam.SetActive(false);

        fuleBaarMain.transform.parent.gameObject.SetActive(true);
        StartCoroutine("FillFule");
    }

    IEnumerator FillFule()
    {

        while (fuleFillbaar.fillAmount < 1)
        {
            if (canFill)
                fuleFillbaar.fillAmount += 0.015f;
            yield return new WaitForSeconds(0.15f);

        }
        yield return new WaitForSeconds(1f);
        GameManager.instance.LevelComplete();

    }
}
