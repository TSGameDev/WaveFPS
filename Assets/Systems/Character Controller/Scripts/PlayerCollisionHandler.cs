using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private InputHandler _InputHandler;

    private string INTERACTION_TAG = "";

    private void Awake()
    {
        _InputHandler = GetComponent<InputHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(INTERACTION_TAG))
            _InputHandler.OnPlayerInteraction = other.GetComponent<IInteractable>().Interact;
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
