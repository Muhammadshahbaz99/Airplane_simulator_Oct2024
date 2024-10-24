using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingPanel : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI loadingPercentage;
    [SerializeField] Image loadingFillBaar;
    [SerializeField] float timeDecided = 3f;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Load_SceneAysinc());
    }
    float loadingTime = 0f;
    IEnumerator Load_SceneAysinc()
    {

        yield return new WaitForSeconds(1f);
        //AsyncOperation op = SceneManager.LoadSceneAsync("GamePlay");

        while (loadingTime <timeDecided)
        {
            yield return new WaitForSeconds(0.05f);
            loadingPercentage.text = ((loadingTime/timeDecided)*100).ToString("00") + "%";
            loadingFillBaar.fillAmount = loadingTime / timeDecided;

            loadingTime += 0.05f;
        }

        SceneManager.LoadScene("GamePlay");
    }


}
