using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //플레이어의 이동 방식 / 플레이어 체력 가감 
    private GameObject player;
    [SerializeField] GameObject UI;
    private HeartUI heartUI;
    public PlayerManager pm;
	public Transform playerTr;
	public GameObject playerWeapon;
    public float fireTimer;

    void Start()
    {
        //플레이어 게임 오브젝트 내에 존재하는 PlayerManager를 뽑아온다.
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerManager>();
		playerTr = player.GetComponent<Transform>();
        heartUI = UI.GetComponent<HeartUI>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject collided = collision.gameObject;
		//적과 충돌시
		if (collided.CompareTag("Enemy"))
		{
            MobManager mm = collided.GetComponent<MobManager>();
				    pm.curHealth -= mm.damage;
            if (pm.curHealth < 0) pm.curHealth = 0;
            //ui에서의 작용도 해줘야 한다.
            heartUI.HealthChange(pm.curHealth);
		}

    public void EarnHeal()
    {
        heartUI.HealthChange(pm.curHealth);
    }
}
