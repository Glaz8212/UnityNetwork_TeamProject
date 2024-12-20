using Photon.Pun;
using System.Collections;
using UnityEngine;

public class ResourceController : MonoBehaviourPun
{
    public float maxHp;
    public float curHp;

    public Vector3 startPos; // 처음 스폰 위치를 기억
    public Vector3 itemSpawnPos; // 아이템 스폰 위치
    private float range;
    [SerializeField] int second; // 리스폰 시간

    private string resourceTag;

    private void Start()
    {
        curHp = maxHp;
        startPos = transform.position;
        resourceTag = gameObject.tag;
    }
  
    /// <summary>
    /// Player와 Resource의 상호작용 함수 - 삭제 시 주의 요망
    /// Resource의 사망상태를 처리
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        if (curHp > 0)
        {
            Debug.Log($"체력감소 {curHp}");
            curHp -= damage;
        }
        if (curHp <= 0)
        {
            Debug.Log("죽음");
            photonView.RPC("Die", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    private void Die()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            range = Random.Range(1.5f, 2f);
            itemSpawnPos = new Vector3(Random.onUnitSphere.x * range + startPos.x,
                               startPos.y + 1.5f,
                               Random.onUnitSphere.z * range + startPos.z);
            StartCoroutine(DieRoutine());
        }
    }

    IEnumerator DieRoutine()
    {
        gameObject.transform.position = new Vector3(startPos.x, startPos.y - 10, startPos.z);
        switch (resourceTag)
        {
            case "Tree":
                PhotonNetwork.Instantiate("YJE/Wood", itemSpawnPos, Quaternion.identity);
                break;
            case "Rock":
                PhotonNetwork.Instantiate("YJE/Ore", itemSpawnPos, Quaternion.identity);
                break;
            case "Grass":
                PhotonNetwork.Instantiate("YJE/Fruit", itemSpawnPos, Quaternion.identity);
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(second);
        curHp = maxHp;
        gameObject.transform.position = startPos;
    }
}
