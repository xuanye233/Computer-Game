using UnityEngine;
using System.Collections;
using Photon.Pun;

public class EffectLife : MonoBehaviourPunCallbacks
{
    private ParticleSystem[] particleSystems;
    bool isDestroyed;

    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        isDestroyed = false;
    }

    void Update()
    {
        bool allStopped = true;
        if (isDestroyed) return;

        foreach (ParticleSystem ps in particleSystems)
        {
            if (!ps.isStopped)
            {
                allStopped = false;
            }
        }

        if (allStopped)
        {
            int viewID = gameObject.GetComponent<PhotonView>().ViewID;
            isDestroyed = true;
            PhotonView.RPC("destroyEffect", RpcTarget.MasterClient, viewID);
        }
    }

    [PunRPC]
    public void destroyEffect(int viewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
    }
}