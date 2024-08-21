using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private float Hp;
    [SerializeField] private Transform hpPosition;
    [SerializeField] private UnitHealth health;

    [SerializeField] private UIHealthBar healthBarPrefab;
    private UIHealthBar healthBarInstance;

    private void Start()
    {
        health.Init(this);
        health.SetMaxHp(Hp);
        healthBarInstance = Instantiate(healthBarPrefab);
        healthBarInstance.GetComponent<FollowTransform>().SetTarget(hpPosition);
        
        healthBarInstance.setFillHp(1);
    }

    public void UpdateHealthBar(float percent, bool isDead)
    {
        if (isDead)
        {
            Destroy(gameObject);
            Destroy(healthBarInstance.gameObject);
        }
        healthBarInstance.setFillHp(percent);
    }
}
