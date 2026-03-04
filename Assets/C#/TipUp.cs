using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * 50 * Time.deltaTime);
    }
}
