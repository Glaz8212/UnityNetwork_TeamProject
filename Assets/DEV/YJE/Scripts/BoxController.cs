using UnityEngine;

/// <summary>
/// TODO: ItemBox들의 UI관리 필요
/// </summary>
public class BoxController : MonoBehaviour
{
    public bool IsUIOpen;
    [SerializeField] GameObject UI_ItemBox;

    // TODO : UI 상호작용 창 닫혀있는지 확인하는 bool변수 - public
    public void BoxOpen()
    {
        Debug.Log("아이템상자 열기");
        IsUIOpen = true;
        UI_ItemBox.SetActive(true);
        // TODO : UI 상호작용 창 닫혀있는지 확인하는 bool변수 = ture; - return값
    }

    public void BoxClose()
    {
        Debug.Log("아이템상자 닫기");
        IsUIOpen = false;
        UI_ItemBox.SetActive(false);

        // TODO : UI 상호작용 창 닫혀있는지 확인하는 bool변수 = false; - return값

    }

    /*
    [SerializeField] PlayerInteraction playerInteraction;

    public void Update()
    {
        if (playerInteraction.isInteracting)
        {
            BoxOpen();
        }
        else
        {
            BoxClose();
        }
    }

    public void BoxOpen()
    {
        Debug.Log("아이템상자 열기");
    }

    public void BoxClose()
    {
        Debug.Log("아이템상자 닫기");

    }
    */
}
