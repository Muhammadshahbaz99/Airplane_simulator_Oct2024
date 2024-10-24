using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject MainCamera;

    [SerializeField] GameObject confettieParticals;
    public GameObject[] levels;
    public int[] levelRewards;

    public MainUi_Controller uiManager;

    public int startLvl = 0;


    public static int lvlNo = 1;

    private void OnEnable()
    {
        instance = this;

        if (startLvl > 0)
            lvlNo = startLvl;
        else
            lvlNo = PlayerPrefs.GetInt("LevelNo", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (lvlNo < levels.Length)
            levels[lvlNo - 1].SetActive(true);
        else
            levels[Random.Range(1, levels.Length-1)].SetActive(true);
    }

    public int GetLevelReward()
    {
        return levelRewards[lvlNo - 1];
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        uiManager.GameStart();
    }
    public void LevelComplete()
    {
        PlayerPrefs.SetInt("LevelNo", lvlNo + 1);
        uiManager.LevelComplete();
        confettieParticals.SetActive(true);
    }
    public void LevelFailed()
    {
        uiManager.LevelFailed();
    }
}
