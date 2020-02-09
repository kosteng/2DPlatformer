using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    private ProjectInfrastructure _projectInfrastructure;
    [SerializeField] private MonoBehaviourServiceLocator _monoBehaviourServiceLocator;

    private void Awake()
    {
        _projectInfrastructure = new ProjectInfrastructure(_monoBehaviourServiceLocator);
    }

    void Start()
    {
        _projectInfrastructure.Start();
    }

    void Update()
    {
        _projectInfrastructure.Update(Time.deltaTime);
    }
    private void FixedUpdate()
    {
        _projectInfrastructure.FixedUpdate(Time.deltaTime);
    }
}
