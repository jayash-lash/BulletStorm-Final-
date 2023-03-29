using Common;
using Common.Movement;
using Enemy;
using UnityEngine;
using Zenject;

public class MissileSpawner : MonoBehaviour
{
    [Inject] private MissileFactory _missileFactory;

    [Header("SpawnPositions(Player)")] [SerializeField]
    private Transform[] _defaultMissilePosition;

    [SerializeField] private Transform _homingMissilePosition;

    [SerializeField] private TimerOn _timer;

    [Header("Time(Player)")] [SerializeField]
    private float _timeBetweenSpawnOrdinary;

    [SerializeField] private float _timeBetweenSpawnHoming;

    private float _elapsedTime;
    private EnemyArgs _enemy;

    private void Awake()
    {
        _timer.OnTimeIsOut += OrdinaryMissileOfPlayerSpawning;
        _timer.OnTimeIsOut += HomingMissileOfPlayerSpawning;

        _timer.StartTimer(_timeBetweenSpawnOrdinary);
        _timer.StartTimer(_timeBetweenSpawnHoming);
    }

    private void Update()
    {
        OrdinaryMissileOfPlayerSpawning();
        HomingMissileOfPlayerSpawning();
    }

    private void OrdinaryMissileOfPlayerSpawning()
    {
        var isMousedPressed = Input.GetMouseButton(0);
        // if(isMousedPressed) Debug.Log("Pressed");
        _elapsedTime += Time.deltaTime;
        var isTimePassed = _elapsedTime > _timeBetweenSpawnOrdinary;

        if (!isMousedPressed || !isTimePassed) return;
        _elapsedTime = 0;

        foreach (var point in _defaultMissilePosition)
        {
            if (point == null) break;
            var spawnPoint = point.position;
            _missileFactory.CreateInTwoPositionsOfPlayer(spawnPoint);
        }
    }

    private void HomingMissileOfPlayerSpawning()
    {
        var keyDown = Input.GetKeyDown(KeyCode.E);

        _elapsedTime += Time.deltaTime;
        var isTimePassed = _elapsedTime > _timeBetweenSpawnHoming;

        if (!keyDown || !isTimePassed) return;
        _elapsedTime = 0;

        var spawnPoint = _homingMissilePosition.position;
        _missileFactory.CreateInOnePositionOfPlayer(spawnPoint);
    }
}