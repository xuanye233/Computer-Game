using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class NameSetButton : MonoBehaviourPunCallbacks
{
    public InputField inputField;
    Button setNameButton;
    [SerializeField]
    GameObject playerNameobj;
    [SerializeField]
    GameObject roomNameobj;

    string nameText;
    void Start()
    {
        if (inputField == null)
            inputField = GameObject.Find("SetNameInput").GetComponent<InputField>();
        setNameButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length == 0)
            setNameButton.interactable = false;
        else
            setNameButton.interactable = true;
    }

    public void NameClick()
    {
        GlobalData.playerName = inputField.text;
        PhotonNetwork.NickName = GlobalData.playerName;
        playerNameobj.SetActive(false);
        roomNameobj.SetActive(true);
    }
}
