using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Transform _position;
    [SerializeField] private GameObject _boyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Summon());

    }
    private IEnumerator Summon()
    {
        yield return new WaitForSeconds(3f);
        GameObject _boy = Instantiate(_boyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);
        _boy.GetComponent<BoyControl>().Position = _position;
    }
}


