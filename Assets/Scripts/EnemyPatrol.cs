using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;
    private GameObject _target;
    private Animator _animator;
    private Weapon _weapon;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }
    // Update is called once per frame
    void Update()
    {        
    }
    private void UpdateTarget()
    {
        //Si es el la primera vez lo inicializamos
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
        // si esta a la izquierda cambiar a la derecha
        if(_target.transform.position.x==minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        // si esta a la izquierda cambiar a la derecha
       else if (_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private IEnumerator PatrolToTarget()
    {
        // Corutine to move the enemy
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            //actualiza animator
            _animator.SetBool("Idle", false);
            Debug.Log("Caminar");
            //caminar

            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            // IMPORTANTE
            yield return null;
        }
        //
       
        Debug.Log("Llego al target");
        
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        UpdateTarget();

        _animator.SetBool("Idle", true);
        //if (_weapon != null)
        //{
        //    _weapon.Shoot();
        //}
        //Otra manera es de la siguiente:

        _animator.SetTrigger("Shoot");
        //esperamos un momento
        Debug.Log("Esperar por "+ waitingTime + " segundos");
        //Importante "LLAMARSE NUEVAMENTE DESPUES DE x SEGUNDOS"
        yield return new WaitForSeconds(waitingTime);
        //
        Debug.Log("");
       
        StartCoroutine("PatrolToTarget");
    }
    public void CanShoot()
    {
        if (_weapon != null)
        {
            _weapon.Shoot();
        }
    }
}

