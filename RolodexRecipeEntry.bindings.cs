using Godot;


public partial class RolodexRecipeEntry : PanelContainer {
  public static RolodexRecipeEntry New() {
    return GD.Load<PackedScene>("res://RolodexRecipeEntry.tscn").Instantiate<RolodexRecipeEntry>();
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

    private VBoxContainer? _HBoxContainer_VBoxContainer;
    public VBoxContainer HBoxContainer_VBoxContainer {
      get => _HBoxContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/VBoxContainer");
    }

    private Label? _HBoxContainer_VBoxContainer_Name;
    public Label HBoxContainer_VBoxContainer_Name {
      get => _HBoxContainer_VBoxContainer_Name ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer/Name");
    }

    private Label? _HBoxContainer_VBoxContainer_Characteristic;
    public Label HBoxContainer_VBoxContainer_Characteristic {
      get => _HBoxContainer_VBoxContainer_Characteristic ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer/Characteristic");
    }

    private HBoxContainer? _HBoxContainer_VBoxContainer_Ingredients;
    public HBoxContainer HBoxContainer_VBoxContainer_Ingredients {
      get => _HBoxContainer_VBoxContainer_Ingredients ??= parent.GetNode<HBoxContainer>("HBoxContainer/VBoxContainer/Ingredients");
    }

    private TextureRect? _HBoxContainer_VBoxContainer_Ingredients_TextureRect;
    public TextureRect HBoxContainer_VBoxContainer_Ingredients_TextureRect {
      get => _HBoxContainer_VBoxContainer_Ingredients_TextureRect ??= parent.GetNode<TextureRect>("HBoxContainer/VBoxContainer/Ingredients/TextureRect");
    }

  }

  public RolodexRecipeEntryNodes? _Nodes;
  public RolodexRecipeEntryNodes Nodes {
    get {
      return _Nodes ??= new RolodexRecipeEntryNodes(this);
    }
  }
}
