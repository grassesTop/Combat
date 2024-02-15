using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{

    private Button clickButton;
    private Image image;
    private Text text;
    private ICard card;

    public void SetData(ICard card) {
        this.card = card;
        float width = card.OriginInfo().texture.width;
        float height = card.OriginInfo().texture.height;
        Sprite pic = Sprite.Create(card.OriginInfo().texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        image.sprite = pic;
        text.text = card.OriginInfo().cardName;
    }

    private void Awake()
    {
        clickButton = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();

    }

    private void OnEnable()
    {
        clickButton.onClick.AddListener(OnItemClick);
       
    }

    private void OnDisable()
    {
        clickButton.onClick.RemoveAllListeners();
    }

    private void OnItemClick()
    {
        UIManager.Instance.CardListUI.SetActive(false);
        MouseManager.Instance.StartSpell(card);
    }
}
