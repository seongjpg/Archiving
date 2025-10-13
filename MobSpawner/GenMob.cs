using System.Collections.Generic;
using UnityEngine;


// Interface와 ScriptableObject를 활용하여 만든 것은 결국 CreateAssetMenu를 사용하여, 인스펙터에서 에셋화하여 사용할 수 있게 만들어야 한다.
[CreateAssetMenu(menuName ="Spawner/GenMob")] 

//genMob을 달고있는 스포너는, 플레이어가 트리거에 감지되는 순간 스포너를 소환한다.
public class GenMob : ScriptableObject, IGetArea, ISpawnRealTime {

	
	public RoomData GetRoomSize() // 안씀
	{
		RoomData rd = new RoomData();
		return rd;
	}

	public RectInt SetRoom(RectInt rect) // 방의 크기를 정하여 SetLoc에서 활용
	{
		return rect;
	}

	//몬스터를 소환하는 부분. 현재는 여러 몬스터가 한꺼번에 소환된다. 이는 수정하여 순차적으로 소환되도록 설정 하면 된다.
	public void SpawnObj(int limit, RectInt room, List<SpanwerPoolAssets.Elem_And_Prop> objPool)
	{
		int amt = Random.Range(limit / 2, limit);
		GameObject player = GameObject.FindWithTag("Player");
		for (int rep = 0; rep < amt; rep++)
		{
			int mom = 0; List<int> sector = new List<int>();
			foreach (SpanwerPoolAssets.Elem_And_Prop eap in objPool)
			{
				mom += eap.prop; // mom은 모든 가중치를 더한 값이 된다.
				sector.Add(mom); // sector의 각 윈소는 objPool에 들어있는 값을 반영하여 설정되었다.
				/*
				 가령 m1, m2, m3가 각각 19, 20, 30의 가중치를 가지면, sector의 각 원소는 19, 39, 69가 된다.
				 */
			}
			int output = Random.Range(0, mom); // output은 0~69까지의 값 중 임의의 값을 갖게 된다.
			for (int i = 0; i < sector.Count; i++)
			{
				/*
				 아래의 시간 지연 방식은 사용할 수 없다. 
				현재 while 루프는 메인 스레드에서 바쁜 대기(busy-wait)를 해서 프레임 경과를 기다리지 못한다. 
				한 프레임 내에서 루프를 계속 돌기 때문에 Unity가 프레임을 진행시키지 않고,
				Time.deltaTime 값은 같은 프레임의 고정값(프레임 델타)으로 반복 누적되어,
				루프는 즉시 종료되거나(조건을 만족하면 바로 빠져나감) 프레임을 막아버려 아무런 '지연된 동작'처럼 보이지 않는다. 
				Unity에서는 Time.deltaTime을 내부 루프로 기다리면 안 되고, 프레임을 넘기는 방식(코루틴 또는 시간 비교)을 사용해야 한다.
				따라서 현재 스크립트는 동시다발적으로 소환되게 되어 있음
				 */

				if (output <= sector[i]) // output이 만일 30이였다면, 19보다는 크고, 39보다는 작거나 같기에, m2가 소환된다.
				{
					float time = 0f;
					float spawnCycle = 1;
					while (time <= spawnCycle)
					{
						time += Time.deltaTime;
					}
					time = 0f;
					Instantiate(objPool[i].elem, SetLoc(room, player.transform.position), Quaternion.identity);
					//맵에 존재하는 몬스터 카운터에 반영해야 한다
				}
			}
		}
	}
	
	//SetLoc에서는 room의 값을 이용하여, player의 위치에서 일정 거리 떨어진 위치에서만 몬스터가 소환될 수 있도록 위치를 랜덤으로 지정한다.
	public Vector3 SetLoc(RectInt room, Vector3 playerPos) 
	{
		Vector3 loc = new Vector3(Random.Range(room.x, room.x + room.width), Random.Range(room.y, room.y + room.height));
		while (Vector3.Distance(loc, playerPos) < 5.0f)
		{
			loc = new Vector3(Random.Range(room.x, room.x + room.width), Random.Range(room.y, room.y + room.height));
		}
		Debug.Log($"소환 위치 : {room.x}, {room.y}, {room.width}, {room.height}");
		return loc;
	}
}
