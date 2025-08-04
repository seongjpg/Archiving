using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/UpgradeHitRate")]
public class UpgradeHitRate : ScriptableObject, IShield
{

    [SerializeField] float hitRateP;

    public string description => $"ȸ���� ���� : {hitRateP}";
    
    public void Upgrade(GameObject user)
    {
        PlayerManager pm = user.GetComponent<PlayerManager>();
        if (pm != null )
        {
			pm.hitRate *= hitRateP;
		}
        
    }
}
