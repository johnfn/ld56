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

    private HSeparator? _Page1Viewport_MarginContainer_Page1_HSeparator;
    public HSeparator Page1Viewport_MarginContainer_Page1_HSeparator {
      get => _Page1Viewport_MarginContainer_Page1_HSeparator ??= parent.GetNode<HSeparator>("Page1Viewport/MarginContainer/Page1/HSeparator");
    }

    private HSeparator? _Page1Viewport_MarginContainer_Page1_HSeparator2;
    public HSeparator Page1Viewport_MarginContainer_Page1_HSeparator2 {
      get => _Page1Viewport_MarginContainer_Page1_HSeparator2 ??= parent.GetNode<HSeparator>("Page1Viewport/MarginContainer/Page1/HSeparator2");
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

    private TextureRect? _TopPages;
    public TextureRect TopPages {
      get => _TopPages ??= parent.GetNode<TextureRect>("TopPages");
    }

    private TextureRect? _LeftPageContents;
    public TextureRect LeftPageContents {
      get => _LeftPageContents ??= parent.GetNode<TextureRect>("LeftPageContents");
    }

    private TextureRect? _RightPageContents;
    public TextureRect RightPageContents {
      get => _RightPageContents ??= parent.GetNode<TextureRect>("RightPageContents");
    }

    private AudioStreamPlayer2D? _AudioStreamPlayer2D;
    public AudioStreamPlayer2D AudioStreamPlayer2D {
      get => _AudioStreamPlayer2D ??= parent.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

    private RolodexRecipeEntry? _Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry;
    public RolodexRecipeEntry Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry {
      get => _Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry ??= parent.GetNode<RolodexRecipeEntry>("Page1Viewport/MarginContainer/Page1/RolodexRecipeEntry");
    }

    private RolodexRecipeEntry? _Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry2;
    public RolodexRecipeEntry Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry2 {
      get => _Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry2 ??= parent.GetNode<RolodexRecipeEntry>("Page1Viewport/MarginContainer/Page1/RolodexRecipeEntry2");
    }

    private RolodexRecipeEntry? _Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry3;
    public RolodexRecipeEntry Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry3 {
      get => _Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry3 ??= parent.GetNode<RolodexRecipeEntry>("Page1Viewport/MarginContainer/Page1/RolodexRecipeEntry3");
    }

  }

  public RolodexNodes? _Nodes;
  public RolodexNodes Nodes {
    get {
      return _Nodes ??= new RolodexNodes(this);
    }
  }
}
