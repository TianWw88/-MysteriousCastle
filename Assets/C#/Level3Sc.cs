using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level3Sc : MonoBehaviour
{
    public GameObject note_door,note_wind,note_buou;

    public GameObject note_windmod;

    public GameObject aud_wind;


    public InputField input1, input2, input3;


    public GameObject note_boxui;
    public GameObject boxui;
    public GameObject boxmod;//木箱模型
    public GameObject tiptext;

    private float boxcd;

    private bool iskey;
    public GameObject doorui;
    public GameObject Winui;


    public GameObject choutiui;
    public Slider sli1, sli2, sli3;
    public GameObject slitip;
    public GameObject Choutimod;

    public GameObject note_chouti;

    public GameObject keyui;

    public AudioSource box_aud;
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

    public void Achouti()
    {
        if (sli1.value == 1 && sli2.value == 1 && sli3.value == 1)
        {
            choutiui.SetActive(false);
            Choutimod.GetComponent<Animator>().enabled = true;
            Choutimod.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            boxcd = 1;
            slitip.SetActive(true);
        }
    }
    public void Abox()
    {
        //确定
        if (input1.text == "Circle" && input2.text == "Triangle" && input3.text == "Circle")
        {
            //正确
            boxui.SetActive(false);
            boxmod.GetComponent<BoxCollider>().enabled = false;
            boxmod.GetComponent<Animator>().enabled = true;
            box_aud.Play();
}
        else
        {
            boxcd = 1;
            tiptext.SetActive(true);
        }
    }
        

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (boxui.activeSelf) boxui.SetActive(false);
            if (choutiui.activeSelf) choutiui.SetActive(false);
        }

        boxcd -= Time.deltaTime;
        if (boxcd < 0)
        {
            tiptext.SetActive(false);
            slitip.SetActive(false);
        }

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

                if (hit.collider.gameObject.name == "note_door")
                {
                    note_door.SetActive(true);
                }
                if (hit.collider.gameObject.name == "WindChime")
                {
                    aud_wind.SetActive(true);
                    note_windmod.SetActive(true);
                }

                if (hit.collider.gameObject.name == "note_windmod")
                {
                    note_wind.SetActive(true);
                }

                if (hit.collider.gameObject.name == "Box")
                {
                    boxui.SetActive(true);
                }

                if (hit.collider.gameObject.name == "note_box")
                {
                    //木箱纸条
                    note_boxui.SetActive(true);
                }

                if (hit.collider.gameObject.name == "note_buou")
                {
                    //布偶纸条
                    note_buou.SetActive(true);
                }

                if (hit.collider.gameObject.name == "note_chouti")
                {
                    //抽屉纸条
                    note_chouti.SetActive(true);
                }
                if (hit.collider.gameObject.name == "Chouti")
                {
                    //抽屉界面
                    choutiui.SetActive(true);
                }

                if (hit.collider.gameObject.name == "key")
                {
                    //钥匙
                    hit.collider.gameObject.SetActive(false);
                    iskey = true;
                    keyui.SetActive(true);
                }


                if (hit.collider.gameObject.name == "door")
                {
                    if (iskey)
                    {
                        hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                        gameObject.GetComponent<AudioSource>().Play();
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
