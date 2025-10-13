using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Spawner/SpawnerPool")]

public class SpanwerPoolAssets : ScriptableObject {

	[System.Serializable]
	public struct Elem_And_Prop {
		
			public GameObject elem;
			public int prop;
			Elem_And_Prop(GameObject _elem, int _prop)
			{
				elem = _elem;
				prop = _prop;
			}
	}
	[SerializeField] public List<Elem_And_Prop> pool = new List<Elem_And_Prop>();
}
