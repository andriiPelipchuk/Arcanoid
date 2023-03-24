using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private TextMeshProUGUI _textMesh;

    private int _projectileNumber = 8;

    public static Action<GameObject> addNewProjectile;

    public void CreateProjectile(Vector3 direction)
    {
        var numberSpawn = _projectileNumber;
        StartCoroutine(SpawnCoroutine(direction, numberSpawn));
    }

    public int GetProjectileNumber()
    {
        return _projectileNumber;
    }
    public void TakeAwayProjectile()
    {
        _projectileNumber--;
    }
    public void GiveProjectile()
    {
        _projectileNumber++;
    }

    private IEnumerator SpawnCoroutine(Vector3 dir, int numberSpawn)
    {

        for (int i = numberSpawn; i >= 0; i--)
        {
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            addNewProjectile?.Invoke(projectile);

            var moveProjectile = projectile.GetComponent<Projectile>();
            moveProjectile.SetDirection(dir);

            _textMesh.text = i.ToString();
            yield return new WaitForSeconds(0.2f);
        }
        _textMesh.text = _projectileNumber.ToString();
        _textMesh.gameObject.SetActive(false);
    }

}
