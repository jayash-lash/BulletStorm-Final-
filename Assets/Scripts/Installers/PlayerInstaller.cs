using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerTransform;

        public override void InstallBindings()
        {
            BindPlayerTransform();
        }

        private void BindPlayerTransform()
        {
            Container.Bind<Transform>().
                FromInstance(_playerTransform).
                AsSingle();
        }
    }
}