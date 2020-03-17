using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    //[SerializeField] GameObject healthUI; //show the current health
    float health; //Character HP
    CharacterItems items;

    void Start()
    {
        items = GetComponent<CharacterItems>();
        health = 50f;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            //碰到食物后增加一些体力
            /*------------------------*/
            //IncreaseHealth(10f);
            //healthUI.GetComponent<IncreaseHealth>().increaseScore(10);
            Debug.Log("体力增加了");
            other.gameObject.SetActive(false);
        }

#if false
        else if (other.gameObject.CompareTag("Sewage"))
        {
            //碰到污水减少体力
            //------------------------
            //DecreaseHealth(10f)
            //healthUI.GetComponent<DecreaseHealth>().decreaseScore(10);
            Debug.Log("碰到污水体力减少");
        }

        else if (other.gameObject.CompareTag("Mice"))
        {
            //碰到鼠群减少体力
            //-------------------------
            //DecreaseHealth(10f)
            //healthUI.GetComponent<DecreaseHealth>().decreaseScore(10);
            Debug.Log("碰到老鼠群体力减少");
        }

        else if (other.gameObject.CompareTag("Key"))
        {
            //碰到钥匙后增加钥匙（不是碰到就能捡起来，应该还要加一些交互操作
            //-----------------------------
            int index = -1;
            //index=other的钥匙index值
            items.addKey(index);
            Debug.Log("捡到了钥匙" + index);
        }

        else if (other.gameObject.CompareTag("Firestone"))
        {
            //捡到打火石，需要补充交互操作
            //-----------------------------
            items.increaseFirestone(1);
            Debug.Log("捡到一个打火石");
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            //偷钥匙？？
            //加一些玩家交互操作---------------------------------
            //-----------------------------
            //偷钥匙成功
            List<int> oppKeys = other.GetComponent<CharacterItems>().getKeys();
            for (int i = 0; i < oppKeys.Count; i++)
            {
                items.addKey(oppKeys[i]);
            }

        }

        else if (other.gameObject.CompareTag("Door"))
        {
            //开门
            int index = 0;
            //index = 门的index
            if (items.getKeys().Contains(index))
            {
                Debug.Log("开门成功");
            }
            else
            {
                Debug.Log("你没有符合条件的钥匙");
            }
        }
#endif
    }

    public void ChangeHealth(float increaseNum)
    {
        health = health + increaseNum > 100 ? 100 : health + increaseNum;
        if(health < 0)
        {
            health = 0;
        }
    }


    public float GetHealth()
    {
        return health;
    }
}
