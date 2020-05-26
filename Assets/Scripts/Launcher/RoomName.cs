using Com.MyCompany.MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomName : MonoBehaviour
{
    [SerializeField]
    InputField inputField;
    [SerializeField]
    LauncherTest launcherTest;
    [SerializeField]
    Button setNameButton;

    void Update()
    {
        if (inputField.text.Length == 0)
            setNameButton.interactable = false;
        else
            setNameButton.interactable = true;
    }

    public void onClicked()
    {
        //修改房间名
        launcherTest.roomName = inputField.text;
        Debug.Log(launcherTest.roomName);
    }
}
