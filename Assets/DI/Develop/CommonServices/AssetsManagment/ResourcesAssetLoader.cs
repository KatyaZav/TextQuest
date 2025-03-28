using UnityEngine;

namespace DI.Game.Develop.CommonServices.AssetsManagment
{
    public class ResourcesAssetLoader
    {
        public T LoadResource<T>(string resourcePath) where T : Object
        {
            var loaded = Resources.Load<T>(resourcePath);
            if (loaded == null)
                throw new System.Exception($"Can't find {typeof(T)} in path: {resourcePath}");

            return loaded;
        }
    }
}