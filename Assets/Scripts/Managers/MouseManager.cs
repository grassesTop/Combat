using System;
using System.Collections;
using UnityEngine;

public class MouseManager : Singleton<MouseManager>
{

    public Action<RaycastHit> OnMoveToPositionActions;
    private enum MouseState
    {
        Combat, Spell, Calculus, Main
    }

    private MouseState mouseState = MouseState.Combat;

    // Update is called once per frame
    void Update()
    {
        switch(mouseState)
        {
            case MouseState.Combat:
                OnCombatState();
                break;
            case MouseState.Spell:
                OnSpellState();
                break;
            case MouseState.Calculus:
                OnCalculusState();
                break;
            case MouseState.Main:
                OnMainState();
                break;
        }
    }

    private void OnMainState() {
        OpenMenu();
    }
    private void OnCombatState()
    {
        OpenMenu();
        MoveToPosition();
    }
    private void OnSpellState()
    {
        OpenMenu();
    }
    private void OnCalculusState()
    {
        OpenMenu();
    }

    private void OpenMenu() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            
        }
    }

    private void MoveToPosition()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var camera = Camera.main;
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                OnMoveToPositionActions?.Invoke(hit);
            }
        }
    }
}
