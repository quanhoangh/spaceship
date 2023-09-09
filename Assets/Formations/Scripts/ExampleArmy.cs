using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExampleArmy : MonoBehaviour {

    private FormationBase _formation;

    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }
    [SerializeField] public List<Transform> point;
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private float _unitSpeed = 2;

    public readonly List<GameObject> _spawnedUnits = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    private Transform _parent;
    public static ExampleArmy instance;
    public Vector3 pos;
    private void Awake() {
        ExampleArmy.instance = this;
        _parent =  GameObject.Find("Unit Parent").transform;
        point.Clear();
        Transform o = GameObject.Find("point").transform;
            foreach(Transform t in o)
        {
            point.Add(t);
        }
    }

    private void Update() {
        SetFormation();
 

    }

    private void SetFormation() {
        _points = Formation.EvaluatePoints().ToList();

        

        if (_points.Count > _spawnedUnits.Count) {
            var remainingPoints = _points.Skip(_spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if (_points.Count < _spawnedUnits.Count) {
            Kill(_spawnedUnits.Count - _points.Count);
        }

        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
          
      
        }

    }

    private void Spawn(IEnumerable<Vector3> points) {
        foreach (var pos in points) {
            Transform porad = random();
            
            var unit = Instantiate(_unitPrefab,porad.position, transform.rotation, _parent);
            _spawnedUnits.Add(unit);
        }
    }

    private void Kill(int num) {
        for (var i =0; i < num; i++) {
            var unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }
    public virtual void loadPoint()
    {
        if (point.Count > 0) return;
        foreach (Transform Point in point)
        {
            point.Add(Point);
        }
    }
    public virtual Transform random()
    {
        int rand = UnityEngine.Random.Range(0, point.Count);
        return point[rand];

    }
}