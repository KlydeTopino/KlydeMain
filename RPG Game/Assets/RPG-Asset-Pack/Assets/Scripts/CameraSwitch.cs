using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject CameraFollowPlayer, CameraFollowMonster, CameraFollowNPC;

    public Button Player, Monster, NPC;


    void Start()
    {
        Player.onClick.AddListener(PlayerButtonOnClick);
        Monster.onClick.AddListener(MonsterButtonOnClick);
        NPC.onClick.AddListener(NPCButtonOnClick);
    }

    void PlayerButtonOnClick()
    {
        CameraFollowPlayer.SetActive(true);
        CameraFollowMonster.SetActive(false);
        CameraFollowNPC.SetActive(false);
    }

    void MonsterButtonOnClick()
    {
        CameraFollowPlayer.SetActive(false);
        CameraFollowMonster.SetActive(true);
        CameraFollowNPC.SetActive(false);
    }

    void NPCButtonOnClick()
    {
        CameraFollowPlayer.SetActive(false);
        CameraFollowMonster.SetActive(false);
        CameraFollowNPC.SetActive(true);
    }
}
