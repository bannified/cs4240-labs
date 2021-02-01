using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpActivatable : MonoBehaviour, IActivatable
{
    [SerializeField]
    private FoxCharacter m_TargetFoxCharacter;

    public void Activate()
    {
        if (m_TargetFoxCharacter == null)
        {
            return;
        }

        m_TargetFoxCharacter.SetMaxJumpCount(2);
    }
}
