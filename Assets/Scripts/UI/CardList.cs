using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardList : MonoBehaviour
{
    private GameObject cardItemObj;
    
    private List<ICard> list = new List<ICard>();

    private GridLayoutGroup mGridLayoutGroup;

    private bool NeedRefresh = true;

    private void Awake()
    {
        cardItemObj = Resources.Load("UI/CardItemUI") as GameObject;
        list.Clear();
        list.Add(new FireBall());
        list.Add(new FireBall());
        list.Add(new FireBall());
        list.Add(new FireBall());
        mGridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void OnEnable()
    {
        if (NeedRefresh)
        {
            foreach (var item in list)
            {
                CardItem cardItem = Instantiate<GameObject>(cardItemObj, gameObject.transform).GetComponent<CardItem>();
                cardItem.SetData(item);
            }
            NeedRefresh = false;
        }
    }
}
