using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    float interactionRadius;
    [SerializeField]
    private Transform interactionOrigin;
    
    Transform player;
    bool isFocus = false;
    bool hasInteracted = false;


    private void Update()
    {
        if(isFocus)
        {
            float distance = Vector3.Distance(player.position, interactionOrigin.position);
            if (!hasInteracted && distance <= interactionRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }


    public virtual void Interact()
    {
        Debug.Log("Interacting with" + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocus()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionOrigin.position, interactionRadius);
    }
}
