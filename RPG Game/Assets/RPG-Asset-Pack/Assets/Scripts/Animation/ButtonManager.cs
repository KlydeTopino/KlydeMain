using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{

    public GameObject[] PlayerButtons;
    public GameObject[] MonsterButtons;
    public GameObject[] NPCButtons;

    public void PlayerButtonClicked()
    {
        foreach (var obj in PlayerButtons)
        {
            obj.SetActive(true);
        }

        foreach (var obj in MonsterButtons)
        {
            obj.SetActive(false);
        }

        foreach (var obj in NPCButtons)
        {
            obj.SetActive(false);
        }
    }

    public void MonsterButtonClicked()
    {
        foreach (var obj in PlayerButtons)
        {
            obj.SetActive(false);
        }

        foreach (var obj in MonsterButtons)
        {
            obj.SetActive(true);
        }

        foreach (var obj in NPCButtons)
        {
            obj.SetActive(false);
        }
    }

    public void NPCButtonClicked()
    {
        foreach (var obj in PlayerButtons)
        {
            obj.SetActive(false);
        }

        foreach (var obj in MonsterButtons)
        {
            obj.SetActive(false);
        }

        foreach (var obj in NPCButtons)
        {
            obj.SetActive(true);
        }
    }
}
