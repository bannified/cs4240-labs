using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCharacter : Character
{
    float m_JumpForce;

    [SerializeField]
    float m_MaxMoveSpeed = 20.0f;

    private float m_SqMaxMoveSpeed;

    [SerializeField]
    private bool m_HasInput;
    [SerializeField]
    private Vector2 m_InputVector;
    [SerializeField]
    private Vector3 m_MovementVector;

    [SerializeField]
    private SpringArm m_SpringArm;
    [SerializeField]
    private Camera m_Camera;

    private Quaternion m_TargetRotation;
    [SerializeField]
    private float m_TurnRate = 5.0f;

    [SerializeField]
    private float m_CameraTurnRate = 3.0f;

    protected override void OnAwake() 
    {
        m_SqMaxMoveSpeed = m_MaxMoveSpeed * m_MaxMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        m_HasInput = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0; 

        Move();
        UpdateMoveRotation();
    }

    private void Move()
    {
        float velocitySq = m_Rigidbody.velocity.sqrMagnitude;

        m_Animator.SetFloat("WalkRun", Mathf.Sqrt(velocitySq) / m_MaxMoveSpeed);

        if (velocitySq > m_SqMaxMoveSpeed)
        {
            return;
        }

        if (!m_HasInput)
        {
            return;
        }

        if (m_Camera != null)
        {
            Vector3 m_CamForward = m_Camera.transform.forward.normalized;
            Vector3 m_CamRight = m_Camera.transform.right.normalized;
            m_MovementVector = (m_InputVector.y * m_CamForward) + (m_InputVector.x * m_CamRight);
            m_MovementVector.y = 0.0f;

            m_Rigidbody.AddForce(m_MovementVector * m_MovementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }

    private void UpdateMoveRotation()
    {
        if (m_MovementVector.sqrMagnitude == 0)
        {
            return;
        }

        Quaternion rot = Quaternion.LookRotation(m_MovementVector, Vector3.up);
        m_TargetRotation = rot;

        transform.rotation = Quaternion.Slerp(transform.rotation, m_TargetRotation, m_TurnRate * Time.fixedDeltaTime);
    }

    /**
     * Character Interface
     */

    protected override void OnMoveForward(float axisValue)
    {
        m_InputVector.y = axisValue;
    }

    protected override void OnMoveRight(float axisValue)
    {
        m_InputVector.x = axisValue;
    }

    protected override void OnLookUp(float axisValue)
    {
        m_SpringArm.Rotate(new Vector3(-axisValue * m_CameraTurnRate, 0.0f, 0.0f));
    }

    protected override void OnLookRight(float axisValue)
    {
        m_SpringArm.Rotate(new Vector3(0.0f, axisValue * m_CameraTurnRate, 0.0f));
    }

    protected override void OnJumpStart()
    {

    }

    protected override void OnJumpEnd()
    {

    }

    protected override void OnPossessed(PlayerController controller)
    {

    }

    protected override void OnUpdateAnimator()
    {

    }
}
