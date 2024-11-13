using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = myCamera.transform.forward;
        // transform.LookAt(myCamera.transform.position);
    }
}
