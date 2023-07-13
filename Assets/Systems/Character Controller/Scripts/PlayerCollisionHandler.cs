using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private InputHandler _InputHandler;


    private void Awake()
    {
        _InputHandler = GetComponent<InputHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _InputHandler.OnPlayerInteraction = other.GetComponent<IInteractable>() != null ? other.GetComponent<IInteractable>().Interact : null;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
