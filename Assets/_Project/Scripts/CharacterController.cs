using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private PlayerInputsReceiver playerInputsReceiver;

    public enum LookingDirection
    {
        Back,
        Front,
        Side
    }

    [SerializeField] private float speed = 5f;
    [SerializeField] private LookingDirection lastLookingDir = LookingDirection.Front;
    [SerializeField] private bool isWalking = false;

    private void Update()
    {
        isWalking = !(playerInputsReceiver.moveVector == Vector2.zero);
        SetMoveDirection();
        
        Vector3 flipScale = transform.localScale;
        if (lastLookingDir == LookingDirection.Side)
        {
            if (playerInputsReceiver.moveVector.x > 0) flipScale.x = 1;
            else if (playerInputsReceiver.moveVector.x < 0) flipScale.x = -1;
            transform.localScale = flipScale;
        }
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition((Vector2)transform.position + playerInputsReceiver.moveVector * (speed * Time.deltaTime));
    }

    private void SetMoveDirection()
    {
        if (playerInputsReceiver.moveVector.x != 0) lastLookingDir = LookingDirection.Side;
        else if (playerInputsReceiver.moveVector.y < 0) lastLookingDir = LookingDirection.Front;
        else if (playerInputsReceiver.moveVector.y > 0) lastLookingDir = LookingDirection.Back;
    }
}