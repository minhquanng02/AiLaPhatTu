using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;
using UnityEngine.UI;
using Unity.Services.Core;

public class CloudSave : MonoBehaviour
{
    public async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    public async void SaveData(int level)
    {
        var data = new Dictionary<string, object> { { "Level" + level.ToString(), true.ToString() } };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }


    public async void LoadData()
    {
        for (int i = 0; i < 20; i++)
        {
            string y = i.ToString();
            Dictionary<string, string> serverData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { "Level" + y });

            if (serverData.ContainsKey("Level" + y))
            {
                GameSystem.Level[i] = bool.Parse(serverData["Level" + y]);
                //Debug.Log(y + " " + GameSystem.Level[i]);
            }
            /*else
            {
                print("Key not found!!");
            }*/
        }

        MenuCard card = GameObject.Find("MenuUI").GetComponent<MenuCard>();
        card.OnCardChange();
    }
}