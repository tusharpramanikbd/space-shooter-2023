using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.GetComponent<AsteroidHit>() != null)
        {
            other.transform.GetComponent<AsteroidHit>().AsteroidDestroy();
        }
        else if(other.transform.GetComponent<IHitInterface>() != null)
        {
            other.transform.GetComponent<IHitInterface>().HitByLaserBeam();
        }

        Destroy(gameObject);
    }
}
