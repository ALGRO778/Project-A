using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer1 : MonoBehaviour
{
    [SerializeField] public float time = 600;
    [SerializeField] private Text timetxt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timetxt.text = time.ToString();
        }
        else
        {
            Debug.Log("Time's Up!");
            UnityEditor.EditorApplication.isPlaying = false;

        }
    }
}
