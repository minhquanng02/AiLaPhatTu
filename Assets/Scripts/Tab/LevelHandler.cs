using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class LevelHandler : MonoBehaviour
{
    public byte stage = 1;
    public int health = 3;

    public List<GameObject> objectToSwap;

    public TextMeshProUGUI stageText;

    public TabGroup tabGroup;
    public CloudSave cloudSave;

    public GameObject losePanel;
    public GameObject bgAudio;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject homeAudio;
    public GameObject menuUI;

    private void Start()
    {
        if (!tabGroup)
            tabGroup = GameObject.Find("TabGroup").GetComponent<TabGroup>();
        if (!homeAudio)
            homeAudio = GameObject.Find("HomeAudio");
        if (!menuUI)
            menuUI = GameObject.Find("MenuUI");
        if (!cloudSave)
            cloudSave = GameObject.Find("CloudSave").GetComponent<CloudSave>();
    }

    public void NextStage()
    {
        stage++;

        if (stage <= 10)
            stageText.text = stage.ToString() + "/10";
        else stageText.gameObject.SetActive(false);

        SwapQuiz();
    }

    public void DestroyLevel()
    {
        Destroy(transform.gameObject);

        AudioSource audio = homeAudio.GetComponent<AudioSource>();
        audio.enabled = true;

        Victory();

    }

    public void Replay()
    {
        DestroyLevel();

        tabGroup.CreateLevel(TabGroup.levelIndex);
    }

    public void SwapQuiz()
    {
        int index = transform.GetSiblingIndex();

        for (int i = 1; i <= objectToSwap.Count; i++)
        {
            if (i == stage)
            {
                objectToSwap[i-1].SetActive(true);
            }
            else
            {
                objectToSwap[i-1].SetActive(false);
            }
        }

    }

    public void SetHealth()
    {
        switch (health)
        {
            case 2:
                heart3.SetActive(false);
                break;
            case 1:
                heart2.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);
                bgAudio.SetActive(false);
                losePanel.SetActive(true);
                break;
        }
    }

    public void LevelComplete()
    {
       if (!GameSystem.Level[TabGroup.levelIndex])
            GameSystem.Level[TabGroup.levelIndex] = true;

        TabButton tabBtn = tabGroup.tabButtons[TabGroup.levelIndex];
        
        ChangeCard changeCard = tabBtn.GetComponent<ChangeCard>();
             
        changeCard.Carding(GameSystem.Level[TabGroup.levelIndex]);

        cloudSave.SaveData(TabGroup.levelIndex);

    }

    public void Victory()
    {
        if (GameSystem.Level.All(x => x))
        {
            if (GameSystem.victory == false)
            {
                GameSystem.victory = true;
                menuUI.SetActive(false);
            }

        }
        

    }
}
