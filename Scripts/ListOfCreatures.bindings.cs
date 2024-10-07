using Godot;
namespace ld56;

public partial class ListOfCreatures : PanelContainer {
  public static ListOfCreatures New() {
    return GD.Load<PackedScene>("res://Scenes/list_of_creatures.tscn").Instantiate<ListOfCreatures>();
  }
  public ListOfCreatures() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ListOfCreaturesNodes {
    ListOfCreatures parent;

    public ListOfCreaturesNodes(ListOfCreatures parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/list_of_creatures.tscn
    private MarginContainer? _MarginContainer;
    public MarginContainer MarginContainer {
      get => _MarginContainer ??= parent.GetNode<MarginContainer>("MarginContainer");
    }

    private HBoxContainer? _MarginContainer_CreatureList;
    public HBoxContainer MarginContainer_CreatureList {
      get => _MarginContainer_CreatureList ??= parent.GetNode<HBoxContainer>("MarginContainer/CreatureList");
    }

    private UpcomingCreatureUi? _MarginContainer_CreatureList_UpcomingCreatureUi;
    public UpcomingCreatureUi MarginContainer_CreatureList_UpcomingCreatureUi {
      get => _MarginContainer_CreatureList_UpcomingCreatureUi ??= parent.GetNode<UpcomingCreatureUi>("MarginContainer/CreatureList/UpcomingCreatureUi");
    }

  }

  public ListOfCreaturesNodes? _Nodes;
  public ListOfCreaturesNodes Nodes {
    get {
      return _Nodes ??= new ListOfCreaturesNodes(this);
    }
  }
}
