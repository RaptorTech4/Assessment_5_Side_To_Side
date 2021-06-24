using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public PlayerController _PC;

    public string _MovementInputName = "Horizontal";
    public string _JumpInputName = "Jump";

    float _Movement;

    private void Start()
    {
        _PC = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _Movement = Input.GetAxisRaw(_MovementInputName);
        _PC.Move(_Movement);

        if (Input.GetButtonDown(_JumpInputName))
        {
            _PC.Jump();
        }
    }
}
