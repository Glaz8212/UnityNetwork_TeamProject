using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviourPunCallbacks
{
    public CinemachineVirtualCamera cinemachineVirtualCamera; // 시네머신 카메라
    private GameSceneManager gameSceneManager;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    /// <summary>
    /// 방에 입장 시 실행
    /// </summary>
    public override void OnJoinedRoom()
    {
        StartCoroutine(StartDelayRoutine());
    }

    /// <summary>
    /// 시작하자마자 바로 되는 경우, 제대로 안될 수 있으니 약간의 딜레이를 주기 위한 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator StartDelayRoutine()
    {
        // 네트워크 준비에 필요한 시간 설정
        yield return new WaitForSeconds(2f);
        SetCam();
    }

    private void SetCam()
    {
        cinemachineVirtualCamera.LookAt = gameSceneManager.nowPlayer.transform;
    }
}
