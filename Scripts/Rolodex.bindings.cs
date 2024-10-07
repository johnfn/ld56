using Godot;


public partial class Rolodex : ColorRect {
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
    // Scene: ./Scenes/Rolodex.tscn
    private Button? _ClickOutside;
    public Button ClickOutside {
      get => _ClickOutside ??= parent.GetNode<Button>("ClickOutside");
    }

    private TextureRect? _BookTexture;
    public TextureRect BookTexture {
      get => _BookTexture ??= parent.GetNode<TextureRect>("BookTexture");
    }

    private SubViewport? _BookTexture_Page1Viewport;
    public SubViewport BookTexture_Page1Viewport {
      get => _BookTexture_Page1Viewport ??= parent.GetNode<SubViewport>("BookTexture/Page1Viewport");
    }

    private MarginContainer? _BookTexture_Page1Viewport_MarginContainer;
    public MarginContainer BookTexture_Page1Viewport_MarginContainer {
      get => _BookTexture_Page1Viewport_MarginContainer ??= parent.GetNode<MarginContainer>("BookTexture/Page1Viewport/MarginContainer");
    }

    private VBoxContainer? _BookTexture_Page1Viewport_MarginContainer_Page1;
    public VBoxContainer BookTexture_Page1Viewport_MarginContainer_Page1 {
      get => _BookTexture_Page1Viewport_MarginContainer_Page1 ??= parent.GetNode<VBoxContainer>("BookTexture/Page1Viewport/MarginContainer/Page1");
    }

    private HSeparator? _BookTexture_Page1Viewport_MarginContainer_Page1_HSeparator;
    public HSeparator BookTexture_Page1Viewport_MarginContainer_Page1_HSeparator {
      get => _BookTexture_Page1Viewport_MarginContainer_Page1_HSeparator ??= parent.GetNode<HSeparator>("BookTexture/Page1Viewport/MarginContainer/Page1/HSeparator");
    }

    private HSeparator? _BookTexture_Page1Viewport_MarginContainer_Page1_HSeparator2;
    public HSeparator BookTexture_Page1Viewport_MarginContainer_Page1_HSeparator2 {
      get => _BookTexture_Page1Viewport_MarginContainer_Page1_HSeparator2 ??= parent.GetNode<HSeparator>("BookTexture/Page1Viewport/MarginContainer/Page1/HSeparator2");
    }

    private SubViewport? _BookTexture_Page2Viewport;
    public SubViewport BookTexture_Page2Viewport {
      get => _BookTexture_Page2Viewport ??= parent.GetNode<SubViewport>("BookTexture/Page2Viewport");
    }

    private MarginContainer? _BookTexture_Page2Viewport_MarginContainer;
    public MarginContainer BookTexture_Page2Viewport_MarginContainer {
      get => _BookTexture_Page2Viewport_MarginContainer ??= parent.GetNode<MarginContainer>("BookTexture/Page2Viewport/MarginContainer");
    }

    private VBoxContainer? _BookTexture_Page2Viewport_MarginContainer_Page2;
    public VBoxContainer BookTexture_Page2Viewport_MarginContainer_Page2 {
      get => _BookTexture_Page2Viewport_MarginContainer_Page2 ??= parent.GetNode<VBoxContainer>("BookTexture/Page2Viewport/MarginContainer/Page2");
    }

    private Button? _BookTexture_NextPageButton;
    public Button BookTexture_NextPageButton {
      get => _BookTexture_NextPageButton ??= parent.GetNode<Button>("BookTexture/NextPageButton");
    }

    private Button? _BookTexture_PrevPageButton;
    public Button BookTexture_PrevPageButton {
      get => _BookTexture_PrevPageButton ??= parent.GetNode<Button>("BookTexture/PrevPageButton");
    }

    private Button? _BookTexture_CreaturesTab;
    public Button BookTexture_CreaturesTab {
      get => _BookTexture_CreaturesTab ??= parent.GetNode<Button>("BookTexture/CreaturesTab");
    }

    private Button? _BookTexture_RecipesTab;
    public Button BookTexture_RecipesTab {
      get => _BookTexture_RecipesTab ??= parent.GetNode<Button>("BookTexture/RecipesTab");
    }

    private Button? _BookTexture_IngredientsTab;
    public Button BookTexture_IngredientsTab {
      get => _BookTexture_IngredientsTab ??= parent.GetNode<Button>("BookTexture/IngredientsTab");
    }

    private TextureRect? _BookTexture_TopPages;
    public TextureRect BookTexture_TopPages {
      get => _BookTexture_TopPages ??= parent.GetNode<TextureRect>("BookTexture/TopPages");
    }

    private TextureRect? _BookTexture_LeftPageContents;
    public TextureRect BookTexture_LeftPageContents {
      get => _BookTexture_LeftPageContents ??= parent.GetNode<TextureRect>("BookTexture/LeftPageContents");
    }

    private TextureRect? _BookTexture_RightPageContents;
    public TextureRect BookTexture_RightPageContents {
      get => _BookTexture_RightPageContents ??= parent.GetNode<TextureRect>("BookTexture/RightPageContents");
    }

    private AudioStreamPlayer2D? _AudioStreamPlayer2D;
    public AudioStreamPlayer2D AudioStreamPlayer2D {
      get => _AudioStreamPlayer2D ??= parent.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

    private RolodexRecipeEntry? _BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry;
    public RolodexRecipeEntry BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry {
      get => _BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry ??= parent.GetNode<RolodexRecipeEntry>("BookTexture/Page1Viewport/MarginContainer/Page1/RolodexRecipeEntry");
    }

    private RolodexRecipeEntry? _BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry2;
    public RolodexRecipeEntry BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry2 {
      get => _BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry2 ??= parent.GetNode<RolodexRecipeEntry>("BookTexture/Page1Viewport/MarginContainer/Page1/RolodexRecipeEntry2");
    }

    private RolodexRecipeEntry? _BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry3;
    public RolodexRecipeEntry BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry3 {
      get => _BookTexture_Page1Viewport_MarginContainer_Page1_RolodexRecipeEntry3 ??= parent.GetNode<RolodexRecipeEntry>("BookTexture/Page1Viewport/MarginContainer/Page1/RolodexRecipeEntry3");
    }

  }

  public RolodexNodes? _Nodes;
  public RolodexNodes Nodes {
    get {
      return _Nodes ??= new RolodexNodes(this);
    }
  }
}
