using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUi_Controller : MonoBehaviour
{
    [SerializeField] GameObject mainUI, levelCompletePanel, lvlFailPanel,LoadingScreen;
    [SerializeField] GameObject[] levelsUi;
    public GameObject animationCash;

    [SerializeField] Text levelNumberTxt,scoreTxt,lvlRewardText,lvl_3xRewardText;


    [SerializeField] AudioClip cashSFX;
    // Start is called before the first frame update
    void Start()
    {
        levelsUi[GameManager.lvlNo - 1].SetActive(true);
        scoreTxt.text = PlayerPrefs.GetInt("score", 100).ToString();

        lvlRewardText.text = GameManager.instance.GetLevelReward().ToString();
        lvl_3xRewardText.text = (GameManager.instance.GetLevelReward()*2).ToString();
        levelNumberTxt.text = "LEVEL " + GameManager.lvlNo;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        mainUI.SetActive(false);
    }
    public void LevelComplete()
    {
        DisableGameplayUI();
        Invoke(nameof(ShowLevelCompletePanel), 1f);
    }
    private void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
        //Debug.LogError("LvlComplete");

    }
    public void LevelFailed()
    {
        DisableGameplayUI();
        Invoke(nameof(ShowLevelFailPanel), 0.5f);
    }
    private void ShowLevelFailPanel()
    {
        lvlFailPanel.SetActive(true);
    }

    void DisableGameplayUI()
    {
        levelsUi[GameManager.lvlNo - 1].SetActive(false);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelNo", GameManager.lvlNo + 1);
        //SceneManager.LoadScene("GamePlay");
        GameManager.instance.uiManager.LoadingScreen.SetActive(true);
    }
    public void RestartLevel()
    {
        //SceneManager.LoadScene("GamePlay");
        GameManager.instance.uiManager.LoadingScreen.SetActive(true);

    }
    public void CashAnimation()
    {

    }
    public void Claim_2xScore()
    {
        StartCoroutine(AnimateCash(GameManager.instance.GetLevelReward()*2));

    }
    public void ClaimScore()
    {
        StartCoroutine(AnimateCash(GameManager.instance.GetLevelReward()));
    }
    IEnumerator AnimateCash(int cash)
    {
        int score = PlayerPrefs.GetInt("score", 100);

        SoundManager.instance.PlayOnShot(cashSFX);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(animationCash, mainUI.transform.parent);
            //score = score + 20 * (i + 1);
            scoreTxt.text = (score + 20 * (i + 1)).ToString();

            yield return new WaitForSeconds(0.05f);
        }
        PlayerPrefs.SetInt("score", score + cash);
        scoreTxt.text = (score + cash).ToString();
        yield return new WaitForSeconds(2f);

        //SceneManager.LoadScene("GamePlay");
        GameManager.instance.uiManager.LoadingScreen.SetActive(true);

        //multiplayierPanel.SetActive(true);
        //GameManager.Instance.LevelComplete();

    }
}
