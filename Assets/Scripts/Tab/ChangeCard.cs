using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCard : MonoBehaviour
{
    public GameObject NomalCard, CompleteCard;
    
    public void Carding(bool levelDone)
    {
        if (levelDone)
        {
            CompleteCard.SetActive(true);
            NomalCard.SetActive(false);
        }
        else
        {
            CompleteCard.SetActive(false);
            NomalCard.SetActive(true);
        }
    }
}
