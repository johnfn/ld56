using Godot;


public partial class NewspaperEntry : HBoxContainer {
  public static NewspaperEntry New() {
    return GD.Load<PackedScene>("res://Scenes/newspaper_entry.tscn").Instantiate<NewspaperEntry>();
  }
  public NewspaperEntry() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class NewspaperEntryNodes {
    NewspaperEntry parent;

    public NewspaperEntryNodes(NewspaperEntry parent) {
      this.parent = parent;
    }
    private TextureRect? _Image;
    public TextureRect Image {
      get => _Image ??= parent.GetNode<TextureRect>("Image");
    }

    private VBoxContainer? _TextContainer;
    public VBoxContainer TextContainer {
      get => _TextContainer ??= parent.GetNode<VBoxContainer>("TextContainer");
    }

    private Label? _TextContainer_Name;
    public Label TextContainer_Name {
      get => _TextContainer_Name ??= parent.GetNode<Label>("TextContainer/Name");
    }

    private Label? _TextContainer_Description;
    public Label TextContainer_Description {
      get => _TextContainer_Description ??= parent.GetNode<Label>("TextContainer/Description");
    }

  }

  public NewspaperEntryNodes? _Nodes;
  public NewspaperEntryNodes Nodes {
    get {
      return _Nodes ??= new NewspaperEntryNodes(this);
    }
  }
}
