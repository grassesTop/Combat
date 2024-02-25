using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellDirectionUIControl : MonoBehaviour
{
    // Start is called before the first frame update

    public ICard card;
    private bool isSetEndPostion;
    private Button mSave;
    private Text mSaveHint;

    void Start()
    {
        mSave = transform.GetChild(0).GetComponent<Button>();
        mSaveHint = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        mSave.onClick.AddListener(() => {
            if (isSetEndPostion)
            {
                CombatManager.Instance.currentCharacter.SaveSpellCard(card);
                UIManager.Instance.SpellDirectionUIControl.gameObject.SetActive(false);
                UIManager.Instance.CombatUIControl.gameObject.SetActive(true);
            }
        });
    }

    public void SetCard(ICard card) {
        this.card = card;
    }

    // Update is called once per frame
    void Update()
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
                var startPosition = CombatManager.Instance.currentCharacter.GetTransform().position;
                var endPosition = hit.point;
                card.SetSpellInfo(SpellInfos.CreatesDirectionSpellInfo(startPosition, endPosition));
                isSetEndPostion = true;
                mSaveHint.text = "±£´æ";
            }
        }
    }
}
