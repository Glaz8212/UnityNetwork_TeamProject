using UnityEngine;

/// <summary>
/// TODO: MissionBox들의 UI관리 필요
/// </summary>
public class MissionController : MonoBehaviour
{
    public bool Is1Clear = false;
    public bool Is2Clear = false;
    public bool IsEndingClear = false;

    // TODO: UI와의 버튼으로 구현하게 될 예정
    /// <summary>
    /// Mission1의 클리어 여부를 확인하는 함수
    /// </summary>
    public void Mission1ClearChecked()
    {
        // 미션 클리어가 완료된 경우에는 함수 종료
        if (Is1Clear)
        {
            Debug.Log("이미 1 클리어");
            return;
        }
        // 미션1 클리어가 안된 경우
        else
        {
            // TODO : 미션 아이템이 전부 들어갔는지 확인하여
            //        들어간 경우 => 미션 클리어
            //        부족한 경우 => 리턴
            //        인벤토리 기능 추가 시 수정 필요
            Debug.Log("1 클리어");
            Is1Clear = true;
        }
    }

    /// <summary>
    /// Mission2의 클리어 여부를 확인하는 함수
    /// </summary>
    public void Mission2ClearChecked()
    {
        // 미션1 클리어가 완료되지 않은 경우에는 함수 종료
        if (!Is1Clear)
        {
            Debug.Log("1 클리어 미완성");
            return;
        }
        // 미션2 클리어가 완료된 경우 함수 종료
        if (Is2Clear)
        {
            Debug.Log("이미 2 클리어");
            return;
        }
        // 미션1 클리어가 된경우
        else if (Is1Clear)
        {
            // TODO : 미션 아이템이 전부 들어갔는지 확인하여
            //        들어간 경우 => 미션 클리어
            //        부족한 경우 => 리턴
            //        인벤토리 기능 추가 시 수정 필요
            Debug.Log("2 클리어");
            Is2Clear = true;
        }
    }

    /// <summary>
    /// 게임의 클리어 여부를 확인하는 함수
    /// </summary>
    public void EndingClearChecked()
    {
        // 미션1 또는 미션2가 클리어되지 않은 경우 함수 종료
        if (!Is1Clear || !Is2Clear)
        {
            Debug.Log("1이나 2 클리어 미완성");
            return;
        }
        // 미션1과 2가 모두 클리어 된 경우
        else if (Is1Clear && Is2Clear)
        {
            Debug.Log("엔딩 클리어");
            // 엔딩확인
            IsEndingClear = true;
        }
    }

}
