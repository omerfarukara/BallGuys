using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    Animator _animator;

    float currentSprintSpeed;

    PhotonView view;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        currentSprintSpeed = ThirdPersonController.Instance.SprintSpeed;
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            #region Animation
            if (ThirdPersonController.Instance.speed > 1) { ThirdPersonController.Instance.speed = 1; }
            _animator.SetFloat("Force", Mathf.Abs(ThirdPersonController.Instance.speed));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.speed = 1.5f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _animator.speed = 1;
            }
            if (!ThirdPersonController.Instance.Grounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _animator.SetTrigger("Flip");
                    ThirdPersonController.Instance.SprintSpeed = ThirdPersonController.Instance.MaxSpeed;
                }
            }
            else
            {
                ThirdPersonController.Instance.SprintSpeed = currentSprintSpeed;
            }

            #endregion
        }
    }
}
