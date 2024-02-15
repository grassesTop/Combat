using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    public GameObject CardListUI;
    public GameObject DireactionSpellUI;
    public GameObject HandlerUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        DireactionSpellUI = Instantiate(Resources.Load<GameObject>("UI/SpellDirectionalUI"), this.transform);
        CardListUI = Instantiate(Resources.Load<GameObject>("UI/CardListUI"), this.transform);
        HandlerUI = Instantiate(Resources.Load<GameObject>("UI/Main/HandlerUI"), this.transform);
        DireactionSpellUI.SetActive(false);
        CardListUI.SetActive(false);
        HandlerUI.SetActive(true);
    }

    private void OnEnable()
    {
        DireactionSpellUI.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            DireactionSpellUI.SetActive(false);
            MouseManager.Instance.SpellCard();
        });
        HandlerUI.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            CardListUI.SetActive(true);
            HandlerUI.SetActive(false);
        });
    }
}
