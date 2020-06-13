using UnityEngine;

public class BulletFactory : MonoBehaviour, IFactory<BulletView>
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private BulletView _bulletPrefab;
    private Vector2 _startPosition = new Vector2(0f, -7f);

    public BulletView Create()
    {
        var bullet = Instantiate(_bulletPrefab, _startPosition, Quaternion.identity);
        SetParent(bullet);
      //  bullet.gameObject.SetActive(false);

        return bullet;
    }

    private void SetParent(BulletView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}
