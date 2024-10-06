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
    private TextureRect? _IngredientImage;
    public TextureRect IngredientImage {
      get => _IngredientImage ??= parent.GetNode<TextureRect>("IngredientImage");
    }

    private HBoxContainer? _HBoxContainer2;
    public HBoxContainer HBoxContainer2 {
      get => _HBoxContainer2 ??= parent.GetNode<HBoxContainer>("HBoxContainer2");
    }

    private RichTextLabel? _NameLabel;
    public RichTextLabel NameLabel {
      get => _NameLabel ??= parent.GetNode<RichTextLabel>("NameLabel");
    }

    private RichTextLabel? _QuantityLabel;
    public RichTextLabel QuantityLabel {
      get => _QuantityLabel ??= parent.GetNode<RichTextLabel>("QuantityLabel");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
