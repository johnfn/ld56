using Godot;


public partial class DayIndicator : Control {
  public static DayIndicator New() {
    return GD.Load<PackedScene>("res://Scripts/day_indicator.tscn").Instantiate<DayIndicator>();
  }
  public DayIndicator() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class DayIndicatorNodes {
    DayIndicator parent;

    public DayIndicatorNodes(DayIndicator parent) {
      this.parent = parent;
    }
    private Sprite2D? _HighlightCircle;
    public Sprite2D HighlightCircle {
      get => _HighlightCircle ??= parent.GetNode<Sprite2D>("HighlightCircle");
    }

    private Sprite2D? _Checkmark;
    public Sprite2D Checkmark {
      get => _Checkmark ??= parent.GetNode<Sprite2D>("Checkmark");
    }

  }

  public DayIndicatorNodes? _Nodes;
  public DayIndicatorNodes Nodes {
    get {
      return _Nodes ??= new DayIndicatorNodes(this);
    }
  }
}
