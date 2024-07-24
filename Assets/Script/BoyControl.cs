using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BoyControl : MonoBehaviour
{
    public Transform Position;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;

    private bool _ifFinished;

    private void Start()
    {
        _navMeshAgent.SetDestination(Position.position);
        _animator.SetBool("IsWalk", true);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Position.position) < 0.5 && !_ifFinished)
        {
            _ifFinished = true;
            _animator.SetBool("IsWalk", false);
            _animator.SetBool("IsFinish", true);
            MoneyManager.onComed.Invoke();
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
