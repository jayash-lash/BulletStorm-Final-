using FactoryElements.Enemy.EnemyBullet;
using FactoryElements.PlayersBullet;
using UnityEngine;
using Zenject;

public class MissileFactory : MonoBehaviour
{
    [Inject] private DiContainer _diContainer;

    [Header("PlayerPrefabs")]
    [SerializeField] private BaseMissile _ordinaryMissilePrefab;
    [SerializeField] private BaseMissile _homingMissilePrefab;
    [Header("EnemyPrefabs")]
    [SerializeField] private BaseEnemyMissile _directEnemyMissilePrefab;
    [SerializeField] private BaseEnemyMissile _homingEnemyMissileMissilePrefab;
    public void CreateInTwoPositionsOfPlayer(Vector2 position)
    {
        _diContainer.
            InstantiatePrefab(_ordinaryMissilePrefab, position, Quaternion.identity, null);
    }

    public void CreateInOnePositionOfPlayer(Vector2 position)
    {
        _diContainer.
            InstantiatePrefab(_homingMissilePrefab, position, Quaternion.identity, null);
    }

    public void CreateInOnePositionOfEnemy(Vector2 position, EnemyMissileType missileType = EnemyMissileType.Null)
    {
        BaseEnemyMissile currentMissile = null;

        switch (missileType)
        {
            case EnemyMissileType.Homing:
                currentMissile = _homingEnemyMissileMissilePrefab;
                break;
            case EnemyMissileType.Null:
                return;
            default:
                currentMissile = _directEnemyMissilePrefab;
                break;
        }
        _diContainer.InstantiatePrefab(currentMissile, position, Quaternion.identity, null);
    }
}

public enum EnemyMissileType
{
    Null = 0,
    
    Direct = 10,
    Homing
}