using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour{

    SaveGame juicSave;
    public float clickPower = 2;
    public float cycleTime = 10;
    public float money = 0;
    public float moneyZeros = 0;

    public void Start()
    {
        juicSave = new SaveGame(); 
    }

    public void Update()
    {   
        
        if (moneyZeros == 0 && money < 1000000)
        {

        }
        else
        { 
            while (money >= 1000)
            {
                money /= 1000;
                moneyZeros += 3;
            }
            while (money < 1 && money > 0 && moneyZeros > 0)
            {
                money *= 1000;
                moneyZeros -= 3;

            }
        }
        money = Mathf.Round(money * 100f) / 100f;
    }

    public void addMoney(float moneyAmount, float moneyZerosInput)
    {
        while(moneyZerosInput < moneyZeros)
        {
            moneyAmount /= 1000;
            moneyZerosInput += 3;
        }
        money += moneyAmount;
    }

    public void SaveSomething()
    {
        juicSave.clickPower = clickPower;
        Debug.Log(SaveGameSystem.SaveGame(juicSave));
    }
    public void LoadSomething() {
        juicSave = SaveGameSystem.LoadGame();
        clickPower = juicSave.clickPower;

    }

    public void LetItRain()
    {
        addMoney(100000,0);
    }
}
