using System.Collections.Generic;
using UnityEngine;


public struct RoomData {
    public RectInt room;
    public BoxCollider2D cd;
	public GameObject spawner;
    public RoomData(RectInt _room, BoxCollider2D _cd, GameObject _spawner)
    {
        room = _room;
        cd = _cd;
		spawner = _spawner;
    }
}

public class MapCenter : MonoBehaviour
{
	public List<RoomData> roomData = new List<RoomData>(); //MapGenerator에서 RoomData를 넣은 리스트가 여기에 있다.

	public void OnTriggerEnter2D(Collider2D obj)
	{
		Debug.Log("감지!");
		GameObject player = obj.gameObject;
		if (player.CompareTag("Player"))
		{
			// roomData의 RoomData 값들을 찾아서, 플레이어와 접촉중인 RoomData를 찾아 그 안의 spawner를 활성화한다.
			foreach (RoomData rd in roomData) // 여기서 스포너가 사라져서, 문제가 발생하고 있음(게임이 멈추진 않는데 수정해야함)
			{
				if (rd.cd.IsTouching(obj))
				{
					Debug.Log($"스포너 활성화");
					rd.spawner.SetActive(true);
				}
			}
		}
	}

	public void OnTriggerExit2D(Collider2D obj)
	{
		GameObject player = obj.gameObject;
		if (player.CompareTag("Player"))
		{
			Debug.Log("방을 나감");
		}
		
	}

}

