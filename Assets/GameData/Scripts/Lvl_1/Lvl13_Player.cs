using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lvl13_Player : MonoBehaviour
{

    [SerializeField] TextMeshPro speedText, altitudeText;
    [SerializeField] GameObject lvlDescriptionText;
    [SerializeField] GameObject tapToPlay;
    [SerializeField] DragRotate draginput;
    [SerializeField] Vector3 planeMovements;
    [SerializeField] float airPlaneSpeed = 1f;
    [SerializeField] float maxRotationAngle;


    [SerializeField] float altitudeTextMulitplier, speedTextMultiplier = 1f;
    [SerializeField] GameObject Confettie;
    [SerializeField] GameObject sideCam, followCam;

    [SerializeField] GameObject dangerWarning;
    [SerializeField] float dangerDetectionRange;
    [SerializeField] AudioSource enginSound;
    [SerializeField] AudioClip explosionSound;

    [SerializeField] GameObject explosionVFX;
    float speed = 0f;

    bool isCrashed = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke(nameof(DisableDescText), 2f);
    }

    void DisableDescText()
    {
        lvlDescriptionText.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (!isCrashed)
        {
            speed += Time.deltaTime * airPlaneSpeed;
            transform.localEulerAngles = new Vector3(maxRotationAngle * (draginput.rotationAmount - 1), transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.localPosition += transform.forward * speed;

            speedText.text = ((int)(speed * speedTextMultiplier)).ToString();
            altitudeText.text = ((int)(transform.position.y * altitudeTextMulitplier - 6.883f * altitudeTextMulitplier)).ToString() + " FT";

            // Does the ray intersect any objects excluding the player layer
            dangerWarning.SetActive(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, dangerDetectionRange));

        }

    }
    RaycastHit hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("switchCamTrigger"))
        {
            followCam.SetActive(true);
            sideCam.SetActive(false);
        }
        else if (other.name.Contains("CompleteTrigger"))
        {
            //followCam.SetActive(false);
            Confettie.SetActive(true);
            Invoke(nameof(LevelComplete), 2f);
        }
        else if (other.name.Contains("CrashTrigger"))
        {
            followCam.SetActive(false);
            isCrashed = true;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            enginSound.Stop();
            enginSound.PlayOneShot(explosionSound);
            explosionVFX.SetActive(true);
            GameManager.instance.LevelFailed();
        }
    }
    void LevelComplete()
    {
        followCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = null;

        GameManager.instance.LevelComplete();
        enginSound.Stop();
    }

    public void StartLevel(float pSpeed)
    {
        GameManager.instance.GameStart();
        airPlaneSpeed = pSpeed;
        tapToPlay.SetActive(false);
        enginSound.Play();
    }
}
