using Godot;


public partial class RolodexCreatureEntry : PanelContainer {
  public static RolodexCreatureEntry New() {
    return GD.Load<PackedScene>("res://RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
  }
  public RolodexCreatureEntry() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RolodexCreatureEntryNodes {
    RolodexCreatureEntry parent;

    public RolodexCreatureEntryNodes(RolodexCreatureEntry parent) {
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

    private HBoxContainer? _HBoxContainer_VBoxContainer_FavoriteDishes;
    public HBoxContainer HBoxContainer_VBoxContainer_FavoriteDishes {
      get => _HBoxContainer_VBoxContainer_FavoriteDishes ??= parent.GetNode<HBoxContainer>("HBoxContainer/VBoxContainer/FavoriteDishes");
    }

    private TextureRect? _HBoxContainer_VBoxContainer_FavoriteDishes_Dish1;
    public TextureRect HBoxContainer_VBoxContainer_FavoriteDishes_Dish1 {
      get => _HBoxContainer_VBoxContainer_FavoriteDishes_Dish1 ??= parent.GetNode<TextureRect>("HBoxContainer/VBoxContainer/FavoriteDishes/Dish1");
    }

    private TextureRect? _HBoxContainer_VBoxContainer_FavoriteDishes_Dish2;
    public TextureRect HBoxContainer_VBoxContainer_FavoriteDishes_Dish2 {
      get => _HBoxContainer_VBoxContainer_FavoriteDishes_Dish2 ??= parent.GetNode<TextureRect>("HBoxContainer/VBoxContainer/FavoriteDishes/Dish2");
    }

    private TextureRect? _HBoxContainer_VBoxContainer_FavoriteDishes_Dish3;
    public TextureRect HBoxContainer_VBoxContainer_FavoriteDishes_Dish3 {
      get => _HBoxContainer_VBoxContainer_FavoriteDishes_Dish3 ??= parent.GetNode<TextureRect>("HBoxContainer/VBoxContainer/FavoriteDishes/Dish3");
    }

  }

  public RolodexCreatureEntryNodes? _Nodes;
  public RolodexCreatureEntryNodes Nodes {
    get {
      return _Nodes ??= new RolodexCreatureEntryNodes(this);
    }
  }
}
