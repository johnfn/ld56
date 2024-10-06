using Godot;
namespace ld56;

public partial class DialogOptionNode : PanelContainer {
  public static DialogOptionNode New() {
    return GD.Load<PackedScene>("res://Scenes/DialogOptionNode.tscn").Instantiate<DialogOptionNode>();
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
    private RichTextLabel? _RichTextLabel;
    public RichTextLabel RichTextLabel {
      get => _RichTextLabel ??= parent.GetNode<RichTextLabel>("RichTextLabel");
    }

  }

  public DialogOptionNodeNodes? _Nodes;
  public DialogOptionNodeNodes Nodes {
    get {
      return _Nodes ??= new DialogOptionNodeNodes(this);
    }
  }
}
