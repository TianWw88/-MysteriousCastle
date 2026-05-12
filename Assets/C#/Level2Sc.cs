using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level2Sc : MonoBehaviour
{
    public GameObject noteui, drawerui,keyui,doorui,Winui;

    public GameObject keyani;
    private bool iskey;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Win")
        {
            Winui.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //判断是否碰撞到物体
            bool isCollider = Physics.Raycast(ray, out hit);

            if (isCollider)
            {
                print(hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == "note")
                {
                    noteui.SetActive(true);
                }
                if (hit.collider.gameObject.name == "drawer")
                {
                    drawerui.SetActive(true);
                }

                if (hit.collider.gameObject.name == "book")
                {
                    hit.collider.gameObject.SetActive(false);
                    keyani.SetActive(true);
                   
                }

                if (hit.collider.gameObject.name == "SM_Prop_Key_01")
                {
                    keyui.SetActive(true);
                    iskey = true;
                }
                if (hit.collider.gameObject.name == "door")
                {
                    if (iskey)
                    {
                        gameObject.GetComponent<AudioSource>().Play();
                        hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    }
                    else
                    {
                        doorui.SetActive(true);
                    }
                }
            }


        }
    }
}
