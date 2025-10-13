using System.Collections.Generic;
using UnityEngine;



// 모든 스포너는 스폰되는 구역을 알고 있어야 한다.
public interface IGetArea {
	RoomData GetRoomSize(); 
}

//스포너가 실시간 스폰을 하여야 할 때 사용한다.
public interface ISpawnRealTime {
	void SpawnObj(int limit, RectInt rd, List<SpanwerPoolAssets.Elem_And_Prop> objPool);
}

//스포너가 사전에 스폰을 진행할 경우에 사용한다.
public interface ISpawnInPractice {
	void SpawnObj(int amt, RoomData rd, List<GameObject> objPool);
}


