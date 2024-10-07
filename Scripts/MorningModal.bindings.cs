using Godot;
namespace ld56;

public partial class MorningModal : Panel {
  public static MorningModal New() {
    return GD.Load<PackedScene>("res://Scenes/morning_modal.tscn").Instantiate<MorningModal>();
  }
  public MorningModal() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class MorningModalNodes {
    MorningModal parent;

    public MorningModalNodes(MorningModal parent) {
      this.parent = parent;
    }
    private RichTextLabel? _GoodMorningLabel;
    public RichTextLabel GoodMorningLabel {
      get => _GoodMorningLabel ??= parent.GetNode<RichTextLabel>("GoodMorningLabel");
    }

    private HBoxContainer? _CheckHBox;
    public HBoxContainer CheckHBox {
      get => _CheckHBox ??= parent.GetNode<HBoxContainer>("CheckHBox");
    }

    private RichTextLabel? _ReservationLabel;
    public RichTextLabel ReservationLabel {
      get => _ReservationLabel ??= parent.GetNode<RichTextLabel>("ReservationLabel");
    }

    private GridContainer? _ReservationList;
    public GridContainer ReservationList {
      get => _ReservationList ??= parent.GetNode<GridContainer>("ReservationList");
    }

    private Button? _DoneButton;
    public Button DoneButton {
      get => _DoneButton ??= parent.GetNode<Button>("DoneButton");
    }

    private DayIndicator? _CheckHBox_DayIndicator;
    public DayIndicator CheckHBox_DayIndicator {
      get => _CheckHBox_DayIndicator ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator");
    }

    private DayIndicator? _CheckHBox_DayIndicator2;
    public DayIndicator CheckHBox_DayIndicator2 {
      get => _CheckHBox_DayIndicator2 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator2");
    }

    private DayIndicator? _CheckHBox_DayIndicator3;
    public DayIndicator CheckHBox_DayIndicator3 {
      get => _CheckHBox_DayIndicator3 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator3");
    }

    private DayIndicator? _CheckHBox_DayIndicator4;
    public DayIndicator CheckHBox_DayIndicator4 {
      get => _CheckHBox_DayIndicator4 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator4");
    }

    private DayIndicator? _CheckHBox_DayIndicator5;
    public DayIndicator CheckHBox_DayIndicator5 {
      get => _CheckHBox_DayIndicator5 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator5");
    }

    private DayIndicator? _CheckHBox_DayIndicator6;
    public DayIndicator CheckHBox_DayIndicator6 {
      get => _CheckHBox_DayIndicator6 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator6");
    }

    private DayIndicator? _CheckHBox_DayIndicator7;
    public DayIndicator CheckHBox_DayIndicator7 {
      get => _CheckHBox_DayIndicator7 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator7");
    }

    private DayIndicator? _CheckHBox_DayIndicator8;
    public DayIndicator CheckHBox_DayIndicator8 {
      get => _CheckHBox_DayIndicator8 ??= parent.GetNode<DayIndicator>("CheckHBox/DayIndicator8");
    }

    private ReservationCard? _ReservationList_PanelContainer;
    public ReservationCard ReservationList_PanelContainer {
      get => _ReservationList_PanelContainer ??= parent.GetNode<ReservationCard>("ReservationList/PanelContainer");
    }

  }

  public MorningModalNodes? _Nodes;
  public MorningModalNodes Nodes {
    get {
      return _Nodes ??= new MorningModalNodes(this);
    }
  }
}
