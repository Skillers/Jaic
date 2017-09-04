using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    
    public GameObject cameraObject;
    Vector3 mouseBeginDrag;
    Vector3 mouseDuringDrag;
    Vector3 cameraPositionBeginDrag;
    public float draggingFactor;
    public float xBoundry;
    public float yBoundry;

    void Start()
    {
        draggingFactor = 4;
    }

    // camare handling
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            if (cameraObject.transform.position.z < -1000)
            {
                cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, cameraObject.transform.position.z + 200);
                draggingFactor = 4f;
                xBoundry += 125.5f;
                yBoundry += 77.4f;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) // backwards
        {
            if(cameraObject.transform.position.z > -4000)
            {
                cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, cameraObject.transform.position.z - 200);
                draggingFactor += 0.17f;
                xBoundry -= 125.5f;
                yBoundry -= 77.4f;
            }
        }

        if(cameraObject.transform.position.x <= (-xBoundry / 2))
        {
            cameraObject.transform.position = new Vector3((-xBoundry / 2), cameraObject.transform.position.y, cameraObject.transform.position.z);
        }
        if(cameraObject.transform.position.x >= (xBoundry / 2))
        {
            cameraObject.transform.position = new Vector3((xBoundry / 2), cameraObject.transform.position.y, cameraObject.transform.position.z);
        }
        if(cameraObject.transform.position.y <= (-yBoundry / 2) - 520)
        {
            cameraObject.transform.position = new Vector3( cameraObject.transform.position.x, (-yBoundry / 2) - 520, cameraObject.transform.position.z);
        }
        if (cameraObject.transform.position.y >= (yBoundry / 2) + 520)
        {
            cameraObject.transform.position = new Vector3(cameraObject.transform.position.x, (yBoundry / 2) + 520, cameraObject.transform.position.z);
        }

    }

    public void OnDrag(BaseEventData data)
    {

            mouseDuringDrag = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraObject.transform.position.z);

            cameraObject.transform.position = new Vector3(cameraPositionBeginDrag.x + ((mouseBeginDrag.x - mouseDuringDrag.x)*draggingFactor), cameraPositionBeginDrag.y + ((mouseBeginDrag.y - mouseDuringDrag.y) * draggingFactor), cameraObject.transform.position.z);
       
    }

    public void OnBeginDrag(BaseEventData data)
    {
            cameraPositionBeginDrag = cameraObject.transform.position;
            mouseBeginDrag = new Vector3(Input.mousePosition.x , Input.mousePosition.y, cameraObject.transform.position.z);
        
       
    }
}

