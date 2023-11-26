using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCard : MonoBehaviour
{
    public List<GameObject> changeCards;

    void Start()
    {
        CloudSave cloudSave = GameObject.Find("CloudSave").GetComponent<CloudSave>();
        cloudSave.LoadData();

        
    }

    public void OnCardChange()
    {
        for (int i = 0; i < changeCards.Count; i++)
        {
            ChangeCard card = changeCards[i].GetComponentInChildren<ChangeCard>();
            card.Carding(GameSystem.Level[i]);
        }
    }
}
