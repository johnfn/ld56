using Godot;


public partial class RolodexRecipeEntry : PanelContainer {
  public static RolodexRecipeEntry New() {
    return GD.Load<PackedScene>("res://Scenes/RolodexRecipeEntry.tscn").Instantiate<RolodexRecipeEntry>();
  }
  public RolodexRecipeEntry() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RolodexRecipeEntryNodes {
    RolodexRecipeEntry parent;

    public RolodexRecipeEntryNodes(RolodexRecipeEntry parent) {
      this.parent = parent;
    }
    private HBoxContainer? _HBoxContainer;
    public HBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<HBoxContainer>("HBoxContainer");
    }

    private TextureRect? _HBoxContainer_TextureRect;
    public TextureRect HBoxContainer_TextureRect {
      get => _HBoxContainer_TextureRect ??= parent.GetNode<TextureRect>("HBoxContainer/TextureRect");
    }

    private VBoxContainer? _HBoxContainer_TextContainer;
    public VBoxContainer HBoxContainer_TextContainer {
      get => _HBoxContainer_TextContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/TextContainer");
    }

    private Label? _HBoxContainer_TextContainer_Name;
    public Label HBoxContainer_TextContainer_Name {
      get => _HBoxContainer_TextContainer_Name ??= parent.GetNode<Label>("HBoxContainer/TextContainer/Name");
    }

    private Label? _HBoxContainer_TextContainer_Description;
    public Label HBoxContainer_TextContainer_Description {
      get => _HBoxContainer_TextContainer_Description ??= parent.GetNode<Label>("HBoxContainer/TextContainer/Description");
    }

    private HBoxContainer? _HBoxContainer_TextContainer_Ingredients;
    public HBoxContainer HBoxContainer_TextContainer_Ingredients {
      get => _HBoxContainer_TextContainer_Ingredients ??= parent.GetNode<HBoxContainer>("HBoxContainer/TextContainer/Ingredients");
    }

    private RolodexRecipeEntryIngredient? _HBoxContainer_TextContainer_Ingredients_Ingredient1;
    public RolodexRecipeEntryIngredient HBoxContainer_TextContainer_Ingredients_Ingredient1 {
      get => _HBoxContainer_TextContainer_Ingredients_Ingredient1 ??= parent.GetNode<RolodexRecipeEntryIngredient>("HBoxContainer/TextContainer/Ingredients/Ingredient1");
    }

    private RolodexRecipeEntryIngredient? _HBoxContainer_TextContainer_Ingredients_Ingredient2;
    public RolodexRecipeEntryIngredient HBoxContainer_TextContainer_Ingredients_Ingredient2 {
      get => _HBoxContainer_TextContainer_Ingredients_Ingredient2 ??= parent.GetNode<RolodexRecipeEntryIngredient>("HBoxContainer/TextContainer/Ingredients/Ingredient2");
    }

    private RolodexRecipeEntryIngredient? _HBoxContainer_TextContainer_Ingredients_Ingredient3;
    public RolodexRecipeEntryIngredient HBoxContainer_TextContainer_Ingredients_Ingredient3 {
      get => _HBoxContainer_TextContainer_Ingredients_Ingredient3 ??= parent.GetNode<RolodexRecipeEntryIngredient>("HBoxContainer/TextContainer/Ingredients/Ingredient3");
    }

  }

  public RolodexRecipeEntryNodes? _Nodes;
  public RolodexRecipeEntryNodes Nodes {
    get {
      return _Nodes ??= new RolodexRecipeEntryNodes(this);
    }
  }
}
