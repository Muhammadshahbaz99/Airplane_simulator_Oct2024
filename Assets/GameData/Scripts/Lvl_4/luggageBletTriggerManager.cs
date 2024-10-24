using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luggageBletTriggerManager : MonoBehaviour
{
    public Animator trollyanim;
    [SerializeField] AudioSource bagPickSound;
    [SerializeField] AudioClip bagPicSound;
    private void OnEnable()
    {
        trollyanim.Play("LuggageLvl");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Luaggage"))
        {

            trollyanim.Play("New State");

        other.transform.parent = this.transform.parent;
            bagPickSound.PlayOneShot(bagPicSound);
        }
    }
}
