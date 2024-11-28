using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBox : MonoBehaviour
{
    public bool IsUIOpen;
    public void MissionBoxOpen()
    {
        Debug.Log("미션상자 열기");
        IsUIOpen = true;
        // TODO : UI 상호작용 창 닫혀있는지 확인하는 bool변수 = ture; - return값
    }
    public void MissionBoxClose()
    {
        Debug.Log("미션상자 닫기");
        IsUIOpen = false;
        // TODO : UI 상호작용 창 닫혀있는지 확인하는 bool변수 = false; - return값
    }

}
