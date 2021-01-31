using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    [SerializeField]
    private GameObject m_TargetFollowGO;

    [SerializeField]
    private float m_CameraLagSpeed = 5.0f;

    private Transform m_TargetFollowTransform;

    private Vector3 m_TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (m_TargetFollowGO != null)
        {
            m_TargetFollowTransform = m_TargetFollowGO.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TargetFollowTransform)
        {
            m_TargetPosition = m_TargetFollowTransform.position;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.fixedDeltaTime * m_CameraLagSpeed);
    }

    public void Rotate(Vector3 angle)
    {
        transform.localEulerAngles += angle;
    }

}
