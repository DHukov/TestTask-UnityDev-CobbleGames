public class Injector
{
    IMoveController moveController;
    public IMoveController Init(ControllType controllType)
    {
        switch (controllType)
        {
            case ControllType.MouseNavMesh:
                moveController = new NavMeshController();
                return moveController;
            case ControllType.Keyborad:
                moveController = new KeyboradController();
                return moveController;
            case ControllType.AIFollower:
                moveController = new AIFollowerController();
                return moveController;
        }
        return moveController;
    }
}
