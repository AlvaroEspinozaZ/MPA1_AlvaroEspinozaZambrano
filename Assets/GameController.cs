using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{ 
    public GameObject selectedObject;
    public float velocity=4;
    Vector3 startPosition;
    Vector3 directionForward;
    public Rigidbody rgb;
    int count = 1;
    RaycastHit hit;
    public LayerMask mylayer;
    void Start()
    {
        startPosition = selectedObject.transform.position;
        //rgb = GetComponent<Rigidbody>();
    }

    void Update()
    {
                Vector3 positionMouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                Vector3 posPoke = new Vector3(startPosition.x + positionMouse.x, startPosition.y + positionMouse.y, selectedObject.transform.position.z);

                
                //selectedObject.GetComponent<Rigidbody>().useGravity = false;
                Debug.Log(positionMouse);
                directionForward = new Vector3(startPosition.x + positionMouse.x, startPosition.y + positionMouse.y, selectedObject.transform.position.z + startPosition.y + positionMouse.y);

            
      

    }
    private void FixedUpdate()
    {

        if (count == 1)
        {
            if (Input.GetMouseButton(0))
            {
                selectedObject.GetComponent<Rigidbody>().useGravity = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out hit))
                {
                    if(hit.collider.tag == "Player")
                    {
                        selectedObject.transform.position = new Vector3(hit.point.x, hit.point.y, selectedObject.transform.position.z);

                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                selectedObject.GetComponent<Rigidbody>().useGravity = true;
                rgb.velocity = Vector3.forward * velocity;
                count--;

            }
        }
    }
}
