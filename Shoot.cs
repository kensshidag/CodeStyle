using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _delay;

    void Start()
    {
        StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        WaitForSeconds delay = new (_delay);
        Vector3 direction;
        Vector3 velocity;
        Bullet newBullet;

        while (enabled)
        {
            direction = (_objectToShoot.position - transform.position).normalized;
            newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            velocity = direction * _speed;

            newBullet.transform.up = direction;
            newBullet.SetVelocity(velocity);

            yield return delay;
        }
    }
}