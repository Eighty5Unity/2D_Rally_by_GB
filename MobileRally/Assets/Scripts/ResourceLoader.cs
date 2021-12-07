using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
public static GameObject LoadPrefab(ResourcePath path)
    {
        return Resources.Load<GameObject>(path.PathResource);
    }
}
