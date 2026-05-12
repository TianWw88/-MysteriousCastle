using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    public GameObject colui;
    public Image hpima;
    public GameObject WinUi, LoseUI;

    public GameObject shuzhuobtn;

    public GameObject tipui;//提示UI
    public InputField baoxinagui;//保险柜密码


    public GameObject PintuGame;

    public MY_enemg mye;




    private bool Door_key = false;

    public GameObject Doorclose, Dooropen;
    void Start()
    {
        shuzhuobtn.GetComponent<Button>().onClick.AddListener(Ashuzhuo);

    }






    public void Aresmye()
    {
        mye.m_agent.speed = 3;
    }
    public void Ahp()
    {
        hpima.fillAmount -= 0.21f;
        if (hpima.fillAmount <= 0)
        {
            LoseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Abaoxiangui()
    {
        if (baoxinagui.text == "0481")
        {
            baoxinagui.gameObject.transform.parent.gameObject.SetActive(false);
            GameObject obj = Instantiate(tipui, tipui.transform.parent);
            obj.SetActive(true);
            obj.transform.GetChild(0).GetComponent<Text>().text = "The password is correct. You found a key in the safe";
            Destroy(obj, 2);
            GameObject.Find("地窖大门").gameObject.name = "地窖大门开";//可以开门
            GameObject.Find("保险柜").gameObject.SetActive(false);
        }
    }
    public void Ashuzhuo()
    {
        //搜索书桌
        GameObject.Find("书桌").gameObject.SetActive(false);
        shuzhuobtn.SetActive(false);
        GameObject obj = Instantiate(tipui,tipui.transform.parent);
        obj.SetActive(true);
        obj.transform.GetChild(0).GetComponent<Text>().text = "You found a key in your desk";
        Destroy(obj, 2);
        GameObject.Find("地下室大门").gameObject.name = "地下室门开";//可以开门
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "col")
        {
            for (int i = 0; i < colui.transform.childCount; i++)
            {
                if (colui.transform.GetChild(i).gameObject.name == other.gameObject.name)
                {
                    colui.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
        if (other.name == "Win")
        {
            WinUi.SetActive(true);
            Time.timeScale = 0;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "col")
        {
            for (int i = 0; i < colui.transform.childCount; i++)
            {
                if (colui.transform.GetChild(i).gameObject.name == other.gameObject.name)
                {
                    colui.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray01 = new Ray(Camera.main.transform.position, Vector3.forward);
            RaycastHit hit;
            //判断是否碰撞到物体
            bool isCollider = Physics.Raycast(ray, out hit);
            //bool isCollider01= Physics.Raycast(Camera.main.transform.position, Vector3.forward, 
            //    10, LayerMask.GetMask("UI", "Enemy", "Player"));
            if (isCollider)
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "拼图")
                {
                    PintuGame.SetActive(true);
                    mye.m_agent.speed = 0;
                }
                if (hit.collider.gameObject.name == "钥匙")
                {
                    Destroy(hit.collider.gameObject);
                    GameObject obj = Instantiate(tipui, tipui.transform.parent);
                    obj.SetActive(true);
                    obj.transform.GetChild(0).GetComponent<Text>().text = "Congratulations on unlocking the Easter egg and obtaining the key to the main entrance directly";
                    Destroy(obj, 2);
                    Doorclose.SetActive(false);
                    Dooropen.SetActive(true);

                }
            }

        }
    }
}
