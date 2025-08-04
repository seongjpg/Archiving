using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
	[SerializeField] private ScriptableObject shieldAsset;
	private IShield shield;

	private void Start()
	{
		shield = shieldAsset as IShield;
		Debug.Log($"{gameObject.name} - asset : {shield}");
		if (shield == null)
			Debug.LogError("shield is NULL");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject collided = collision.gameObject;
		//Active
		if (this.CompareTag("Active"))
		{
		}
		if (this.CompareTag("Passive"))
		{
		}
		if (this.CompareTag("Weapon"))
		{
		}
		if (this.CompareTag("Shield"))
		{
			Debug.Log("¹æ¾î±¸!");
			shield.Upgrade(collided);
			Destroy(this.gameObject);
		}
		if (this.CompareTag("OneTime"))
		{
		}
	}
}
