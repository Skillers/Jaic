using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyConverter : MonoBehaviour {
    public Statistics stats;
    public float numberOfZero;
    public float money;
    public Text moneyText;

	
	// Update is called once per frame
	void Update () {

        money = stats.money;
        numberOfZero = stats.moneyZeros;
        if(numberOfZero == 0)
        {
            moneyText.text = "$"+ money + "" ;
        }
        else {
            moneyText.text = "$" + money + "E+" + numberOfZero;
        }
            
    }
}
