using UnityEngine;

public interface IShield {
	void Upgrade(GameObject player);
	string description { get; }
}
