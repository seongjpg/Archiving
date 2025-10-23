using UnityEngine;
using System.Collections.Generic;
using System;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GenImmediate gi;
    [SerializeField] SpanwerPoolAssets poolAssets;
    [SerializeField] public int summonLessItem;
    private List<SpanwerPoolAssets.Elem_And_Prop> objPool;
    public RectInt room;
    int summonItem;

    void Start()
    {
        // 아이템이 너무 바닥에 많이 떨어져있다면 곤란. 적은 양만이 맵에 포진하게끔 한다 - 128x80 사이즈의 맵이라면 2-3개 정도가 기댓값이 되겠다.                             
        summonItem = UnityEngine.Random.Range(-Convert.ToInt32(Mathf.Sqrt(Mathf.Sqrt(room.height * room.width))), Convert.ToInt32(Mathf.Sqrt(Mathf.Log(room.height * room.width, 2))));
        Debug.Log($"summonItem : {summonItem}, logscale : {Convert.ToInt32(Mathf.Log(room.height * room.width, 2))}, multiple : {room.height*room.width}");
        objPool = poolAssets.pool; // 오브젝트 풀 반영
        
    }

    public void Update()
    {
        if (room != null)
        {
            gi.SpawnObj(limit: summonItem, room, objPool); // limit는 사후 적절하게 바꿔 관리하여야 한다.
            Destroy(this.gameObject); // 기본적인 세팅이 끝난 이후에는 바로 파괴하면 됨. 
        }  
    }

    public void SetRoom(RectInt rect)
    {
        room = gi.SetRoom(rect);
    }

}
