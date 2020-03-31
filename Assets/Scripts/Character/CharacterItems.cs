using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItems : MonoBehaviour
{
    int fireStone;
    int food;
    int trap;
    int OriginStone;
    int StumblingBolack;
    int FixPotion;
    List<int> key;

    void Start()
    {
        fireStone = 100;
        food = 6;
        trap = 6;
        OriginStone = 5;
        StumblingBolack = 5;
        FixPotion = 5;
        key = new List<int>();
    }

    void Update()
    {
        
    }
    public int getOriginStone()
    {
        return OriginStone;
    }

    public int getFixPotion()
    {
        return FixPotion;
    }

    public int getStumblingBolack()
    {
        return StumblingBolack;
    }

    public int getFood()
    {
        return food;
    }

    public int getTrap()
    {
        return trap;
    }

    public int getFireStone()
    {
        return fireStone;
    }

    public void changeFireStone(int num)
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

    public void changeOriginStone(int num)
    {
        OriginStone += num;
    }

    public void changeStumblingBolack(int num)
    {
        StumblingBolack += num;
    }

    public void changeFixPotion(int num)
    {
        FixPotion += num;
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
