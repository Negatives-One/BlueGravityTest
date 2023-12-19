using System.Collections.Generic;
using UnityEngine;

public class InteractionChecker : MonoBehaviour
{
    private List<Transform> _interactables = new List<Transform>();

    public IInteractable nextToMe;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            _interactables.Add(other.transform);
            OrganizeInteractables();
        } 
    }private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            _interactables.Remove(other.transform);
            OrganizeInteractables();
        } 
    }


    private void OrganizeInteractables()
    {
        float distance = float.MaxValue;
        IInteractable chosenOne = null;
        foreach (Transform interactable in _interactables)
        {
            float currentDistance = Vector2.Distance(transform.position, interactable.position);
            if ( currentDistance < distance)
            {
                distance = Vector2.Distance(transform.position, interactable.position);
                chosenOne = interactable.GetComponent<IInteractable>();
            }
        }

        nextToMe = chosenOne;
    }
}
