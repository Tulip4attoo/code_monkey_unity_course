using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float playerRadius = 0.7f;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking = false;
    private Vector2 inputVector;
    private bool canMove = true;
    private Vector3 moveDir;
    private float moveDistance;
    private RaycastHit hitObject;
    private Vector3 lastInteractionDirection;

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        inputVector = gameInput.GetMovementVectorNormalized();
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastInteractionDirection = moveDir;
        }
        if (Physics.Raycast(transform.position, lastInteractionDirection, out hitObject, interactionDistance, counterLayerMask))
        {
            if (hitObject.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }


    private void Update()
    {
        HandleInteractions();
        HandleMovement();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        inputVector = gameInput.GetMovementVectorNormalized();
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastInteractionDirection = moveDir;
        }
        if (Physics.Raycast(transform.position, lastInteractionDirection, out hitObject, interactionDistance, counterLayerMask))
        {
            if (hitObject.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // clearCounter.Interact();
            }
        }
    }

    private void HandleMovement()
    {
        isWalking = false;
        inputVector = gameInput.GetMovementVectorNormalized();
        moveDistance = moveSpeed * Time.deltaTime;
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // attempt on X movement
            moveDir = new Vector3(inputVector.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, new Vector3(inputVector.x, 0, 0), moveDistance);
            if (canMove)
            {
                isWalking = true;
            } else {
                // attempt on Z movement
                moveDir = new Vector3(0, 0, inputVector.y).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
                if (canMove)
                {
                    isWalking = true;
                }
            }
        } else {
            isWalking = inputVector != Vector2.zero;
        }

        if (isWalking)
        {
            transform.position += moveDir * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

}
