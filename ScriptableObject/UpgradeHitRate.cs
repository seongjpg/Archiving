using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/UpgradeHitRate")]
public class UpgradeHitRate : ScriptableObject, IShield
{

    [SerializeField] float hitRateP;

    public string description => $"회피율 증가 : {hitRateP}";
    
    public void Upgrade(GameObject user)
    {
        PlayerManager pm = user.GetComponent<PlayerManager>();
        if (pm != null )
        {
			pm.hitRate *= hitRateP;
		}
        
    }
}
