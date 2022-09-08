using Photon.Pun;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        PhotonView view;

        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

        private void Start()
        {
            view = GetComponent<PhotonView>();
        }

        public void OnMove(InputValue value)
        {
            if (view.IsMine)
            {
                MoveInput(value.Get<Vector2>());
            }
        }

        public void OnLook(InputValue value)
        {
            if (view.IsMine)
            {
                if (cursorInputForLook)
                {
                    LookInput(value.Get<Vector2>());
                }
            }
        }

        public void OnJump(InputValue value)
        {
            if (view.IsMine)
            {
                JumpInput(value.isPressed);
            }
        }

        public void OnSprint(InputValue value)
        {
            if (view.IsMine)
            {
                SprintInput(value.isPressed);
            }
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            if (view.IsMine)
            {
                move = newMoveDirection;
            }
        }

        public void LookInput(Vector2 newLookDirection)
        {
            if (view.IsMine)
            {
                look = newLookDirection;
            }
        }

        public void JumpInput(bool newJumpState)
        {
            if (view.IsMine)
            {
                jump = newJumpState;
            }
        }

        public void SprintInput(bool newSprintState)
        {
            if (view.IsMine)
            {
                sprint = newSprintState;
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (view.IsMine)
            {
                SetCursorState(cursorLocked);
            }
        }

        private void SetCursorState(bool newState)
        {
            if (view.IsMine)
            {
                Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
            }
        }
    }

}