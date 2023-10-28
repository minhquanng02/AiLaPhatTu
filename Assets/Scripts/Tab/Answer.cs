using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : TabGroup
{
    public Quiz quiz;
    public GameObject nextButton;
    public GameObject panel;
    public LevelHandler lvl;

    public override void OnTabSelected(TabButton button)
    {
        selectedTab = button;

        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < objectToSwap.Count; i++)
        {
            if (i == index || i == quiz.answer)
            {
                objectToSwap[i].SetActive(true);

                if (i == index && i != quiz.answer)
                {
                    objectToSwap[i].transform.GetChild(3).gameObject.SetActive(true);    
                    lvl.health--;
                    lvl.SetHealth();
                }
            }
            else
            {
                objectToSwap[i].SetActive(false);
            }
        }

        //Debug.Log(LevelHandler.health);

        nextButton.SetActive(true);
        panel.SetActive(true);
    } 
}
