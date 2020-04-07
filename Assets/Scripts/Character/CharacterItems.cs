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
    int BlindDrug;
    int Teleportation;
    int StumblingBlock;
    int ThunderstormStone;
    List<int> key;

    int JewelThief;//jewelthief的数量
    int jewel;//后续改成list，现在先用单个测试

    void Start()
    {
        fireStone = 100;
        food = 6;
        trap = 6;
        OriginStone = 5;
        StumblingBolack = 5;
        FixPotion = 5;
        BlindDrug = 5;
        Teleportation = 5;
        StumblingBlock = 5;
        ThunderstormStone = 5;

        JewelThief = 5;
        jewel = 5;
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

    public int getBlindDrug()
    {
        return BlindDrug;
    }

    public int getTeleportation()
    {
        return Teleportation;
    }

    public int getStumblingBlock()
    {
        return StumblingBlock;
    }

    public int getThunderstormStone()
    {
        return ThunderstormStone;
    }

    public int getJewelThief()//新增
    {
        return JewelThief;
    }

    public int getJewel()//新增
    {
        return jewel;
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

    public void changeBlindDrug(int num)
    {
        BlindDrug += num;
    }

    public void changeTeleportation(int num)
    {
        Teleportation += num;
    }

    public void changeStumblingBlock(int num)
    {
        StumblingBlock += num;
    }

    public void changeThunderstormStone(int num)
    {
        ThunderstormStone += num;
    }

    public void changeJewelThief(int num)//新增
    {
        JewelThief += num;
    }

    public void changeJewel(int num)//新增
    {
        jewel += num;
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
