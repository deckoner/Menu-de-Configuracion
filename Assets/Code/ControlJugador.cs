using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Control : MonoBehaviour
{
    private Controls controles;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        controles = new Controls();
        controles.Enable();

        Controls.Player.Salto.performed += CTX:cALLBACKcONTEXT => Salto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
