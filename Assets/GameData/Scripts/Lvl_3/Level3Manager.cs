using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] Transform boardingBridgeContainer;
    [SerializeField] Transform moveableBridge;
    [SerializeField] GameObject vCam1,vCam2;
    [SerializeField] GameObject target;
    [SerializeField] GameObject lvl_3DUI, confettie;

    [SerializeField] float maxrotation;
    [SerializeField] float maxMovement;
    [SerializeField] float controleSpeed;
    [SerializeField] DragRotate verticaControle, horzontalControle;
    // Start is called before the first frame update
    void Start()
    {
        eurlarAngles = boardingBridgeContainer.localEulerAngles;
        loacalPosition = moveableBridge.localPosition;
        GameManager.instance.GameStart();
        //horzontalControle.rotationAmount = -1f;
        Invoke(nameof(transition),0.5f);
        eurlarAngles.z = Mathf.Clamp(eurlarAngles.z + (maxrotation * -15 * controleSpeed), -maxrotation, maxrotation);
        boardingBridgeContainer.localEulerAngles = eurlarAngles;
    }

    void transition()
    {
        vCam1.SetActive(false);
        vCam2.SetActive(true);
    }
    // Update is called once per frame
    Vector3 eurlarAngles = new Vector3();
    Vector3 loacalPosition = new Vector3();
    Vector3 targetLoacalPosition = new Vector3();

    bool lvlComplete = false;
    void FixedUpdate()
    {
        if (lvlComplete)
            return;
        //loacalPosition.x = Mathf.Clamp((maxMovement * (verticaControle.rotationAmount)), 0f, 0.015f);
        loacalPosition.x = Mathf.Clamp((loacalPosition.x + (maxMovement * verticaControle.rotationAmount) * controleSpeed), -maxMovement, maxMovement);
        moveableBridge.localPosition = loacalPosition;

        eurlarAngles.z = Mathf.Clamp(eurlarAngles.z + (maxrotation * horzontalControle.rotationAmount * controleSpeed), -maxrotation, maxrotation);
        boardingBridgeContainer.localEulerAngles = eurlarAngles;


        if (eurlarAngles.z < 1f && eurlarAngles.z > -1f)
            target.GetComponent<SpriteRenderer>().color = Color.green;
        else
            target.GetComponent<SpriteRenderer>().color = Color.red;

        if (target.GetComponent<SpriteRenderer>().color == Color.green && moveableBridge.localPosition.x == maxMovement)
        {
            confettie.SetActive(true);
            GameManager.instance.LevelComplete();
            lvlComplete = true;
            lvl_3DUI.SetActive(false);
        }
        //Debug.Log("LevelComplete!");
    }
}
