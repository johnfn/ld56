using Godot;
namespace ld56;

public partial class Camera : Camera2D {
  public static Camera New() {
    return GD.Load<PackedScene>("res://camera.tscn").Instantiate<Camera>();
  }
  public Camera() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CameraNodes {
    Camera parent;

    public CameraNodes(Camera parent) {
      this.parent = parent;
    }
  }

  public CameraNodes? _Nodes;
  public CameraNodes Nodes {
    get {
      return _Nodes ??= new CameraNodes(this);
    }
  }
}
