using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminale : MonoBehaviour
{

    public ThirdPersonController tpc;
    public GameObject panel;
    public bool terminalActive;

    // Start is called before the first frame update
    void Start()
    {
        ToggleTerminal();
    }

    public void ToggleTerminal()
    {
        terminalActive = !terminalActive;

        tpc.enabled = !terminalActive;
        panel.SetActive(terminalActive);
        Cursor.visible = terminalActive;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
