using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : BasePanel
{
    public int size = 10;
    public Grid gridPrefab;

    private GridLayoutGroup gridLayoutGroup;
    private List<Grid> grids = new List<Grid>();

    private int timenum;
    public Text timetext1,timetext2;
    public GameObject WinUI;

    public GameObject gridsobj;


    private void Awake()
    {
        gridLayoutGroup = transform.Find("Grids").GetComponent<GridLayoutGroup>();
        SetGame(4);
        InvokeRepeating("Settime", 1, 1);
    }

    public void Settime()
    {
        timenum++;
        timetext1.text = "计时：" + timenum + "s";
        timetext2.text = "用时：" + timenum + "s";
    }
    public void SetGame(int size)
    {
        this.size = size;
        
        Init();
        RandomList();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        gridLayoutGroup.cellSize = Vector2.one * (1000 - 5 * (size - 1)) / size;
        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                if ((i - 1) * size + j > grids.Count)
                {
                    grids.Add(Instantiate(gridPrefab, gridLayoutGroup.transform));
                }
                else
                {
                    grids[i].gameObject.SetActive(true);
                }
                grids[(i - 1) * size + j - 1].SetInf(this, size, new Vector2(i, j));
            }
        }
        if (grids.Count > size * size)
        {
            for (int i = size * size; i < grids.Count; i++)
            {
                grids[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 随机位置
    /// </summary>
    public void RandomList()
    {
        for (int i = 0; i < grids.Count; i++)
        {
            grids[i].transform.SetSiblingIndex(Random.Range(0, size * size));
        }
    }

    /// <summary>
    /// 交换步骤处理
    /// </summary>
    public void DoStep()
    {

        for (int i = 0; i < grids.Count; i++)
        {
            if (grids[i].transform.GetSiblingIndex() != i)
            {
                return;
            }
        }
        WinUI.SetActive(true);

        // 拼图完成，恢复守卫速度
        MainControl mc = GameObject.FindObjectOfType<MainControl>();
        if (mc != null) mc.Aresmye();

        CancelInvoke("Settime");
        
        
    }
}
