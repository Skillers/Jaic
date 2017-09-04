using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour {

    private bool dragged = false;
    public Statistics stats;
    public GameObject resourceInfo;
    public Image progressResource;

    // stats
    public float progressResourceValue;
    public string resourceName = "Wood";
    public int lvl = 1;
    public int stored = 0;
    public float currentLvlCost;
    public float currentZeroToLvlCost;
    public float priceFactor;
    public float SellPrice;

    void Start()
    {
        stored = 0;
        lvl = 1;
        currentZeroToLvlCost = 0;

    }

    void Update () {
        if(progressResourceValue >= 1) {
            stored += lvl * 1;
            progressResourceValue = 0;

        }
        progressResourceValue += (1f/ stats.cycleTime)*Time.deltaTime ;
        progressResource.fillAmount = progressResourceValue;
    }

    public void OnDrag(BaseEventData data)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            dragged = true;
            this.transform.position = new Vector3(((int)hit.point.x/25)*25, ((int)hit.point.y / 25) * 25, this.transform.position.z);
        }
    }

    public void openResourceInfo ()
    {
        if (!dragged)
        {
            resourceInfo.GetComponent<ResourceDisplay>().AssignResource(this.gameObject);
            resourceInfo.SetActive(true);
        }
        dragged = false;
    }

    public void GetUpgraded(float AmountOfLvls)
    {
        
        int startLevel = lvl;
        while (lvl < startLevel+AmountOfLvls)
        {
            lvl++;
            currentLvlCost = currentLvlCost * priceFactor;  
        }

    }




}
