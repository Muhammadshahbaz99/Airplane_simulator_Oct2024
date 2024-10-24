using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4_Manager : MonoBehaviour
{
    [SerializeField] GameObject DescriptionText;
    public GameObject rccCanvas;
    [SerializeField] Animator luggageAnimator;

    [SerializeField] Transform t1, t2,troly1,troly2;
    private void OnEnable()
    {
        luggageAnimator.speed = 0;
        Invoke(nameof(DisableDescription), 2f);
    }
    private void DisableDescription()
    {
        DescriptionText.SetActive(false);
    }
    public void SetAnimatorSpeed(float s)
    {

        luggageAnimator.speed = s;
    }

    public void DisableRigidBodiesForLugage() {

        //foreach (Rigidbody a in t1.GetComponentsInChildren<Rigidbody>())
        //{
        //    a.drag = 1;
        //    //Destroy(a);
        //}

        //foreach (Rigidbody a in t2.GetComponentsInChildren<Rigidbody>())
        //{
        //    a.drag = 1;

        //    //Destroy(a);
        //}
    }
}
