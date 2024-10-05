using Godot;
namespace ld56;

public partial class HighlightCircle : Sprite2D {
  public static HighlightCircle New() {
    return GD.Load<PackedScene>("res://highlight_circle.tscn").Instantiate<HighlightCircle>();
  }
  public HighlightCircle() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class HighlightCircleNodes {
    HighlightCircle parent;

    public HighlightCircleNodes(HighlightCircle parent) {
      this.parent = parent;
    }
  }

  public HighlightCircleNodes? _Nodes;
  public HighlightCircleNodes Nodes {
    get {
      return _Nodes ??= new HighlightCircleNodes(this);
    }
  }
}
