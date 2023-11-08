using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public byte stage = 1;
    public int health = 3;

    public List<GameObject> objectToSwap;

    public TextMeshProUGUI stageText;

    public TabGroup tabGroup;

    public GameObject losePanel;
    public GameObject audio;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Start()
    {
        if (!tabGroup)
            tabGroup = GameObject.Find("TabGroup").GetComponent<TabGroup>();
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
                audio.SetActive(false);
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
        

    }
}
