using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DottedLine _dotted;
    [SerializeField] private Gun _gun;
    [SerializeField] private TextMeshProUGUI _textMesh, _textLosePopUp, _textWonPopUp;
    [SerializeField] private GameObject _counter, _losePopUp, _wonPopUp;

    private List<GameObject> _projectileArray;

    private Vector3 _direction;
    private int _score = -1;
    private bool _openPopUp = false;

    private void Awake()
    {
        _projectileArray = new List<GameObject>();

        Tile.addCoin += WriteScoreCoin;
        Coin.addCoin += WriteScoreCoin;
        Block.deleteProjectile += RemoveFromArray;
        Gun.addNewProjectile += FillProjectileArray;
        Fine.takeAwayProjectile += GiveCommandTakeAwayProjectile;
        Bonus.giveProjectile += CommandGiveProjectile;
        Door.wonPopUp += OpenWonPopup;

        WriteScoreCoin();
    }
    private void Update()
    {
        PressingMouseButton();
        for(int i = 0; i < _projectileArray.Count; i++)
        {
            print(_projectileArray[i]);
        }
        print(_projectileArray.Count);
    }

    private void PressingMouseButton()
    {
        if(_projectileArray.Count == 0 && !_openPopUp)
        {
            
            if (Input.GetMouseButton(0))
            {
                _counter.SetActive(true);
                _direction = _dotted.ActivateDottedLine();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _dotted.DeactivateDottedLine();
                _gun.CreateProjectile(_direction);
            }
        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OpenWonPopup()
    {
        
        _openPopUp = true;
        _wonPopUp.SetActive(true);
        _textWonPopUp.text = "Score " + _score.ToString();
    }

    private void OpenLosePopUp()
    {
        _openPopUp = true;
        _losePopUp.SetActive(true);
        _textLosePopUp.text = "Score " + _score.ToString();
    }

    private void GiveCommandTakeAwayProjectile(GameObject projectile)
    {
        RemoveFromArray(projectile);
        _gun.TakeAwayProjectile();
    }
    private void CommandGiveProjectile(GameObject projectile)
    {
        RemoveFromArray(projectile);
        _gun.GiveProjectile();
    }
    private void FillProjectileArray(GameObject projectile)
    {
        _projectileArray.Add(projectile);
    }
    private void RemoveFromArray(GameObject projectile)
    {
        _projectileArray.Remove(projectile);
        if (_gun.GetProjectileNumber() <= 0)
            OpenLosePopUp();
    }
    private void WriteScoreCoin()
    {
        _score++;
        _textMesh.text = _score.ToString();
    }
}
