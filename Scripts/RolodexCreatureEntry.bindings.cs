using Godot;


public partial class RolodexCreatureEntry : PanelContainer {
  public static RolodexCreatureEntry New() {
    return GD.Load<PackedScene>("res://Scenes/RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
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
    // Scene: ./Scenes/RolodexCreatureEntry.tscn
    private HBoxContainer? _HBoxContainer;
    public HBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<HBoxContainer>("HBoxContainer");
    }

    private TextureRect? _HBoxContainer_TextureRect;
    public TextureRect HBoxContainer_TextureRect {
      get => _HBoxContainer_TextureRect ??= parent.GetNode<TextureRect>("HBoxContainer/TextureRect");
    }

    private VBoxContainer? _HBoxContainer_FavoriteDishes;
    public VBoxContainer HBoxContainer_FavoriteDishes {
      get => _HBoxContainer_FavoriteDishes ??= parent.GetNode<VBoxContainer>("HBoxContainer/FavoriteDishes");
    }

    private TextureRect? _HBoxContainer_FavoriteDishes_Dish1;
    public TextureRect HBoxContainer_FavoriteDishes_Dish1 {
      get => _HBoxContainer_FavoriteDishes_Dish1 ??= parent.GetNode<TextureRect>("HBoxContainer/FavoriteDishes/Dish1");
    }

    private Label? _HBoxContainer_FavoriteDishes_Dish1_QuestionMark;
    public Label HBoxContainer_FavoriteDishes_Dish1_QuestionMark {
      get => _HBoxContainer_FavoriteDishes_Dish1_QuestionMark ??= parent.GetNode<Label>("HBoxContainer/FavoriteDishes/Dish1/QuestionMark");
    }

    private TextureRect? _HBoxContainer_FavoriteDishes_Dish2;
    public TextureRect HBoxContainer_FavoriteDishes_Dish2 {
      get => _HBoxContainer_FavoriteDishes_Dish2 ??= parent.GetNode<TextureRect>("HBoxContainer/FavoriteDishes/Dish2");
    }

    private Label? _HBoxContainer_FavoriteDishes_Dish2_QuestionMark;
    public Label HBoxContainer_FavoriteDishes_Dish2_QuestionMark {
      get => _HBoxContainer_FavoriteDishes_Dish2_QuestionMark ??= parent.GetNode<Label>("HBoxContainer/FavoriteDishes/Dish2/QuestionMark");
    }

    private TextureRect? _HBoxContainer_FavoriteDishes_Dish3;
    public TextureRect HBoxContainer_FavoriteDishes_Dish3 {
      get => _HBoxContainer_FavoriteDishes_Dish3 ??= parent.GetNode<TextureRect>("HBoxContainer/FavoriteDishes/Dish3");
    }

    private Label? _HBoxContainer_FavoriteDishes_Dish3_QuestionMark;
    public Label HBoxContainer_FavoriteDishes_Dish3_QuestionMark {
      get => _HBoxContainer_FavoriteDishes_Dish3_QuestionMark ??= parent.GetNode<Label>("HBoxContainer/FavoriteDishes/Dish3/QuestionMark");
    }

    private VBoxContainer? _HBoxContainer_TextContainer;
    public VBoxContainer HBoxContainer_TextContainer {
      get => _HBoxContainer_TextContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/TextContainer");
    }

    private Label? _HBoxContainer_TextContainer_Name;
    public Label HBoxContainer_TextContainer_Name {
      get => _HBoxContainer_TextContainer_Name ??= parent.GetNode<Label>("HBoxContainer/TextContainer/Name");
    }

    private VBoxContainer? _HBoxContainer_TextContainer_KnownInformationContainer;
    public VBoxContainer HBoxContainer_TextContainer_KnownInformationContainer {
      get => _HBoxContainer_TextContainer_KnownInformationContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/TextContainer/KnownInformationContainer");
    }

    private Label? _HBoxContainer_TextContainer_KnownInformationContainer_Characteristic;
    public Label HBoxContainer_TextContainer_KnownInformationContainer_Characteristic {
      get => _HBoxContainer_TextContainer_KnownInformationContainer_Characteristic ??= parent.GetNode<Label>("HBoxContainer/TextContainer/KnownInformationContainer/Characteristic");
    }

    private Label? _HBoxContainer_TextContainer_KnownInformationContainer_Characteristic2;
    public Label HBoxContainer_TextContainer_KnownInformationContainer_Characteristic2 {
      get => _HBoxContainer_TextContainer_KnownInformationContainer_Characteristic2 ??= parent.GetNode<Label>("HBoxContainer/TextContainer/KnownInformationContainer/Characteristic2");
    }

    private Label? _HBoxContainer_TextContainer_KnownInformationContainer_Characteristic3;
    public Label HBoxContainer_TextContainer_KnownInformationContainer_Characteristic3 {
      get => _HBoxContainer_TextContainer_KnownInformationContainer_Characteristic3 ??= parent.GetNode<Label>("HBoxContainer/TextContainer/KnownInformationContainer/Characteristic3");
    }

  }

  public RolodexCreatureEntryNodes? _Nodes;
  public RolodexCreatureEntryNodes Nodes {
    get {
      return _Nodes ??= new RolodexCreatureEntryNodes(this);
    }
  }
}
