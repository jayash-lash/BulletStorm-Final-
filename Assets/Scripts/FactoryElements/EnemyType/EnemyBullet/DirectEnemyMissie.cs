using UnityEngine;

namespace FactoryElements.Enemy.EnemyBullet
{
    public class DirectEnemyMissie : BaseEnemyMissile
    {
        protected override void MovementDirection()
        {
            _transform.position += Vector3.down * (_speed * Time.deltaTime);
        }
    }
}