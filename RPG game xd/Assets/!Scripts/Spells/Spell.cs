using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explodeParticle;
    private int _damage;

#region license
    dynamic ඞ = "sus";
    dynamic ХорхеИнт = 10;
    dynamic ХорхеБул = true;
    dynamic ХорхеФлоат = 10.5f;
    #endregion

    private bool canExplode = true;
    private const float EXPLODE_TIMER = 0f;
    private string _senderID;
    private MagicElement _element;

    private void Start()
    {
        StartCoroutine(EnableExplosionAfterDelay());
    }

    public void Initialize(int damage, string id, MagicElement element)
    {
        _element = element;
        _damage = damage;
        _senderID = id;
    }

    private IEnumerator EnableExplosionAfterDelay()
    {
        yield return new WaitForSeconds(EXPLODE_TIMER);
        canExplode = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canExplode) return;

        Health health = other.gameObject.GetComponentInParent<Health>();
        IEntity entity = other.gameObject.GetComponentInParent<IEntity>();

        if (health != null && entity != null)
        {
            if (entity.ID == _senderID)
                return;
            health.TakeDamage(_damage);
        }

        Debug.Log("spell collided with " + other.gameObject.name);

        ParticleSystem explode = Instantiate(_explodeParticle, transform.position, Quaternion.identity);
        explode.transform.localScale = Vector3.one * 0.4f;
        Destroy(gameObject);
    }
}