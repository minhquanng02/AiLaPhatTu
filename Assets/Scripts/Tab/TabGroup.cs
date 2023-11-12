using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    protected TabButton selectedTab;
    public List<TabButton> tabButtons;
    public List<GameObject> objectToSwap;
    public Transform spawnParent;

    public static int levelIndex;

    public GameObject homeAudio;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
    }
    public void OnTabExit(TabButton button)
    {
    }
    public virtual void OnTabSelected(TabButton button)
    {
        selectedTab = button;

        if (homeAudio != null)
        {
            AudioSource audio = homeAudio.GetComponent<AudioSource>();
            audio.enabled = false;
        }

        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectToSwap.Count; i++)
        {
            if (i == index)
            {
                //objectToSwap[i].SetActive(true);
                CreateLevel(i);

                levelIndex = i;
            }
            else
            {
                //objectToSwap[i].SetActive(false);
            }

            
        }

    } 

    public void CreateLevel(int levelIndex)
    {
        GameObject level = Instantiate(objectToSwap[levelIndex], transform.position, transform.rotation);

        level.transform.SetParent(spawnParent);

        RectTransform rect = level.GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0, 0);
        rect.offsetMin = new Vector2(0, 0);
        rect.localScale = new Vector3(1, 1, 1);
    }
}
