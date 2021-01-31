using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Character m_Character;

    private void Start()
    {
        if (m_Character)
        {
            PossessCharacter(m_Character);
        }
    }

    public void PossessCharacter(Character character)
    {
        character.Possess(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Character == null)
        {
            return;
        }

        float verticalInputAxisValue = Input.GetAxis("Vertical");
        float horizontalInputAxisValue = Input.GetAxis("Horizontal");
        float lookUpInputAxisValue = Input.GetAxis("Mouse Y");
        float lookRightInputAxisValue = Input.GetAxis("Mouse X");

        m_Character.MoveForward(verticalInputAxisValue);

        m_Character.MoveRight(horizontalInputAxisValue);

        if (lookUpInputAxisValue != 0.0f)
        {
            m_Character.LookUp(lookUpInputAxisValue);
        }

        if (lookRightInputAxisValue != 0.0f)
        {
            m_Character.LookRight(lookRightInputAxisValue);
        }

        if (Input.GetButtonDown("Jump"))
        {
            m_Character.JumpStart();
        } else if (Input.GetButtonUp("Jump"))
        {
            m_Character.JumpEnd();
        }
    }
}
