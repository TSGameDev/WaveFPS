using UnityEngine;

[RequireComponent(typeof(MotorHandler))]
[RequireComponent(typeof(RotationHandler))]
public class InputHandler : MonoBehaviour
{
    private PlayerControls _PlayerControls;
    private MotorHandler _MotorHandler;
    private RotationHandler _RotationHandler;

    private bool _ShiftHeld;
    private bool _LeftClickHeld;
    private bool _RightClickHeld;

    public Vector2 GetMovementInput() => _PlayerControls.Game.WASD.ReadValue<Vector2>();
    public Vector2 GetMouseInput() => _PlayerControls.Game.MouseDelta.ReadValue<Vector2>();
    public bool GetJumpInput() => _PlayerControls.Game.Space.triggered;
    public bool GetLeftClick() => _PlayerControls.Game.LeftClick.triggered;
    public bool GetRightClick() => _PlayerControls.Game.RightClick.triggered;

    public bool GetRunningInput() => _ShiftHeld;
    public bool GetLeftClickHeld() => _LeftClickHeld;
    public bool GetRightClickHeld() => _RightClickHeld;

    private void Awake()
    {
        _PlayerControls = new();
        _MotorHandler = GetComponent<MotorHandler>();
        _RotationHandler = GetComponent<RotationHandler>();
    }

    private void OnEnable()
    {
        _PlayerControls.Enable();
        _PlayerControls.Game.Enable();

        _PlayerControls.Game.Shift.performed += ctx => _ShiftHeld = true;
        _PlayerControls.Game.Shift.canceled += ctx => _ShiftHeld = false;

        _PlayerControls.Game.LeftClick.performed += ctx => _LeftClickHeld = true;
        _PlayerControls.Game.LeftClick.canceled += ctx => _LeftClickHeld = false;
        
        _PlayerControls.Game.RightClick.performed += ctx => _RightClickHeld = true;
        _PlayerControls.Game.RightClick.canceled += ctx => _RightClickHeld = false;
    }

    private void OnDisable()
    {
        _PlayerControls.Disable();
        _PlayerControls.Game.Disable();
    }

    private void Update()
    {
        _MotorHandler.moveDir = GetMovementInput();
        _MotorHandler.hasJumped = GetJumpInput();
        _MotorHandler.isRunning = GetRunningInput();

        _RotationHandler.mouseInput = GetMouseInput();
    }
}
