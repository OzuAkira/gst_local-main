using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMove : MonoBehaviour
{
    public float move_P = 0.03f;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > 1)
        {
           // X = false;
            //Debug.Log("a");
            gameObject.transform.position = gameObject.transform.position;
        }
        else
        {
            gameObject.transform.position += Vector3.down * move_P;
        }
    }
}