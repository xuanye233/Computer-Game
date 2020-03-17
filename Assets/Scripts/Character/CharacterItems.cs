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
        food = 6;
        trap = 6;
        key = new List<int>();
    }

    void Update()
    {
        
    }

    public int getFood()
    {
        return food;
    }

    public int getTrap()
    {
        return trap;
    }

    public void changeFirestone(int num)
    {
        fireStone += num;
    }

    public void changeFood(int num)
    {
        food += num;
    }

    public void changeTrap(int num)
    {
        trap += num;
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
