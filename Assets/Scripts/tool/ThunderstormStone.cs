using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThunderstormStone : MonoBehaviourPunCallbacks
{
    void exposure()
    {
        PhotonNetwork.Instantiate("PlayerCube", GameObject.Find("MapCamera/PlayerCube").transform.position, Quaternion.identity, 0);

    }

    IEnumerator Wait(float waitTime, int ViewID)
    {
        yield return new WaitForSeconds(waitTime);
        PhotonView.Find(ViewID).GetComponent<ThirdPersonUserControl>().canMove = true;
        //等待之后执行的动作
    }
}
