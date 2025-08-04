using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/UpgradeSpeed")]

public class UpgradeSpeed : ScriptableObject, IShield {
	[SerializeField] float speed;

	public string description => $"스피드 증가 : {speed}";
	public void Upgrade(GameObject user)
	{
		PlayerManager pm = user.GetComponent<PlayerManager>();
		if (pm != null)
		{
			pm.speed += speed;
		}
	}
}
