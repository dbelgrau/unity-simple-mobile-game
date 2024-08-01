using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class SimplePlayerController : MonoBehaviour
{

    private void Update()
    {
        if (GameplayManager.Instance.isPlaying)
        {
            HandleTouch();
#if DEBUG
            HandleMouse();
#endif
        }
    }

    private void HandleTouch()
    {
        if (Input.touchCount >= 1 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            GameplayManager.Instance.player.Attack(GameplayManager.Instance.enemy);
        }
    }

    private void HandleMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameplayManager.Instance.player.Attack(GameplayManager.Instance.enemy);
        }
    }
}
