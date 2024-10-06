using Godot;
namespace ld56;

public partial class CookingScreen : Sprite2D {
  public static CookingScreen New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_screen.tscn").Instantiate<CookingScreen>();
  }
  public CookingScreen() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingScreenNodes {
    CookingScreen parent;

    public CookingScreenNodes(CookingScreen parent) {
      this.parent = parent;
    }
    private Sprite2D? _Pot;
    public Sprite2D Pot {
      get => _Pot ??= parent.GetNode<Sprite2D>("Pot");
    }

    private Control? _UI;
    public Control UI {
      get => _UI ??= parent.GetNode<Control>("UI");
    }

    private Button? _UI_CookButton;
    public Button UI_CookButton {
      get => _UI_CookButton ??= parent.GetNode<Button>("UI/CookButton");
    }

    private Button? _UI_IngredientsButton;
    public Button UI_IngredientsButton {
      get => _UI_IngredientsButton ??= parent.GetNode<Button>("UI/IngredientsButton");
    }

    private Button? _UI_RecipesButton;
    public Button UI_RecipesButton {
      get => _UI_RecipesButton ??= parent.GetNode<Button>("UI/RecipesButton");
    }

    private TextureRect? _UI_IngredientSlotsTexture;
    public TextureRect UI_IngredientSlotsTexture {
      get => _UI_IngredientSlotsTexture ??= parent.GetNode<TextureRect>("UI/IngredientSlotsTexture");
    }

    private HBoxContainer? _UI_IngredientSlotsTexture_Container;
    public HBoxContainer UI_IngredientSlotsTexture_Container {
      get => _UI_IngredientSlotsTexture_Container ??= parent.GetNode<HBoxContainer>("UI/IngredientSlotsTexture/Container");
    }

    private CookingResultModal? _UI_CookingResultModal;
    public CookingResultModal UI_CookingResultModal {
      get => _UI_CookingResultModal ??= parent.GetNode<CookingResultModal>("UI/CookingResultModal");
    }

    private CookingIngredient? _UI_IngredientSlotsTexture_Container_CookingIngredient;
    public CookingIngredient UI_IngredientSlotsTexture_Container_CookingIngredient {
      get => _UI_IngredientSlotsTexture_Container_CookingIngredient ??= parent.GetNode<CookingIngredient>("UI/IngredientSlotsTexture/Container/CookingIngredient");
    }

    private CookingIngredient? _UI_IngredientSlotsTexture_Container_CookingIngredient2;
    public CookingIngredient UI_IngredientSlotsTexture_Container_CookingIngredient2 {
      get => _UI_IngredientSlotsTexture_Container_CookingIngredient2 ??= parent.GetNode<CookingIngredient>("UI/IngredientSlotsTexture/Container/CookingIngredient2");
    }

    private CookingIngredient? _UI_IngredientSlotsTexture_Container_CookingIngredient3;
    public CookingIngredient UI_IngredientSlotsTexture_Container_CookingIngredient3 {
      get => _UI_IngredientSlotsTexture_Container_CookingIngredient3 ??= parent.GetNode<CookingIngredient>("UI/IngredientSlotsTexture/Container/CookingIngredient3");
    }

    private CookingIngredient? _UI_IngredientSlotsTexture_Container_CookingIngredient5;
    public CookingIngredient UI_IngredientSlotsTexture_Container_CookingIngredient5 {
      get => _UI_IngredientSlotsTexture_Container_CookingIngredient5 ??= parent.GetNode<CookingIngredient>("UI/IngredientSlotsTexture/Container/CookingIngredient5");
    }

  }

  public CookingScreenNodes? _Nodes;
  public CookingScreenNodes Nodes {
    get {
      return _Nodes ??= new CookingScreenNodes(this);
    }
  }
}
