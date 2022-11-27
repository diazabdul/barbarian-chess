using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class UnitManager : MonoBehaviourPunCallbacks
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;
    //public int _countObjective;

    public BaseUnit OccupiedUnit;

    public BaseHero SelectedHero;
    private bool status = true;
    private bool finish = false;
    public int moveSuggest;

    public List<Vector2> _data = new List<Vector2>();
    public List<Tile> _tiles = new List<Tile>();
    private Tile spawnHero, spawnObjective;

    public Vector2[] Objective, Hero, Obstacle, Flag, Hole;
    public int counting, walkcount, maxWalk = 0;
    private string temp;

    public Transform path;

    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }
    private void Start()
    {
        int x = Random.Range(0, GridManager.Instance._width);
        int y = Random.Range(0, GridManager.Instance._height);
        path.transform.position = new Vector2(x, y);
    }
    private void Update()
    {


    }
    public void turnOff()
    {
        for(int i = 0; i < _tiles.Count; i++)
        {
            if(_tiles[i]._highlight.active == true)
            {
                _tiles[i]._highlight.SetActive(false);
            }
        }
    }
    public void SpawnHeroes()
    {       
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
            //var spawnedHero = Instantiate(randomPrefab);
            //spawnHero = GridManager.Instance.GetHeroRespawnTile(0,0);
            Vector2 randomPosition = new Vector2(Random.Range(0, 5), Random.Range(0, 5));
 
        //if(photonization.Instance.view == null)
        //{
            /*photonization.Instance.view =  */PhotonNetwork.Instantiate(randomPrefab.name, randomPosition, Quaternion.identity);
        //}
        //else
        //{
        //    photonization.Instance.view1 = PhotonNetwork.Instantiate(randomPrefab.name, randomPosition, Quaternion.identity);
        //}
            
        
            //spawnHero.SetUnit(spawnedHero);
        
        GameManager.Instance.ChangeState(GameState.HeroesTurn);

    }
    public void highlightTurn(Transform pos, bool activator)
    {
        int generator = Random.Range(1, 3);
        Debug.Log("This is generator " + generator);
        for(int i= 0; i < _tiles.Count; i++)
        {
            if (getVector2(_tiles[i].name).x == pos.position.x && getVector2(_tiles[i].name).y == pos.position.y)
            {
                if(generator == 1)
                {
                    for (int x = 0; x < _tiles.Count; x++)
                    {
                        if (getVector2(_tiles[x].name).y == pos.position.y)
                        {
                            _tiles[x]._highlight.SetActive(activator);
                        }
                    }
                }
                else if(generator==2)
                {
                    for (int x = 0; x < _tiles.Count; x++)
                    {
                        if (getVector2(_tiles[x].name).x == pos.position.x)
                        {
                            _tiles[x]._highlight.SetActive(activator);
                        }
                    }
                }
                else
                {
                    Debug.Log("This is Number of Generator Bitch"+generator);
                }                
            }            
        }
    }

  
    public void getMove(Tile tile)
    {
        if(tile._highlight.active == true || tile.tag=="Player")
        {
            path.transform.position = tile.transform.position;
            //networkHero.Instance.SetState(networkHero.state.nonactive);
            //networkHero.Instance.setState(networkHero.state.nonactive);
        }
        else
        {
            Debug.Log("Salah Tiles");
        }
        
    }
    public bool validation(Transform pos)
    {
        for(int i=0; i < _tiles.Count; i++)
        {
            if (_tiles[i].transform == pos && _tiles[i]._highlight.active == true)
            {
                return true;
                
            }
            else { return false; }
        }
        return false;
    }
    public void getPos(Tile tile)
    {        
        _tiles.Add(tile);
        _data.Add(getVector2(tile.name));
        //for(int i=0; i < _tiles.Count; i++)
        //{
        //    Debug.Log(_tiles[i].name);
        //}
        //Debug.Log(" Ini Index ke 0"+ _tiles[0].name);
    }
    public Vector2 getVector2(string rString)
    {
        string[] temp = rString.Split(' ');
        float x = System.Convert.ToSingle(temp[1]);
        float y = System.Convert.ToSingle(temp[2]);
        Vector2 rValue = new Vector2(x, y);
        return rValue;
    }
    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
    public void SetSelectedHero(BaseHero hero)
    {
        SelectedHero = hero;
        //MenuManager.Instance.ShowSelectedHero(hero);
    }
}
