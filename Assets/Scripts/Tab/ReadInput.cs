using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadInput : MonoBehaviour
{
    public TextMeshProUGUI inputName;
    public TextMeshProUGUI textName;

    private void Start()
    {
        textName.text = GameSystem.babyName;
    }

    public void ReadName()
    {
        GameSystem.babyName = inputName.text;
    }
}
