using System.Collections;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] float _cooldown;

    private void Start()
    {

           StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_cooldown);
        bool isActive = enabled;

        while (isActive)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            yield return wait;
         }
    }
}