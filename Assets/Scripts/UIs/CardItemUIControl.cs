using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItemUIControl : MonoBehaviour
{

    private Image mImage;
    private Text mText;
    private Button mButton;


    private void Awake()
    {
        mButton = GetComponent<Button>();
        mImage = transform.GetChild(0).GetComponent<Image>();
        mText = transform.GetChild(1).GetComponent<Text>();
    }

    public void SetDate(int index, ICard card) {
        var texture = card.OriginInfo().texture;
        mImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        mText.text = card.OriginInfo().cardName;
        mButton.onClick.AddListener(() => {
            if (card.OriginInfo().spellType == SpellTypes.Directional)
            {
                UIManager.Instance.SpellDirectionUIControl.gameObject.SetActive(true);
                UIManager.Instance.SpellDirectionUIControl.SetCard(card);
                UIManager.Instance.CardListUIControl.gameObject.SetActive(false);
            }
        });
    }


}
