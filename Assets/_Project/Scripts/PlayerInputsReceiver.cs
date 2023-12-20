using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsReceiver : MonoBehaviour
{
    public bool interact = false;
    public bool inventory = false;
    public Vector2 moveVector = Vector2.zero;

    public void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }

    public void OnInteract()
    {
        interact = true;
    }
    public void OnInventory()
    {
        inventory = true;
    }
}
