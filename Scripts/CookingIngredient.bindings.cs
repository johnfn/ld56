using Godot;


public partial class CookingIngredient : PanelContainer {
  public static CookingIngredient New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_ingredient.tscn").Instantiate<CookingIngredient>();
  }
  public CookingIngredient() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingIngredientNodes {
    CookingIngredient parent;

    public CookingIngredientNodes(CookingIngredient parent) {
      this.parent = parent;
    }
    private HBoxContainer? _HBoxContainer;
    public HBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<HBoxContainer>("HBoxContainer");
    }

    private TextureRect? _HBoxContainer_IngredientImage;
    public TextureRect HBoxContainer_IngredientImage {
      get => _HBoxContainer_IngredientImage ??= parent.GetNode<TextureRect>("HBoxContainer/IngredientImage");
    }

    private MarginContainer? _HBoxContainer_MarginContainer;
    public MarginContainer HBoxContainer_MarginContainer {
      get => _HBoxContainer_MarginContainer ??= parent.GetNode<MarginContainer>("HBoxContainer/MarginContainer");
    }

    private VBoxContainer? _HBoxContainer_MarginContainer_VBoxContainer;
    public VBoxContainer HBoxContainer_MarginContainer_VBoxContainer {
      get => _HBoxContainer_MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/MarginContainer/VBoxContainer");
    }

    private RichTextLabel? _HBoxContainer_MarginContainer_VBoxContainer_NameLabel;
    public RichTextLabel HBoxContainer_MarginContainer_VBoxContainer_NameLabel {
      get => _HBoxContainer_MarginContainer_VBoxContainer_NameLabel ??= parent.GetNode<RichTextLabel>("HBoxContainer/MarginContainer/VBoxContainer/NameLabel");
    }

    private RichTextLabel? _HBoxContainer_MarginContainer_VBoxContainer_QuantityLabel;
    public RichTextLabel HBoxContainer_MarginContainer_VBoxContainer_QuantityLabel {
      get => _HBoxContainer_MarginContainer_VBoxContainer_QuantityLabel ??= parent.GetNode<RichTextLabel>("HBoxContainer/MarginContainer/VBoxContainer/QuantityLabel");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
