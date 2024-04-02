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
    float yMax = 0;
    public float timer = 0;
    bool iniciarTImer=false;
    void Start()
    {
        startPosition = selectedObject.transform.position;
        //rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (iniciarTImer)
        {
            timer += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {

        if (count == 1)
        {
            if (Input.GetMouseButton(0))
            {
                iniciarTImer = true;
                selectedObject.GetComponent<Rigidbody>().useGravity = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    startPosition = selectedObject.transform.position;
                    if (hit.collider.tag == "Player")
                    {
                        selectedObject.transform.position = new Vector3(hit.point.x, hit.point.y, selectedObject.transform.position.z);
                        Debug.Log(selectedObject.transform.position.y);
                    }
                   
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                yMax = selectedObject.transform.position.y - startPosition.y;
               
                Debug.Log(yMax);
                float comprobar = yMax - selectedObject.transform.position.y;
                Debug.Log("asdad" + comprobar);
                if (timer < 1.3f && selectedObject.transform.position.y >1.6f)
                {
                    Debug.Log("LanzamientoRapido");
                    selectedObject.GetComponent<Rigidbody>().useGravity = true;
                    rgb.velocity =new Vector3(0, 1.5f* velocity, 1.5f * velocity);
                    count--;
                }
                else {
                    Debug.Log("LanzamientoNormal");
                    selectedObject.GetComponent<Rigidbody>().useGravity = true;
                    rgb.velocity = Vector3.forward * velocity;
                    count--;
                }

            }
        }
    }
}
