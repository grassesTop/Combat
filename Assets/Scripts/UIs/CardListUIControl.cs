using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardListUIControl : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mCardItem;
    private List<ICard> mList;
    private GridLayoutGroup mGroup;
    public bool NeedRefresh = true;


    private void Awake()
    {
        mCardItem = Resources.Load<GameObject>("UI/CardItemUI");
        mGroup = GetComponent<GridLayoutGroup>();
    }

    private void OnEnable()
    {
        if (NeedRefresh)
        {
            Refresh();
            NeedRefresh = false;
        }
    }

    public void Refresh()
    {
        mList = new List<ICard>
        {
            new FireBall(),
            new FireBall(),
            new FireBall()
        };
        for (int i = 0; i < mList.Count; i++)
        {
            var item = Instantiate(mCardItem, this.transform);
            var itemControl = item.GetComponent<CardItemUIControl>();
            itemControl.SetDate(i, mList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
