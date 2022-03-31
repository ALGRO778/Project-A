using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pedals : MonoBehaviour
{
    Image m_TargetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.UpArrow))
        { GetComponent<Image>().color = Color.white; }
        else GetComponent<Image>().color = Color.black;
    }
}
