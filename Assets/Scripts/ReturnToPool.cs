using System.Collections;
using Services;
using UnityEngine;
using Zenject;

public class ReturnToPool : MonoBehaviour
{
    [SerializeField] private float delay;
    private ExplosionVFXPool _explosionVFXPool;
    private YieldInstruction _delayCoroutine;
    
    [Inject]
    private void Inject(ExplosionVFXPool explosionVFXPool) => _explosionVFXPool = explosionVFXPool;

    private void Awake() => _delayCoroutine = new WaitForSeconds(delay);

    public void OnEnable() => StartCoroutine(ReturnCoroutine());

    private IEnumerator ReturnCoroutine()
    {
        yield return _delayCoroutine;
        _explosionVFXPool.Release(gameObject);
    }
}