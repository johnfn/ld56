using Godot;


public partial class Newspaper : ColorRect {
  public static Newspaper New() {
    return GD.Load<PackedScene>("res://Scenes/Newspaper.tscn").Instantiate<Newspaper>();
  }
  public Newspaper() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class NewspaperNodes {
    Newspaper parent;

    public NewspaperNodes(Newspaper parent) {
      this.parent = parent;
    }
    private TextureRect? _Newspaper_;
    public TextureRect Newspaper_ {
      get => _Newspaper_ ??= parent.GetNode<TextureRect>("Newspaper");
    }

    private VBoxContainer? _Newspaper_VBoxContainer;
    public VBoxContainer Newspaper_VBoxContainer {
      get => _Newspaper_VBoxContainer ??= parent.GetNode<VBoxContainer>("Newspaper/VBoxContainer");
    }

    private Label? _Newspaper_VBoxContainer_DaysLeft;
    public Label Newspaper_VBoxContainer_DaysLeft {
      get => _Newspaper_VBoxContainer_DaysLeft ??= parent.GetNode<Label>("Newspaper/VBoxContainer/DaysLeft");
    }

    private VBoxContainer? _Newspaper_VBoxContainer_NewspaperContentContainer;
    public VBoxContainer Newspaper_VBoxContainer_NewspaperContentContainer {
      get => _Newspaper_VBoxContainer_NewspaperContentContainer ??= parent.GetNode<VBoxContainer>("Newspaper/VBoxContainer/NewspaperContentContainer");
    }

    private Button? _Newspaper_CloseButton;
    public Button Newspaper_CloseButton {
      get => _Newspaper_CloseButton ??= parent.GetNode<Button>("Newspaper/CloseButton");
    }

    private Button? _Newspaper_ShopButton;
    public Button Newspaper_ShopButton {
      get => _Newspaper_ShopButton ??= parent.GetNode<Button>("Newspaper/ShopButton");
    }

    private NewspaperEntry? _Newspaper_VBoxContainer_NewspaperContentContainer_NewspaperEntry;
    public NewspaperEntry Newspaper_VBoxContainer_NewspaperContentContainer_NewspaperEntry {
      get => _Newspaper_VBoxContainer_NewspaperContentContainer_NewspaperEntry ??= parent.GetNode<NewspaperEntry>("Newspaper/VBoxContainer/NewspaperContentContainer/NewspaperEntry");
    }

  }

  public NewspaperNodes? _Nodes;
  public NewspaperNodes Nodes {
    get {
      return _Nodes ??= new NewspaperNodes(this);
    }
  }
}
