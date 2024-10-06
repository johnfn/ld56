using Godot;
namespace ld56;

public partial class DialogOptionNode : RichTextLabel {
  public static DialogOptionNode New() {
    return GD.Load<PackedScene>("res://Scenes/dialog_option_node.tscn").Instantiate<DialogOptionNode>();
  }
  public DialogOptionNode() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class DialogOptionNodeNodes {
    DialogOptionNode parent;

    public DialogOptionNodeNodes(DialogOptionNode parent) {
      this.parent = parent;
    }
  }

  public DialogOptionNodeNodes? _Nodes;
  public DialogOptionNodeNodes Nodes {
    get {
      return _Nodes ??= new DialogOptionNodeNodes(this);
    }
  }
}
