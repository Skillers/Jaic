using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountChanger : MonoBehaviour {
    public float currentAmount = 1;
    public GameObject oneImage;
    public GameObject tenImage;
    public GameObject fiftyImage;
    public GameObject hunderdImage;
    public GameObject maxImage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OneTime() {
        currentAmount = 1;
        oneImage.GetComponent<Image>().color = new Color32(30, 255, 0, 255);
        tenImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        fiftyImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        hunderdImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        maxImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);

    }
    public void TenTimes() {
        currentAmount = 10;
        oneImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        tenImage.GetComponent<Image>().color = new Color32(30, 255, 0, 255);
        fiftyImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        hunderdImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        maxImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
    }
    public void FiftyTimes() {
        currentAmount = 50;
        oneImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        tenImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        fiftyImage.GetComponent<Image>().color = new Color32(30, 255, 0, 255);
        hunderdImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        maxImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
    }
    public void HunderdTimeS() {
        currentAmount = 100;
        oneImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        tenImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        fiftyImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        hunderdImage.GetComponent<Image>().color = new Color32(30, 255, 0, 255);
        maxImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
    }
    public void MaxTimes() {
        currentAmount = 0;
        oneImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        tenImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        fiftyImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        hunderdImage.GetComponent<Image>().color = new Color32(165, 165, 165, 255);
        maxImage.GetComponent<Image>().color = new Color32(30, 255, 0, 255);
    }
}
