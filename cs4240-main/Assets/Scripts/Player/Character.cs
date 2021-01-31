using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody), typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected PlayerController m_PlayerController;

    protected CapsuleCollider m_CapsuleCollider;

    protected Rigidbody m_Rigidbody;

    protected Animator m_Animator;

    [SerializeField]
    protected float m_MovementSpeed;

    private void Awake()
    {
        m_CapsuleCollider = GetComponent<CapsuleCollider>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        //m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        OnAwake();
    }

    protected virtual void OnAwake() { }

    private void Update()
    {
        UpdateAnimator();
        OnUpdate();
    }
    protected virtual void OnUpdate() { }

    protected virtual void OnUpdateAnimator() { }
    private void UpdateAnimator()
    {
        OnUpdateAnimator();
    }

    protected virtual void OnPossessed(PlayerController controller) { }
    public void Possess(PlayerController controller) 
    { 
        m_PlayerController = controller;
        OnPossessed(controller);
    }

    protected abstract void OnMoveForward(float axisValue);
    public void MoveForward(float axisValue)
    {
        OnMoveForward(axisValue);
    }

    protected abstract void OnMoveRight(float axisValue);
    public void MoveRight(float axisValue)
    {
        OnMoveRight(axisValue);
    }

    protected abstract void OnLookUp(float axisValue);
    public void LookUp(float axisValue)
    {
        OnLookUp(axisValue);
    }

    protected abstract void OnLookRight(float axisValue);
    public void LookRight(float axisValue)
    {
        OnLookRight(axisValue);
    }

    protected abstract void OnJumpStart();
    public void JumpStart()
    {
        OnJumpStart();
    }

    protected abstract void OnJumpEnd();
    public void JumpEnd()
    {
        OnJumpEnd();
    }
}
