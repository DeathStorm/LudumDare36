using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using FORMS = ENUMS.FORMS;

public class SmithFormButton : MonoBehaviour
{

    public Stage2_GridManager gridManager;
    public FORMS buttonForm = FORMS.Empty;
    private Image image;

    public Color standardColor;
    public Color activeColor;

    void Start()
    {
        image = this.GetComponent<Image>();
        standardColor = image.color;
    }

    public void SelectForm()
    {
        gridManager.SelectForm(buttonForm);
    }

    void Update()
    {
        if (gridManager.activeForm == buttonForm && image.color != activeColor)
        {
            image.color = activeColor;
        }
        else if (gridManager.activeForm != buttonForm && image.color != standardColor)
        {
            image.color = standardColor;
        }
    }
}
