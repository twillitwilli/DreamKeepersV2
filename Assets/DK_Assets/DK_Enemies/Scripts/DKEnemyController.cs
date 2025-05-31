using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class DKEnemyController : MonoBehaviour
{
    PlayerController _playerController;

    DKEnemySpawner _enemySpawner;

    NavMeshAgent _navAgent;

    [SerializeField]
    LayerMask _ignoreLayers;

    public EnemyData enemyStats;

    // ============================= Movement Variables =============================================

    [SerializeField]
    bool _canMove;

    public enum MovementType
    {
        Idle,
        Wandering,
        SetPath,
        Chasing,
        Teleporting,
    }

    public MovementType currentMovement;

    [SerializeField]
    Transform
        currentTarget,
        wanderPoint;

    [SerializeField]
    bool _destroyAtEndPoint;

    [SerializeField]
    List<Transform> SetPathLocations;

    int _currentPath;

    bool _gotToPoint;
    Vector3 _lastPos;

    // ===============================================================================================

    // -------------------- Health Variables ----------------------------

    bool _isDead;

    [SerializeField]
    bool
        _canKnockback,
        _canStun;

    [SerializeField]
    MeshRenderer _meshRenderer;

    [SerializeField]
    Material
        _normalMat,
        _hitMat;

    Rigidbody _rb;

    bool _stunned;
    float _stunCooldown;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _playerController = PlayerController.Instance;
        _enemySpawner = DKEnemySpawner.Instance;

        _rb = GetComponent<Rigidbody>();
    }

    // --------------------- Combat Variables ----------------------------------

    [SerializeField]
    bool _canTargetPlayer;

    public virtual void LateUpdate()
    {
        if (_canMove && !Stunned())
        {
            switch (currentMovement)
            {
                case MovementType.Idle:
                    break;

                case MovementType.Wandering:
                    Wander();
                    break;

                case MovementType.SetPath:
                    break;

                case MovementType.Chasing:
                    break;

                case MovementType.Teleporting:
                    break;
            }
        }
    }

    // --------------------------------- Wandering --------------------------------------------

    public virtual void Wander()
    {
        if (_gotToPoint)
            CheckPathToNewPoint(CreateNewWanderPoint());

        else
        {
            // checks to see if enemy reached the wander position
            if (wanderPoint.position == transform.position)
                _gotToPoint = true;

            currentTarget = wanderPoint;

            float distanceFromPoint = Vector3.Distance(wanderPoint.position, transform.position);
            //WalkingRunningController(distanceFromPoint);

            _navAgent.SetDestination(wanderPoint.position);

            if (distanceFromPoint - 1 <= _navAgent.stoppingDistance)
                _gotToPoint = true;

            _lastPos = transform.position;
        }
    }

    public virtual void CheckPathToNewPoint(Vector3 checkPos)
    {
        RaycastHit hit;
        float range = Vector3.Distance(checkPos, transform.position);

        if (Physics.Raycast(transform.position, checkPos - transform.position, out hit, range, -_ignoreLayers))
        {
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Rock"))
                CreateNewWanderPoint();
        }

        else
            _gotToPoint = false;
    }

    public virtual Vector3 CreateNewWanderPoint()
    {
        wanderPoint.SetParent(null);

        float newX = transform.position.x + Random.Range(-20, 20);
        float newZ = transform.position.z + Random.Range(-20, 20);
        wanderPoint.position = new Vector3(newX, transform.position.y, newZ);

        return wanderPoint.position;
    }

    // -----------------------------------------------------------------------------------------

    // --------------------------------- Set Paths ---------------------------------------------

    public void MovingToNextPoint()
    {
        if (!_gotToPoint && SetPathLocations.Count > 0)
        {
            // checks distance from enemy to current destination
            float distanceFromPoint = Vector3.Distance(SetPathLocations[_currentPath].position, transform.position);

            // sets the nav agents destination to the current position in the path locations
            _navAgent.SetDestination(SetPathLocations[_currentPath].position);

            // checks to see if enemy has made it to their destination
            if (distanceFromPoint - 1 <= _navAgent.stoppingDistance)
            {
                _gotToPoint = true;

                if (SetPathLocations.Count > _currentPath)
                {
                    _currentPath++;
                    _gotToPoint = false;
                }

                if (_destroyAtEndPoint)
                    Destroy(gameObject);
            }
        }
    }

    // -----------------------------------------------------------------------------------------

    private void OnEnable()
    {
        _enemySpawner.currentEnemyCount++;
        wanderPoint.transform.position = transform.position;
    }

    private void OnDisable()
    {
        _enemySpawner.currentEnemyCount--;
    }

    private void OnDestroy()
    {
        _enemySpawner.currentEnemyCount--;
    }

    public void Hit(float damage, Vector3 positionOfObject)
    {
        enemyStats.health -= damage;

        if (damage > 0)
        {
            // took damage
            Debug.Log("took damage = " + damage);

            // if enemy can be knocked back
            if (_canKnockback)
                KnockBack(positionOfObject);

            // if enemy can be stunned
            if (_canStun)
                Stun();

            // if health is less than 0, it dies
            if (enemyStats.health < 0)
                Death();

            // if enemy didnt die apply hit effect to enemy
            else
                HitVisualEffect();
        }

        else
        {
            // healed
            Debug.Log("healed = " + damage);

            // put a limit so that healing cant go over max health
            if (enemyStats.health > enemyStats.maxHealth)
                enemyStats.health = enemyStats.maxHealth;
        }
    }

    async void HitVisualEffect()
    {
        _meshRenderer.material = _hitMat;

        await Task.Delay(1000);

        _meshRenderer.material = _normalMat;
    }

    void KnockBack(Vector3 knockbackFrom)
    {
        // Get the direction to knockback
        Vector3 directionToKnockBack = knockbackFrom - transform.position;

        // add force to the direction being knockedback
        _rb.AddForce(directionToKnockBack * 10);
    }

    void Stun()
    {
        // set stunned status
        _stunned = true;
        _stunCooldown = 3;

        // pause animation
    }

    bool Stunned()
    {
        if (_stunned)
        {
            _stunCooldown -= Time.deltaTime;

            if (_stunCooldown <= 0)
            {
                _stunned = false;

                // unpause animation

                return false;
            }

            else return true;
        }

        else return false;
    }

    public async void Death()
    {
        Debug.Log("Death " + gameObject.name);

        // wait 5 seconds before destroying the object
        await Task.Delay(5000);

        gameObject.SetActive(false);
    }
}
