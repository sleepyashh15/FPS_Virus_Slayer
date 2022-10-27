using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity.FPS.Gameplay
{
    public class HumanoidLandInput : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; } = Vector2.zero;
        public bool MoveIsPressed = false;
        public Vector2 LookInput { get; private set; } = Vector2.zero;
        public bool ShootIsPressed = false;
        public bool InvertMouseY { get; private set; } = true;
        public float ZoomCameraInput { get; private set; } = 0.0f;
        public bool InvertScroll { get; private set; } = true;
        public bool RunIsPressed { get; private set; } = false;
        public bool CrouchIsPressed { get; private set; } = false;
        public bool JumpIsPressed { get; private set; } = false;

        public bool FireIsPressed { get; private set; } = false;

        public bool ReloadIsPressed { get; private set; } = false;

        public float ScrollIsPressed { get; private set; } = 0.0f;

        public float ScopeIsPressed { get; private set; } = 0.0f;

        public bool ChangeCameraWasPressedThisFrame { get; private set; } = false;

        InputActions _input = null;

        PlayerInputHandler m_InputHandler;


        private void OnEnable()
        {
            _input = new InputActions();
            _input.HumanoidLand.Enable();

            _input.HumanoidLand.Move.performed += SetMove;
            _input.HumanoidLand.Move.canceled += SetMove;

            _input.HumanoidLand.Look.performed += SetLook;
            _input.HumanoidLand.Look.canceled += SetLook;

            _input.HumanoidLand.Run.started += SetRun;
            _input.HumanoidLand.Run.canceled += SetRun;

            _input.HumanoidLand.Crouch.started += SetCrouch;
            _input.HumanoidLand.Crouch.canceled += SetCrouch;

            _input.HumanoidLand.Jump.started += SetJump;
            _input.HumanoidLand.Jump.canceled += SetJump;

            _input.HumanoidLand.Fire.started += SetFire;
            _input.HumanoidLand.Fire.canceled += SetFire;

            _input.HumanoidLand.Reload.started += SetReload;
            _input.HumanoidLand.Reload.canceled += SetReload;

            _input.HumanoidLand.ZoomCamera.started += SetZoomCamera;
            _input.HumanoidLand.ZoomCamera.canceled += SetZoomCamera;

            _input.HumanoidLand.Switching.performed += SetSwitching;
            _input.HumanoidLand.Switching.canceled += SetSwitching;

            _input.HumanoidLand.Scope.started += SetScope;
            _input.HumanoidLand.Scope.canceled += SetScope;
        }

        private void OnDisable()
        {
            _input.HumanoidLand.Move.performed -= SetMove;
            _input.HumanoidLand.Move.canceled -= SetMove;

           _input.HumanoidLand.Look.performed -= SetLook;
            _input.HumanoidLand.Look.canceled -= SetLook;

            _input.HumanoidLand.Run.started -= SetRun;
            _input.HumanoidLand.Run.canceled -= SetRun;

            _input.HumanoidLand.Crouch.started -= SetCrouch;
            _input.HumanoidLand.Crouch.canceled -= SetCrouch;

            _input.HumanoidLand.Jump.started -= SetJump;
            _input.HumanoidLand.Jump.canceled -= SetJump;

            _input.HumanoidLand.Fire.started -= SetFire;
            _input.HumanoidLand.Fire.canceled -= SetFire;

            _input.HumanoidLand.Reload.started -= SetReload;
            _input.HumanoidLand.Reload.canceled -= SetReload;

            _input.HumanoidLand.ZoomCamera.started -= SetZoomCamera;
            _input.HumanoidLand.ZoomCamera.canceled -= SetZoomCamera;

            _input.HumanoidLand.Switching.performed -= SetSwitching;
            _input.HumanoidLand.Switching.canceled -= SetSwitching;

            _input.HumanoidLand.Scope.started -= SetScope;
            _input.HumanoidLand.Scope.canceled -= SetScope;

            _input.HumanoidLand.Disable();
        }

        private void Update()
        {
            ChangeCameraWasPressedThisFrame = _input.HumanoidLand.ChangeCamera.WasPressedThisFrame();
        }

        private void SetMove(InputAction.CallbackContext ctx)
        {
            MoveInput = ctx.ReadValue<Vector2>();
            MoveIsPressed = !(MoveInput == Vector2.zero);
        }

        private void SetLook(InputAction.CallbackContext ctx)
        {
            LookInput = ctx.ReadValue<Vector2>();
            ShootIsPressed = !(LookInput == Vector2.zero);

        }
     /*   private void SetLook(float x, float y)
        {
            x = m_InputHandler.GetLookInputsHorizontal();
            y = m_InputHandler.GetLookInputsVertical();

            LookInput = new Vector2(x, y);
            ShootIsPressed = !(LookInput == Vector2.zero);

        }*/

        private void SetRun(InputAction.CallbackContext ctx)
        {
            RunIsPressed = ctx.started;

        }

        private void SetReload(InputAction.CallbackContext ctx)
        {
            ReloadIsPressed = ctx.started;
        }

        private void SetCrouch(InputAction.CallbackContext ctx)
        {
            CrouchIsPressed = ctx.started;

        }

        private void SetJump(InputAction.CallbackContext ctx)
        {
            JumpIsPressed = ctx.started;
        }

        private void SetFire(InputAction.CallbackContext ctx)
        {
            FireIsPressed = ctx.started;
        }

        private void SetZoomCamera(InputAction.CallbackContext ctx)
        {
            ZoomCameraInput = ctx.ReadValue<float>();
        }

        private void SetSwitching(InputAction.CallbackContext ctx)
        {
            ScrollIsPressed = ctx.ReadValue<float>();
        }

        private void SetScope(InputAction.CallbackContext ctx)
        {
            ScopeIsPressed = ctx.ReadValue<float>();
        }

    }
}