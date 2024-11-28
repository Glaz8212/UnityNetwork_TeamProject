using Cinemachine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 장면 테스트를 위한 임시 테스트 스크립트
/// - 바로 게임 씬을 사용할 수 있도록 하는 스크립트
/// </summary>
public class TestGameScene : MonoBehaviourPunCallbacks
{
    public const string RoomName = "TestRoom";
    public GameObject nowPlayer;

    /// <summary>
    /// 게임 시작하자마자 연결을 세팅
    /// </summary>
    private void Start()
    {
        // 플레이어의 이름을 설정
        PhotonNetwork.LocalPlayer.NickName = $"Player {Random.Range(1000, 10000)}";
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// 연결하자마자 방의 옵션을 정하고 방을 생성하는 요청을 전송
    /// </summary>
    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 8;
        options.IsVisible = false;

        PhotonNetwork.JoinOrCreateRoom(RoomName, options, TypedLobby.Default);
    }

    /// <summary>
    /// 방에 입장한 상황
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
        yield return new WaitForSeconds(1f);
        TestGameStart();
    }
    public void TestGameStart()
    {
        Debug.Log("테스트용 게임 시작");

        // 게임 시작하자마자 플레이어를 생성
        PlayerSpawn();
    }

    /// <summary>
    /// 플레이어를 생성하는 함수
    ///  - 프리팹으로 플레이어를 생성할 때, 프리팹은 항상 Resource 폴더에 있어야 함
    ///  - 경로가 필요한경우 (Resource) 폴더명/프리팹명 으로 사용 가능
    /// </summary>
    private void PlayerSpawn()
    {
        //플레이어를 생성할 랜덤한 위치
        Vector3 randomPos = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        //nowPlayer = PhotonNetwork.Instantiate("JHS/Player01", randomPos, Quaternion.identity);
        nowPlayer = PhotonNetwork.Instantiate("YJE/TestPlayer", randomPos, Quaternion.identity);
    }
}
