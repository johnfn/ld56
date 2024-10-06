using Godot;


public partial class Rolodex : Sprite2D {
  public static Rolodex New() {
    return GD.Load<PackedScene>("res://Scenes/Rolodex.tscn").Instantiate<Rolodex>();
  }
  public Rolodex() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RolodexNodes {
    Rolodex parent;

    public RolodexNodes(Rolodex parent) {
      this.parent = parent;
    }
    private SubViewport? _Page1Viewport;
    public SubViewport Page1Viewport {
      get => _Page1Viewport ??= parent.GetNode<SubViewport>("Page1Viewport");
    }

    private MarginContainer? _Page1Viewport_MarginContainer;
    public MarginContainer Page1Viewport_MarginContainer {
      get => _Page1Viewport_MarginContainer ??= parent.GetNode<MarginContainer>("Page1Viewport/MarginContainer");
    }

    private VBoxContainer? _Page1Viewport_MarginContainer_Page1;
    public VBoxContainer Page1Viewport_MarginContainer_Page1 {
      get => _Page1Viewport_MarginContainer_Page1 ??= parent.GetNode<VBoxContainer>("Page1Viewport/MarginContainer/Page1");
    }

    private SubViewport? _Page2Viewport;
    public SubViewport Page2Viewport {
      get => _Page2Viewport ??= parent.GetNode<SubViewport>("Page2Viewport");
    }

    private MarginContainer? _Page2Viewport_MarginContainer;
    public MarginContainer Page2Viewport_MarginContainer {
      get => _Page2Viewport_MarginContainer ??= parent.GetNode<MarginContainer>("Page2Viewport/MarginContainer");
    }

    private VBoxContainer? _Page2Viewport_MarginContainer_Page2;
    public VBoxContainer Page2Viewport_MarginContainer_Page2 {
      get => _Page2Viewport_MarginContainer_Page2 ??= parent.GetNode<VBoxContainer>("Page2Viewport/MarginContainer/Page2");
    }

    private TextureRect? _TextureRect;
    public TextureRect TextureRect {
      get => _TextureRect ??= parent.GetNode<TextureRect>("TextureRect");
    }

    private TextureRect? _TextureRect2;
    public TextureRect TextureRect2 {
      get => _TextureRect2 ??= parent.GetNode<TextureRect>("TextureRect2");
    }

    private Button? _NextPageButton;
    public Button NextPageButton {
      get => _NextPageButton ??= parent.GetNode<Button>("NextPageButton");
    }

    private Button? _PrevPageButton;
    public Button PrevPageButton {
      get => _PrevPageButton ??= parent.GetNode<Button>("PrevPageButton");
    }

    private Button? _CreaturesTab;
    public Button CreaturesTab {
      get => _CreaturesTab ??= parent.GetNode<Button>("CreaturesTab");
    }

    private Button? _RecipesTab;
    public Button RecipesTab {
      get => _RecipesTab ??= parent.GetNode<Button>("RecipesTab");
    }

    private Button? _IngredientsTab;
    public Button IngredientsTab {
      get => _IngredientsTab ??= parent.GetNode<Button>("IngredientsTab");
    }

    private AudioStreamPlayer2D? _AudioStreamPlayer2D;
    public AudioStreamPlayer2D AudioStreamPlayer2D {
      get => _AudioStreamPlayer2D ??= parent.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

  }

  public RolodexNodes? _Nodes;
  public RolodexNodes Nodes {
    get {
      return _Nodes ??= new RolodexNodes(this);
    }
  }
}
