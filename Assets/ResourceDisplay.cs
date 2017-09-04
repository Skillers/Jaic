using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour {

    public AmountChanger currentSetting;
    public Statistics stats;
    private GameObject Resource;
    float tempLVLCost;
    float tempZeroToLVLCost;
    float tempi;


    void Update () {
        transform.GetChild(0).GetComponent<Text>().text = Resource.GetComponent<ResourceHandler>().resourceName + " : LvL " + Resource.GetComponent<ResourceHandler>().lvl;
        transform.GetChild(1).GetComponent<Text>().text = "Stored : "+ Resource.GetComponent<ResourceHandler>().stored + "";
        transform.GetChild(2).GetChild(1).GetComponent<Image>().fillAmount =  Resource.GetComponent<ResourceHandler>().progressResourceValue;
        if(currentSetting.currentAmount != 0) { 
        
                tempLVLCost = Resource.GetComponent<ResourceHandler>().currentLvlCost;
                for (int i = 1; i < currentSetting.currentAmount; i++)
                {
                    tempLVLCost += (float)(Resource.GetComponent<ResourceHandler>().currentLvlCost * (Math.Pow(Resource.GetComponent<ResourceHandler>().priceFactor, i)));
                }
                tempLVLCost = Mathf.Round(tempLVLCost * 100f) / 100f;
                tempZeroToLVLCost = Resource.GetComponent<ResourceHandler>().currentZeroToLvlCost;
                if (tempZeroToLVLCost == 0 && tempLVLCost < 1000000)
                {
                    tempLVLCost = Mathf.Round(tempLVLCost * 100f) / 100f;
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Upgrade:\n$" + tempLVLCost + "\nfor "+ currentSetting.currentAmount + "lvls";
                }
                else
                {
                    while (tempLVLCost >= 1000)
                    {
                        tempLVLCost /= 1000;
                        tempZeroToLVLCost += 3;
                    }
                    tempLVLCost = Mathf.Round(tempLVLCost * 100f) / 100f;
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Upgrade:\n$" + tempLVLCost + "E+" + tempZeroToLVLCost + "\nfor 100lvl";
                }
            }

        if (currentSetting.currentAmount == 0)
        {
            tempLVLCost = 0;
            tempi = 1;
            while (tempLVLCost + (float)(Resource.GetComponent<ResourceHandler>().currentLvlCost * (Math.Pow(Resource.GetComponent<ResourceHandler>().priceFactor, tempi))) < stats.money * Math.Pow(10, stats.moneyZeros))
            {

                tempLVLCost += (float)(Resource.GetComponent<ResourceHandler>().currentLvlCost * (Math.Pow(Resource.GetComponent<ResourceHandler>().priceFactor, tempi)));
                tempi++;

            }

            tempZeroToLVLCost = Resource.GetComponent<ResourceHandler>().currentZeroToLvlCost;
            if (tempZeroToLVLCost == 0 && tempLVLCost < 1000000)
            {
                tempLVLCost = Mathf.Round(tempLVLCost * 100f) / 100f;
                transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Upgrade:\n$" + tempLVLCost + "\nfor"+tempi+"lvls";
            }
            else
            {
                while (tempLVLCost >= 1000)
                {
                    tempLVLCost /= 1000;
                    tempZeroToLVLCost += 3;
                }
                tempLVLCost = Mathf.Round(tempLVLCost * 100f) / 100f;
                transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Upgrade:\n$" + tempLVLCost + "E+" + tempZeroToLVLCost + "\nfor "+tempi+"lvl";
            }

        }

    }

    public void AssignResource (GameObject givenResource)
    {
        Resource = givenResource;
    }

    public void ProgressResource()
    {
        Resource.GetComponent<ResourceHandler>().progressResourceValue += (stats.clickPower * stats.cycleTime/100)/stats.cycleTime; 
    }

    public void Upgrade()
    {
        float balancedTempLVLCost = tempLVLCost;
        float balancedtempZeroToLVLCost = tempZeroToLVLCost;
        while(balancedtempZeroToLVLCost != stats.moneyZeros)
        {
            balancedTempLVLCost /= 1000;
            balancedtempZeroToLVLCost += 3;
        }

        if (stats.money >= balancedTempLVLCost) {
            if (currentSetting.currentAmount != 0)
            {
                stats.money -= balancedTempLVLCost;
                Resource.GetComponent<ResourceHandler>().GetUpgraded((int)currentSetting.currentAmount);


            }
            else
            {
                stats.money -= balancedTempLVLCost;
                Resource.GetComponent<ResourceHandler>().GetUpgraded((int)tempi);
            }
        }
    }
    
}
