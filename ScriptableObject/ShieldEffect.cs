using UnityEngine;

[CreateAssetMenu(menuName = "Items/ShieldEffect")]
public class ShieldDefinition : ScriptableObject {
	public string itemName;
	public Sprite icon;

	public ScriptableObject hitRateAsset;
	public ScriptableObject speedAsset;
	private IShield speedCache;
	private IShield hitRateCache;

	public IShield HitRateEffect
	{
		get
		{
			if (hitRateCache == null)
			{
				hitRateCache = hitRateAsset as IShield;
			}
			return hitRateCache;
		}
	}
	public IShield SpeedEffect
	{
		get
		{
			if (speedCache != null)
			{
				speedCache = speedAsset as IShield ;
			}
			return speedCache;
		}
	}
}
