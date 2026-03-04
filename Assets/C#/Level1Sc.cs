using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level1Sc : MonoBehaviour
{
    public GameObject yaokongqiUI, DoorUI;

    public GameObject xiangkuang;

    private GameObject Doormod;
    public InputField ipf;

    public GameObject Tiptext;
    public GameObject WinUI;
    void Start()
    {
        
    }
    public void Aopentv()
    {
        //打开电视
        yaokongqiUI.SetActive(false);
        xiangkuang.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Win")
        {
            WinUI.SetActive(true);
        }
    }
    public void Ainput()
    {
        GameObject obj = Instantiate(Tiptext, Tiptext.transform.parent);
        obj.transform.localPosition = Tiptext.transform.localPosition;
        obj.SetActive(true);
        if (ipf.text == "0812")
        {
            Doormod.GetComponent<Animator>().enabled = true;
            DoorUI.SetActive(false);
            obj.GetComponent<Text>().text = "Password correct";
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            obj.GetComponent<Text>().text = "Incorrect password";
        }
    }

    


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

                if (hit.collider.gameObject.name == "yaokongqi")
                {
                    yaokongqiUI.SetActive(true);
                }
                if (hit.collider.gameObject.name == "Door")
                {
                    ipf.text = "";
                    Doormod = hit.collider.gameObject;
                    DoorUI.SetActive(true);
                }
            }

        }
    }
}
