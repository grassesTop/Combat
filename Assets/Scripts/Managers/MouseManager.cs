using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : Singleton<MouseManager>
{

    public Action<RaycastHit> OnMoveToPositionActions;
    private ICard iCard;
    private GameObject ClickPoint;
    public enum MouseState
    {
        Combat, Spell, Calculus, Main
    }

    public MouseState mouseState = MouseState.Combat;

    protected override void Awake()
    {
        base.Awake();
        ClickPoint = Instantiate(Resources.Load<GameObject>("Helpers/ClickPoint"));
        ClickPoint.SetActive(false);
    }

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

    public void StartSpell(ICard card)
    {
        mouseState = MouseState.Spell;
        iCard = card;
        if (card.OriginInfo().spellType == SpellTypes.Directional)
        {
            UIManager.Instance.DireactionSpellUI?.SetActive(true);
        }
    }


    public void SetMouseState(MouseState state) {
        mouseState = state;
    }

    private void OnMainState() {
        OpenMenu();
    }
    private void OnCombatState()
    {
        OpenMenu();
    }
    private void OnSpellState()
    {
        OpenMenu();
        SetPreSpellCard_Fire();
    }
    private void OnCalculusState()
    {
        OpenMenu();
    }

    private void OpenMenu() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            
        }
    }


    public void SetPreSpellCard_Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            var camera = Camera.main;
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                Debug.Log("card spell");
                if (iCard.OriginInfo().spellType == SpellTypes.Directional)
                {
                    ClickPoint.SetActive(true);
                    ClickPoint.transform.position = hit.point;
                    SpellInfo spellInfo = new SpellInfo();
                    CombatManager.Instance.playingCharacter.GetTransform().LookAt(hit.point);
                    spellInfo.CreateDirectionSpellType(CombatManager.Instance.playingCharacter.GetTransform().Find("StartPosition").position, hit.point);
                    iCard.SetSpellInfo(spellInfo);
                    
                }
            }
        }
    }
    public void SpellCard()
    {
        Debug.Log("SpellCard");
        CombatManager.Instance.playingCharacter.SetSpellCard(iCard);
        ClickPoint.SetActive(false);
        UIManager.Instance.HandlerUI.SetActive(true);
    }

    
}
