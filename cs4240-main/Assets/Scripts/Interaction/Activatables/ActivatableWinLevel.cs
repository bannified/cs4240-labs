using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableWinLevel : MonoBehaviour, IActivatable
{
    public void Activate()
    {
        Time.timeScale = 0.0f;
    }
}
