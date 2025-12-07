using Configs;
using UnityEngine;

namespace Factory
{
    public class ViewFactory<T, C> where T : MonoBehaviour where C : ItemConfig
    {
        public T Create(C config, Transform parent)
        {
            GameObject gameObject = Object.Instantiate(config.ItemPrefab, parent);

            T component = gameObject.GetComponent<T>();

            if (component == null)
            {
                Debug.LogError($"ViewFactory: Component {typeof(T)} not found in {gameObject.name}");
            }

            return component;
        }
    }
}
