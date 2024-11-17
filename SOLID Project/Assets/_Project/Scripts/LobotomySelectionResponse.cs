using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobotomySelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField]
    private GameObject lobotomyEffectsHolder;

    private List<ILobotomyEffect> _lobotomyEffects;

    private void Start()
    {
        _lobotomyEffects = lobotomyEffectsHolder.GetComponents<ILobotomyEffect>().ToList();
    }

    public void OnDeselect(Transform selection)
    {
        int randomValue = Random.Range(0, _lobotomyEffects.Count);
        _lobotomyEffects[randomValue].StopEffect(selection);
    }

    public void OnSelect(Transform selection)
    {
        int randomValue = Random.Range(0, _lobotomyEffects.Count);
        _lobotomyEffects[randomValue].StartEffect(selection);
    }

}
