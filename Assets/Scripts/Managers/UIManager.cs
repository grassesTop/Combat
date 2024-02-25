using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public CombatUIControl CombatUIControl;
    public CardListUIControl CardListUIControl;
    public SpellDirectionUIControl SpellDirectionUIControl;
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        InitCombatUI();
        InitCardListUI();
        InitSpellDirectionUI();
    }

    private void InitCombatUI()
    {
        GameObject CombatUI = Instantiate(Resources.Load<GameObject>("UI/CombatUI"), this.transform);
        CombatUI.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => {
            CombatUI.SetActive(false);
            CardListUIControl.gameObject.SetActive(true);
        });
        CombatUIControl = CombatUI.GetComponent<CombatUIControl>();
    }

    private void InitCardListUI() {
        GameObject CardListUI = Instantiate(Resources.Load<GameObject>("UI/CardListUI"), this.transform);
        CardListUI.SetActive(false);
        CardListUIControl = CardListUI.GetComponent<CardListUIControl>();
    }

    private void InitSpellDirectionUI()
    {
        GameObject spellDirectionUI = Instantiate(Resources.Load<GameObject>("UI/SpellDirectionUI"), this.transform);
        spellDirectionUI.SetActive(false);
        SpellDirectionUIControl = spellDirectionUI.GetComponent<SpellDirectionUIControl>();
    }

    
}
