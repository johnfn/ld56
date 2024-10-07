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

    private HBoxContainer? _BookTexture_PageContents;
    public HBoxContainer BookTexture_PageContents {
      get => _BookTexture_PageContents ??= parent.GetNode<HBoxContainer>("BookTexture/PageContents");
    }

    private MarginContainer? _BookTexture_PageContents_Page1;
    public MarginContainer BookTexture_PageContents_Page1 {
      get => _BookTexture_PageContents_Page1 ??= parent.GetNode<MarginContainer>("BookTexture/PageContents/Page1");
    }

    private VBoxContainer? _BookTexture_PageContents_Page1_Page1;
    public VBoxContainer BookTexture_PageContents_Page1_Page1 {
      get => _BookTexture_PageContents_Page1_Page1 ??= parent.GetNode<VBoxContainer>("BookTexture/PageContents/Page1/Page1");
    }

    private HSeparator? _BookTexture_PageContents_Page1_Page1_HSeparator;
    public HSeparator BookTexture_PageContents_Page1_Page1_HSeparator {
      get => _BookTexture_PageContents_Page1_Page1_HSeparator ??= parent.GetNode<HSeparator>("BookTexture/PageContents/Page1/Page1/HSeparator");
    }

    private HSeparator? _BookTexture_PageContents_Page1_Page1_HSeparator2;
    public HSeparator BookTexture_PageContents_Page1_Page1_HSeparator2 {
      get => _BookTexture_PageContents_Page1_Page1_HSeparator2 ??= parent.GetNode<HSeparator>("BookTexture/PageContents/Page1/Page1/HSeparator2");
    }

    private HSeparator? _BookTexture_PageContents_Page1_Page1_HSeparator3;
    public HSeparator BookTexture_PageContents_Page1_Page1_HSeparator3 {
      get => _BookTexture_PageContents_Page1_Page1_HSeparator3 ??= parent.GetNode<HSeparator>("BookTexture/PageContents/Page1/Page1/HSeparator3");
    }

    private HSeparator? _BookTexture_PageContents_Page1_Page1_HSeparator4;
    public HSeparator BookTexture_PageContents_Page1_Page1_HSeparator4 {
      get => _BookTexture_PageContents_Page1_Page1_HSeparator4 ??= parent.GetNode<HSeparator>("BookTexture/PageContents/Page1/Page1/HSeparator4");
    }

    private MarginContainer? _BookTexture_PageContents_Page2;
    public MarginContainer BookTexture_PageContents_Page2 {
      get => _BookTexture_PageContents_Page2 ??= parent.GetNode<MarginContainer>("BookTexture/PageContents/Page2");
    }

    private VBoxContainer? _BookTexture_PageContents_Page2_Page2;
    public VBoxContainer BookTexture_PageContents_Page2_Page2 {
      get => _BookTexture_PageContents_Page2_Page2 ??= parent.GetNode<VBoxContainer>("BookTexture/PageContents/Page2/Page2");
    }

    private AudioStreamPlayer2D? _AudioStreamPlayer2D;
    public AudioStreamPlayer2D AudioStreamPlayer2D {
      get => _AudioStreamPlayer2D ??= parent.GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
    }

    private Button? _CloseRolodex;
    public Button CloseRolodex {
      get => _CloseRolodex ??= parent.GetNode<Button>("CloseRolodex");
    }

    private RolodexCreatureEntry? _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry;
    public RolodexCreatureEntry BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry {
      get => _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry ??= parent.GetNode<RolodexCreatureEntry>("BookTexture/PageContents/Page1/Page1/RolodexCreatureEntry");
    }

    private RolodexCreatureEntry? _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry2;
    public RolodexCreatureEntry BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry2 {
      get => _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry2 ??= parent.GetNode<RolodexCreatureEntry>("BookTexture/PageContents/Page1/Page1/RolodexCreatureEntry2");
    }

    private RolodexCreatureEntry? _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry3;
    public RolodexCreatureEntry BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry3 {
      get => _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry3 ??= parent.GetNode<RolodexCreatureEntry>("BookTexture/PageContents/Page1/Page1/RolodexCreatureEntry3");
    }

    private RolodexCreatureEntry? _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry4;
    public RolodexCreatureEntry BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry4 {
      get => _BookTexture_PageContents_Page1_Page1_RolodexCreatureEntry4 ??= parent.GetNode<RolodexCreatureEntry>("BookTexture/PageContents/Page1/Page1/RolodexCreatureEntry4");
    }

  }

  public RolodexNodes? _Nodes;
  public RolodexNodes Nodes {
    get {
      return _Nodes ??= new RolodexNodes(this);
    }
  }
}
