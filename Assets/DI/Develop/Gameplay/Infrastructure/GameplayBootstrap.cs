using DI.Game.Develop.CommonServices.SceneManagment;
using DI.Game.Develop.DI;
using System.Collections;
using UnityEngine;

namespace DI.Game.Develop.Gameplay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();
                        

            yield return new WaitForSeconds(1f);
        }

        private void ProcessRegistrations()
        {
            

            _container.Initialize();
        }
    }
}