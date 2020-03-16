using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItems : MonoBehaviour
{
    int fireStone;
    int food;
    int trap;
    List<int> key;

    void Start()
    {
        fireStone = 0;
        food = 0;
        trap = 0;
        key = new List<int>();
    }

    void Update()
    {
        
    }

    public void increaseFirestone(int num)
    {
        fireStone += num;
    }

    public void addKey(int index)
    {
        key.Add(index);
    }

    public List<int> getKeys()
    {
        return key;
    }

    public void LostKeys()
    {
        //钥匙被偷了
        key.Clear();
    }
}
