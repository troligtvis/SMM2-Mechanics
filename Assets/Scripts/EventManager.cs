using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnUpKeyPressed();
    public static event OnUpKeyPressed onUpKeyPressed;

    public static void RaiseOnUpKeyPressed()
    {
        onUpKeyPressed?.Invoke();
    }
}
