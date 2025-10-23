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
        // �������� �ʹ� �ٴڿ� ���� �������ִٸ� ���. ���� �縸�� �ʿ� �����ϰԲ� �Ѵ� - 128x80 �������� ���̶�� 2-3�� ������ ����� �ǰڴ�.                             
        summonItem = UnityEngine.Random.Range(-Convert.ToInt32(Mathf.Sqrt(Mathf.Sqrt(room.height * room.width))), Convert.ToInt32(Mathf.Sqrt(Mathf.Log(room.height * room.width, 2))));
        Debug.Log($"summonItem : {summonItem}, logscale : {Convert.ToInt32(Mathf.Log(room.height * room.width, 2))}, multiple : {room.height*room.width}");
        objPool = poolAssets.pool; // ������Ʈ Ǯ �ݿ�
        
    }

    public void Update()
    {
        if (room != null)
        {
            gi.SpawnObj(limit: summonItem, room, objPool); // limit�� ���� �����ϰ� �ٲ� �����Ͽ��� �Ѵ�.
            Destroy(this.gameObject); // �⺻���� ������ ���� ���Ŀ��� �ٷ� �ı��ϸ� ��. 
        }  
    }

    public void SetRoom(RectInt rect)
    {
        room = gi.SetRoom(rect);
    }

}
