using Configs;
using UnityEngine;

namespace Factory
{
    public class ViewFactory<T, C> where T : MonoBehaviour where C : ItemConfig
    {
        private GameObject _prefab;

        public ViewFactory(GameObject prefab)
        {
            _prefab = prefab;
        }

        public T Create(Transform parent)
        {
            GameObject gameObject = Object.Instantiate(_prefab, parent);

            T component = gameObject.GetComponent<T>();

            if (component == null)
            {
                Debug.LogError($"ViewFactory: Component {typeof(T)} not found in {gameObject.name}");
            }

            return component;
        }
    }
}
