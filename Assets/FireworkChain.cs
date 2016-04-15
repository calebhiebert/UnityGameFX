using System;
using UnityEngine;
using System.Collections;

public class FireworkChain : MonoBehaviour {

    enum Mode
    {
        MiddleOut, Left, Right, OutIn
    }

    public bool spawn;

    [SerializeField]
    private Mode _spawningMode;

    [SerializeField]
    private float _timeBetweenShots;

    [SerializeField]
    private int _numShots;

    [SerializeField]
    private float _distanceBetweenShots;

    [SerializeField]
    private GameObject _shotPrefab;

    void Update()
    {
        if (spawn)
        {
            Start();
            spawn = false;
        }
    }

    void Start()
    {
        switch (_spawningMode)
        {
            case Mode.MiddleOut:
                StartCoroutine(SpawnCenter());
                break;
            case Mode.Left:
                StartCoroutine(SpawnLeft());
                break;
            case Mode.Right:
                StartCoroutine(SpawnRight());
                break;
            case Mode.OutIn:
                StartCoroutine(SpawnOutIn());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    IEnumerator SpawnLeft()
    {
        for (int i = -_numShots; i < _numShots; i++)
        {
            var newFirework = Instantiate(_shotPrefab);

            newFirework.transform.SetParent(transform, false);

            newFirework.transform.position = new Vector3(_distanceBetweenShots*i, transform.position.y, 5);

            if (Application.isPlaying)
            {
                Destroy(newFirework, 5);
            }

            yield return new WaitForSeconds(_timeBetweenShots);
        }

        if (Application.isEditor && !Application.isPlaying)
        {
            Invoke("DestroyAll", 10);
        }
    }

    IEnumerator SpawnRight()
    {
        for (int i = _numShots; i > -_numShots; i--)
        {
            var newFirework = Instantiate(_shotPrefab);

            newFirework.transform.SetParent(transform, false);

            newFirework.transform.position = new Vector3(_distanceBetweenShots*i, transform.position.y, 5);

            if (Application.isPlaying)
            {
                Destroy(newFirework, 5);
            }

            yield return new WaitForSeconds(_timeBetweenShots);
        }

        if (Application.isEditor && !Application.isPlaying)
        {
            Invoke("DestroyAll", 10);
        }
    }

    IEnumerator SpawnCenter()
    {
        for (int i = 0; i < _numShots; i++)
        {
            var newFirework = Instantiate(_shotPrefab);
            newFirework.transform.SetParent(transform, false);
            newFirework.transform.position = new Vector3(_distanceBetweenShots * i, transform.position.y, 5);

            var newFirework2 = Instantiate(_shotPrefab);
            newFirework2.transform.SetParent(transform, false);
            newFirework2.transform.position = new Vector3(_distanceBetweenShots * -i, transform.position.y, 5);

            if (Application.isPlaying)
            {
                Destroy(newFirework, 5);
                Destroy(newFirework2, 5);
            }

            yield return new WaitForSeconds(_timeBetweenShots);
        }

        if (Application.isEditor && !Application.isPlaying)
        {
            Invoke("DestroyAll", 10);
        }
    }

    IEnumerator SpawnOutIn()
    {
        for (int i = _numShots; i > 0; i--)
        {
            var newFirework = Instantiate(_shotPrefab);
            newFirework.transform.SetParent(transform, false);
            newFirework.transform.position = new Vector3(_distanceBetweenShots * i, transform.position.y, 5);

            var newFirework2 = Instantiate(_shotPrefab);
            newFirework2.transform.SetParent(transform, false);
            newFirework2.transform.position = new Vector3(_distanceBetweenShots * -i, transform.position.y, 5);

            if (Application.isPlaying)
            {
                Destroy(newFirework, 5);
                Destroy(newFirework2, 5);
            }

            yield return new WaitForSeconds(_timeBetweenShots);
        }

        if (Application.isEditor && !Application.isPlaying)
        {
            Invoke("DestroyAll", 10);
        }
    }

    void DestroyAll()
    {
        foreach (var t in GetComponentsInChildren<Transform>())
        {

            if (t != transform)
            {
                DestroyImmediate(t);
            }
        }
    }
}
