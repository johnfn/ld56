using Godot;


public partial class ReservationCard : PanelContainer {
  public static ReservationCard New() {
    return GD.Load<PackedScene>("res://Scenes/reservation_card.tscn").Instantiate<ReservationCard>();
  }
  public ReservationCard() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ReservationCardNodes {
    ReservationCard parent;

    public ReservationCardNodes(ReservationCard parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/reservation_card.tscn
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

    private Label? _HBoxContainer_VBoxContainer_NameLabel;
    public Label HBoxContainer_VBoxContainer_NameLabel {
      get => _HBoxContainer_VBoxContainer_NameLabel ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer/NameLabel");
    }

    private Label? _HBoxContainer_VBoxContainer_TimeLabel;
    public Label HBoxContainer_VBoxContainer_TimeLabel {
      get => _HBoxContainer_VBoxContainer_TimeLabel ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer/TimeLabel");
    }

  }

  public ReservationCardNodes? _Nodes;
  public ReservationCardNodes Nodes {
    get {
      return _Nodes ??= new ReservationCardNodes(this);
    }
  }
}
